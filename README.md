# NGenericDimensions

## Project Description
NGenericDimensions™ is an experiment at creating a .NET library for attempting to represent quantities along with their units of measure, as generic dimensions like length, mass, etc., with compile time safety, lightweight value types, and some operator overloading.

## Examples

VB.NET 2010
```vbnet
Dim myspeed = 10.miles.per.hour
Dim yourspeed = 20.kilometres / 2.minutes
Dim mylength1 As New Length(Of Metres, Double)(100.0)
Dim mylength2 As New Length(Of Metres, Double)(200.0)
Dim mylength3 As Length(Of Metres, Double) = 300.0
Dim mylenght4 = mylength1 + mylength2
Dim myarea = mylength1 * mylength2
Dim myarea2 As Area(Of Metres, Double) = myarea
Dim myduration As New Duration(Of Durations.Minutes, Integer)(100)
```

C#.NET 2010
```csharp
var myspeed = (10).miles().per().hour();
var yourspeed = 20.kilometres() / 2.minutes();
Length<Metres, double> mylength1 = new Length<Metres, double>(100.0);
Length<Metres, double> mylength2 = new Length<Metres, double>(200.0);
Length<Metres, double> mylength3 = 300.0;
var mylenght4 = mylength1 + mylength2;
var myarea = mylength1 * mylength2;
Area<Metres, double> myarea2 = myarea;
var myduration = new Duration<Minutes, int>(100);
```

## Purpose

* Without this library, accurate source code comments and/or variable names are required to allow a programmer to know what the unit of measure of a variable is.  And the lack of compile-time checking can lead to bugs (programmer assumes variable is millimeters when it is really in inches, for example.)

Library Design

* The primary objective of this library is to be able to build units of measure into datatypes that are exposed by class's or interface's methods, functions, and properties.  So, for example, a class could expose a "Width" and a "Height" property with datatypes of being both of double and of millimeters.
* In order to accomplish this, new datatypes were needed to wrap the existing native .NET numeric value types.
* The secondary objective is to, as much as is reasonable and also allowed by the .NET Framework, to allow these new datatypes to have overloaded operators that allow them to work similar to native .NET datatype value types, with compile-time checking to make sure the math makes sense.  (Don't want to be able to add weight and distance together, for example.)
* These new datatypes were chosen to be .NET structures (rather than classes), to imitate the lightweight nature of the native .NET numeric value types.
* These new datatypes were chosen to only have one internal member value (the actual quantity value it represents), and no other value (including a value representing its unit of measure).
* 3 options for designing this new datatype are:
  1. Define a new structure for each unique combination of native .NET numeric value type and each unit of measure.
  2. Define a new generic structure for each unit of measure, taking the native .NET numeric value type as its generic type placeholder.
  3. Define a new generic structure for each dimension of unit of measure, taking a unit of measure type placeholder and a native .NET numeric value type placeholder.
* Option 1 was not chosen, mainly because the number of datatypes would be much higher, and so would the number of operator overloads.
* Option 2 was not chosen, mainly because the number of operator overloads would be too unreasonable.
* Option 3 was chosen, mainly because the number of datatypes dealing with operator overloads would be minimal.  Also, new units of measure could be defined with minimal code.  These generic datatypes are the "dimensions" of the quantity, along with the unit.  Hence, the appropriateness of the name of this library.
* Many other factors contributed to the decisions made.  Factors that came about while originally trying to design these datatypes.
* Limitations in the .NET Frameworks with regards to generics and operator overloading has limited the flexibility of the operator overloads.  These limitations have been minimized with clever use of interfaces and other mechanisms.
* Another object was to categorize the units, both by dimension (length, mass, time, etc.) and by the unit's system (metric for example).  .NET Namespaces were chosen as the method of categorization.
* An additional objective of this library was to try to use Extension Methods to allow shortcut ways to express quantities with their units of measures, such as, for example: 8.miles.per.hour.  Lower-case was chosen here as a way to differentiate these as a concept totally different than any normal .NET use of methods.  What we are trying to do is simulate this as if units of measure are built into the language.
* The non-US standard of spelling for "metres" was chosen over the US standard as "meters", just for the heck of it.
* Having multiple placeholders is frowned upon by .NET standards, like FxCop.  I consider this a worthy exception.  If you don't, then don't use this library.

## Roadmap

* This library has room to improve, grow, and change substantially before version 1 is reached.  Currently, many changes are more for proof of concept than for polishing the library.  Most of the design has been based on theory, and not on math testing or performance testing.
* I will likely be actively working on this at least once a month.
* I will open things up so that patches can be contributed by others on the internet.  And if someone has a passion for making this project succeed, I would carefully welcome others to join the core programming team.
