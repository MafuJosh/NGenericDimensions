using NGenericDimensions.CodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace NGenericDimensions.CodeGenerator
{
    public class Engine
    {
        // T4Dimension.csv file headers
        const string dimensionHeader_NameUppercase       = "Dimension";
        const string dimensionHeader_NamePluralUppercase = "DimensionPlural";
        const string dimensionHeader_DerivedFromLength   = "Length";
        const string dimensionHeader_DerivedFromMass     = "Mass";
        const string dimensionHeader_DerivedFromDuration = "Duration";

        // T4Units.csv file headers
        const string unitHeader_NameUppercase            = "Name";
        const string unitHeader_NamePluralUppercase      = "NamePlural";
        const string unitHeader_Dimension                = "Dimension";
        const string unitHeader_SubFolder                = "SubFolder";
        const string unitHeader_UnitSymbol               = "UnitSymbol";
        const string unitHeader_FamilyBaseUnit           = "FamilyBaseUnit";
        const string unitHeader_FamilyMultiplier         = "FamilyMultiplier";
        const string unitHeader_SIBaseUnit               = "SIBaseUnit";
        const string unitHeader_SIMultiplier             = "SIMultiplier";
        const string unitHeader_SquaredSymbol            = "SquaredSymbol";
        const string unitHeader_CubedSymbol              = "CubedSymbol";
        const string unitHeader_GenericMetricPrefix      = "GenericMetricPrefix";

        //T4SIPrefix.csv file headers
        const string siPrefixHeader_Prefix               = "Prefix";
        const string siPrefixHeader_Multiplier           = "Multiplier";
        const string siPrefixHeader_UnitSymbol           = "UnitSymbol";

        // one for each row in T4Dimensions.csv
        public readonly Dimension[] Dimensions;

        // one for each row in T4Units.csv
        public readonly Unit[] Units;

        // one for each row in T4SIPrefix.csv
        public readonly SIPrefix[] SIPrefixes;

        public readonly DimensionUnitOfMeasureBase[] DimensionUnitOfMeasureBases;

        public Engine()
        {
            // read csv files into arrays of dictionaries
            var dimensionRowsOfKeyedValues = ReadArrayOfDictionariesFromCsv("T4Dimensions.csv");
            var unitRowsOfKeyedValues      = ReadArrayOfDictionariesFromCsv("T4Units.csv");
            var siPrefoxRowsOfKeyedValues  = ReadArrayOfDictionariesFromCsv("T4SIPrefix.csv");

            // create SI Prefixes from csv file data
            SIPrefixes = siPrefoxRowsOfKeyedValues
                .Select(dict => new SIPrefix()
                {
                    Prefix = dict[siPrefixHeader_Prefix],
                    Multiplier = dict[siPrefixHeader_Multiplier],
                    UnitSymbol = dict[siPrefixHeader_UnitSymbol]
                })
                .ToArray();

            // create Dimensions from csv file data
            Dimensions = dimensionRowsOfKeyedValues
                .Select(dict => new Dimension()
                {
                    NameUppercase       = dict[dimensionHeader_NameUppercase],
                    NamePluralUppercase = dict[dimensionHeader_NamePluralUppercase],
                    NameLowercase       = dict[dimensionHeader_NameUppercase].MakeFirstCharLowercase(),
                    NamePluralLowercase = dict[dimensionHeader_NamePluralUppercase].MakeFirstCharLowercase()
                })
                .ToArray();

            // populate each BaseDimension.BaseDimensionsThisDerivedFrom
            for (int i = 0; i < Dimensions.Length; i++)
            {
                Dimensions[i].BaseDimensionsThisDerivedFrom =
                    (new[] {
                    Tuple.Create("Length"  , dimensionRowsOfKeyedValues[i][dimensionHeader_DerivedFromLength]),
                    Tuple.Create("Mass"    , dimensionRowsOfKeyedValues[i][dimensionHeader_DerivedFromMass]),
                    Tuple.Create("Duration", dimensionRowsOfKeyedValues[i][dimensionHeader_DerivedFromDuration])
                    })
                    .Where(t => !string.IsNullOrEmpty(t.Item2)) // ignore empty values under the Length, Mass, Duration column headers
                    .Select(t => new BaseAndDerivedDimensionPair()
                    {
                        BaseDimension = Dimensions.First(d => d.NameUppercase == t.Item1),
                        DerivedDimension = Dimensions[i],
                        Mode = int.Parse(t.Item2) // 1,2,3,-1,-2,-3,etc
                    }).ToArray();
            }

            // populate IsSquaredDimension, IsCubedDimension, IsSquaredOrCubedDimension for each dimension
            foreach (var dimension in Dimensions.Where(d => d.BaseDimensionsThisDerivedFrom.Length == 1))
            {
                dimension.IsSquaredDimension = dimension.BaseDimensionsThisDerivedFrom.Any(d => d.Mode == 2);
                dimension.IsCubedDimension = dimension.BaseDimensionsThisDerivedFrom.Any(d => d.Mode == 3);
                dimension.IsSquaredOrCubedDimension = dimension.IsSquaredDimension || dimension.IsCubedDimension;
            }

            // populate each BaseDimension.DerivedDimensionsFromThisBase
            foreach (var dimension in Dimensions)
            {
                dimension.DerivedDimensionsFromThisBase =
                    Dimensions
                    .Select(d => d.BaseDimensionsThisDerivedFrom.FirstOrDefault(dd => dd.BaseDimension == dimension))
                    .Where(dd => dd != null)
                    .ToArray();
            }

            // set more props on each dimension
            foreach (var dimension in Dimensions)
            {
                dimension.IsBaseDimension = dimension.BaseDimensionsThisDerivedFrom.Length == 1 && dimension.BaseDimensionsThisDerivedFrom[0].Mode == 1;
                dimension.IsDerivedDimension = !dimension.IsBaseDimension;
                dimension.BaseDimensionsThisDerivedFromInNumerator = dimension.BaseDimensionsThisDerivedFrom.Where(d => d.IsBaseInNumerator).ToArray();
                dimension.BaseDimensionsThisDerivedFromInDenominator = dimension.BaseDimensionsThisDerivedFrom.Where(d => d.IsBaseInDenominator).ToArray();
            }
            foreach (var dimension in Dimensions)
            {
                dimension.IsPerSource = dimension
                    .DerivedDimensionsFromThisBase
                    .Where(bd => bd.IsBaseInNumeratorWithADenominator)
                    .Where(bd => bd.DerivedDimension.BaseDimensionsThisDerivedFromInNumerator.Length == 1)
                    .Any();
            }

            // create Units from csv file data
            Units = unitRowsOfKeyedValues
                .Select(dict => new Unit()
                {
                    NameUppercase       = dict[unitHeader_NameUppercase],
                    NamePluralUppercase = dict[unitHeader_NamePluralUppercase],
                    NameLowercase       = dict[unitHeader_NameUppercase].MakeFirstCharLowercase(),
                    NamePluralLowercase = dict[unitHeader_NamePluralUppercase].MakeFirstCharLowercase(),
                    Dimension           = Dimensions.First(d => d.NameUppercase == dict[unitHeader_Dimension]),
                    SubFolder           = (dict[unitHeader_SubFolder] ?? "").StartsWith("[") ? null : dict[unitHeader_SubFolder], // change [Standard] to NULL
                    UnitGroupName       = dict[unitHeader_SubFolder].Replace("[","").Replace("]",""),
                    UnitSymbol          = dict[unitHeader_UnitSymbol].NullIfEmpty(),
                    InheritsSIPrefix    = dict[unitHeader_NamePluralUppercase].EndsWithAny(StringComparison.Ordinal, "metres", "grams", "seconds"),
                    SquaredSymbol       = dict[unitHeader_SquaredSymbol],
                    CubedSymbol         = dict[unitHeader_CubedSymbol],
                    IsMetricBaseUnit    = ("1" == (dict[unitHeader_GenericMetricPrefix].NullIfEmpty() ?? "0")),
                    IsDerivedUnit       = string.IsNullOrEmpty(dict[unitHeader_FamilyBaseUnit])
                })
                .ToArray();

            // set more props on each unit
            foreach (var unit in Units)
            {
                unit.FamilyBaseUnit = Units.SingleOrDefault(u => u.NameUppercase == unitRowsOfKeyedValues.First(d => d[unitHeader_NameUppercase] == unit.NameUppercase)[unitHeader_FamilyBaseUnit]);
                unit.FamilyMultiplier = Helper.FormatCSharpNumericConstant(unitRowsOfKeyedValues.First(d => d[unitHeader_NameUppercase] == unit.NameUppercase)[unitHeader_FamilyMultiplier].Split('*').Skip(1).FirstOrDefault() ?? "1");
                unit.FamilyDivisor = Helper.FormatCSharpNumericConstant(unitRowsOfKeyedValues.First(d => d[unitHeader_NameUppercase] == unit.NameUppercase)[unitHeader_FamilyMultiplier].Split('/').Skip(1).FirstOrDefault() ?? "1");
                unit.SIBaseUnit = Units.SingleOrDefault(u => u.NameUppercase == unitRowsOfKeyedValues.First(d => d[unitHeader_NameUppercase] == unit.NameUppercase)[unitHeader_SIBaseUnit]);
                unit.SIMultiplier = Helper.FormatCSharpNumericConstant(unitRowsOfKeyedValues.First(d => d[unitHeader_NameUppercase] == unit.NameUppercase)[unitHeader_SIMultiplier].Split('*').Skip(1).FirstOrDefault() ?? "1");
                unit.SIDivisor = Helper.FormatCSharpNumericConstant(unitRowsOfKeyedValues.First(d => d[unitHeader_NameUppercase] == unit.NameUppercase)[unitHeader_SIMultiplier].Split('/').Skip(1).FirstOrDefault() ?? "1");
            }

            // set more props on each dimension
            foreach (var dimension in Dimensions)
            {
                dimension.Units = Units.Where(u => u.Dimension.NameUppercase == dimension.NameUppercase).ToArray();

                dimension.IsUsedExponentiallyInDimensions =
                    dimension.BaseDimensionsThisDerivedFrom.Length == 1 &&
                    dimension.BaseDimensionsThisDerivedFrom[0].BaseDimension == dimension &&
                    Dimensions.Any(d => d.BaseDimensionsThisDerivedFrom.Any(dd => dd.BaseDimension == dimension && Math.Abs(dd.Mode) > 1))
                    ;
            }

            // set more unit props
            foreach (var unit in Units.Where(o => !o.IsDerivedUnit))
            {
                if (!string.IsNullOrEmpty(unit.SubFolder))
                {
                    unit.Namespace = $@"{unit.Dimension.NamePluralUppercase}.{unit.SubFolder}";
                }
                else
                {
                    unit.Namespace = $@"{unit.Dimension.NamePluralUppercase}";
                }
                unit.FullClassName = $@"{unit.Namespace}.{unit.NamePluralUppercase}";
                if (unit.InheritsSIPrefix)
                    unit.SIPrefix = unit.NamePluralUppercase.RemoveOccurancesOfText("metres","grams","seconds");
                unit.MetricBaseClassName = (unit.InheritsSIPrefix ? unit.NamePluralUppercase.Replace(unit.SIPrefix, "").MakeFirstCharUppercase() : null);
            }

            var tempDimensionUnitOfMeasureBases = new List<DimensionUnitOfMeasureBase>();

            // "UnitOfMeasure" base classes for each primary dimension
            foreach (var dimension in Dimensions.Where(d => d.Units.Any() && d.BaseDimensionsThisDerivedFrom.Length == 1 && d.BaseDimensionsThisDerivedFrom[0].BaseDimension == d))
            {
                var uomBase = new DimensionUnitOfMeasureBase()
                {
                    Dimension = dimension,
                    InterfaceName = dimension.NameUppercase + "UnitOfMeasure"
                };

                tempDimensionUnitOfMeasureBases.Add(uomBase);

                if (dimension.IsUsedExponentiallyInDimensions)
                {
                    uomBase = new DimensionUnitOfMeasureBase()
                    {
                        Dimension = dimension,
                        Is1DInterface = true,
                        InterfaceName = dimension.NameUppercase + "1DUnitOfMeasure",
                        BaseInterface = tempDimensionUnitOfMeasureBases.Last(),
                        Symbol2D = Units.FirstOrDefault(u => u.Dimension == dimension && u.FamilyBaseUnit == u.SIBaseUnit && u.FamilyBaseUnit == u)?.SquaredSymbol,
                        Symbol3D = Units.FirstOrDefault(u => u.Dimension == dimension && u.FamilyBaseUnit == u.SIBaseUnit && u.FamilyBaseUnit == u)?.CubedSymbol
                    };

                    tempDimensionUnitOfMeasureBases.Add(uomBase);
                }
            }

            // "UnitOfMeasure" base classes for each derived dimension
            foreach (var dimension in Dimensions.Where(d => d.Units.Any() && !(d.BaseDimensionsThisDerivedFrom.Length == 1 && d.BaseDimensionsThisDerivedFrom[0].BaseDimension == d)))
            {
                var uomBase = new DimensionUnitOfMeasureBase()
                {
                    Dimension = dimension,
                    InterfaceName = dimension.NameUppercase + "UnitOfMeasure",
                    Is2DInterface = (dimension.BaseDimensionsThisDerivedFrom.Length == 1 && dimension.BaseDimensionsThisDerivedFrom[0].Mode == 2),
                    Is3DInterface = (dimension.BaseDimensionsThisDerivedFrom.Length == 1 && dimension.BaseDimensionsThisDerivedFrom[0].Mode == 3)
                };

                if (uomBase.Is2DInterface)
                {
                    uomBase.InterfaceName = uomBase.Dimension.BaseDimensionsThisDerivedFrom[0].BaseDimension.NameUppercase + "2DUnitOfMeasure";
                    uomBase.BaseInterface = tempDimensionUnitOfMeasureBases.Single(d => d.InterfaceName == (uomBase.Dimension.BaseDimensionsThisDerivedFrom[0].BaseDimension.NameUppercase + "UnitOfMeasure"));
                }

                if (uomBase.Is3DInterface)
                {
                    uomBase.InterfaceName = uomBase.Dimension.BaseDimensionsThisDerivedFrom[0].BaseDimension.NameUppercase + "3DUnitOfMeasure";
                    uomBase.BaseInterface = tempDimensionUnitOfMeasureBases.Single(d => d.InterfaceName == (uomBase.Dimension.BaseDimensionsThisDerivedFrom[0].BaseDimension.NameUppercase + "UnitOfMeasure"));
                }

                tempDimensionUnitOfMeasureBases.Add(uomBase);
            }

            // "UnitOfMeasure" base classes for each group of units
            foreach (var unitGroup in Units.Where(o => !o.IsDerivedUnit).Select(u => Tuple.Create(u.Dimension, u.UnitGroupName, u.FamilyBaseUnit, u.SubFolder)).Distinct())
            {
                var uomBase = new DimensionUnitOfMeasureBase()
                {
                    Dimension = unitGroup.Item1,
                    InterfaceName = $"{unitGroup.Item2}{unitGroup.Item1.NameUppercase}UnitOfMeasure",
                    UnitGroupName = unitGroup.Item2,
                    SubFolder = unitGroup.Item4,
                    BaseInterface = tempDimensionUnitOfMeasureBases.Last(d => d.Dimension == unitGroup.Item1 && d.UnitGroupName == null),
                    NonFamilyMultiplier = unitGroup.Item3.SIMultiplier
                };

                if (!string.IsNullOrEmpty(unitGroup.Item3.SquaredSymbol) && unitGroup.Item3.SquaredSymbol != uomBase.BaseInterface.Symbol2D)
                    uomBase.Symbol2D = unitGroup.Item3.SquaredSymbol;

                if (!string.IsNullOrEmpty(unitGroup.Item3.CubedSymbol) && unitGroup.Item3.CubedSymbol != uomBase.BaseInterface.Symbol3D)
                    uomBase.Symbol3D = unitGroup.Item3.CubedSymbol;

                tempDimensionUnitOfMeasureBases.Add(uomBase);
            }

            DimensionUnitOfMeasureBases = tempDimensionUnitOfMeasureBases.ToArray();

            foreach (var dimension in Dimensions)
            {
                foreach (var derivedFrom in dimension.BaseDimensionsThisDerivedFrom)
                {
                    derivedFrom.UnitOfMeasureBase = tempDimensionUnitOfMeasureBases.Last(u => u.Dimension == derivedFrom.BaseDimension && u.UnitGroupName == null);
                    derivedFrom.ModeDimension = GetModeDimension(derivedFrom.Mode, derivedFrom.BaseDimension, Dimensions);
                }
            }
        }

        private static Dimension GetModeDimension(int mode, Dimension baseDimension, Dimension[] dimensions)
        {
            if (Math.Abs(mode) == 3) return dimensions.FirstOrDefault(d => d.IsCubedDimension && d.BaseDimensionsThisDerivedFrom.First().BaseDimension == baseDimension) ?? baseDimension;
            if (Math.Abs(mode) == 2) return dimensions.FirstOrDefault(d => d.IsSquaredDimension && d.BaseDimensionsThisDerivedFrom.First().BaseDimension == baseDimension) ?? baseDimension;
            return baseDimension;
        }

        private static Dictionary<string, string>[] ReadArrayOfDictionariesFromCsv(string fileName)
        {
            var rowsOfKeyedValues = File.
                ReadAllLines(Path.Combine(Helper.GetAssemblyLocation(), @"Data\" + fileName), Encoding.UTF8).
                Where(line => !line.StartsWith("#")).
                Where(line => !string.IsNullOrWhiteSpace(line)).
                ToArrayOfKeyedValues();
            return rowsOfKeyedValues;
        }

        public void ClearOutputFolder()
        {
            // determine root folder
            var outputFolder = Path.Combine(GetRootDirectory(), "CodeGenerator.Output");

            // delete output folder
            Console.WriteLine($"deleting {outputFolder}...");
            if (Directory.Exists(outputFolder))
            {
                Directory.Delete(outputFolder, true);
            }
        }

        public void GenerateSIPrefixFile()
        {
            var t4Template = new T4SIPrefix(SIPrefixes);
            var fileContents = t4Template.TransformText();
            SaveOutputFile(fileContents, "SIPrefix.cs");
        }

        public void GenerateUnitFiles()
        {
            foreach (var unit in Units.Where(o => !o.IsDerivedUnit))
            {
                var t4Template = new T4Unit(unit, Units);
                var fileContents = t4Template.TransformText();
                SaveOutputFile(fileContents, unit.NamePluralUppercase + ".cs", unit.Dimension.NamePluralUppercase, unit.SubFolder);
            }
        }

        public void GenerateDimensionFiles()
        {
            foreach (var dimension in Dimensions)
            {
                var t4Template = new T4Dimension(dimension, Dimensions, SIPrefixes);
                var fileContents = t4Template.TransformText();
                SaveOutputFile(fileContents, dimension.NameUppercase + ".cs");
            }
        }

        public void GenerateDimensionUnitOfMeasureBaseFiles()
        {
            foreach (var dimensionUnitOfMeasureBase in DimensionUnitOfMeasureBases)
            {
                var t4Template = new T4DimensionUnitOfMeasure(dimensionUnitOfMeasureBase);
                var fileContents = t4Template.TransformText();
                SaveOutputFile(fileContents, dimensionUnitOfMeasureBase.InterfaceName + ".cs", dimensionUnitOfMeasureBase.Dimension.NamePluralUppercase, dimensionUnitOfMeasureBase.SubFolder);
            }
        }

        private static string GetRootDirectory()
        {
            return string.Join("\\", AppDomain.CurrentDomain.BaseDirectory.Split('\\').Reverse().SkipWhile(o => o != @"CodeGenerator").Skip(1).Reverse());
        }

        public static void SaveOutputFile(string fileContents, string outputFileName, params string[] outputSubPaths)
        {
            // determine root folder
            var newDirectoryName = GetRootDirectory();

            // create output sub folders
            foreach (var subPath in (new[] { "CodeGenerator.Output" }.Concat(outputSubPaths.Where(p => p != null))))
            {
                foreach (var subsubPath in subPath.Split('\\'))
                {
                    newDirectoryName = Path.Combine(newDirectoryName, subsubPath);
                    if (!Directory.Exists(newDirectoryName))
                        Directory.CreateDirectory(newDirectoryName);
                }
            }

            // add file name to folder path
            string outputFilePath = Path.Combine(newDirectoryName, outputFileName);

            // write file
            Console.WriteLine($"writing {outputFilePath.Substring(GetRootDirectory().Length)}...");
            File.WriteAllText(outputFilePath, fileContents, System.Text.Encoding.UTF8);
        }
    }
}
