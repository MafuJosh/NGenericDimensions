using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NGenericDimensionsUnitTests
{
    public class TestsHelperBBase
    {
        protected void AssertCompilationFails(string expectedError, string csharpline)
        {
            CSharpCodeProvider codeProvider = null;

            try
            {
                codeProvider = new CSharpCodeProvider();
                var compilerparams = new CompilerParameters();
                compilerparams.GenerateExecutable = false;
                compilerparams.GenerateInMemory = true;
                compilerparams.ReferencedAssemblies.Add("System.dll");
                compilerparams.ReferencedAssemblies.Add("System.Core.dll");
                compilerparams.ReferencedAssemblies.Add("System.Numerics.dll");
                compilerparams.ReferencedAssemblies.Add("NGenericDimensions.dll");

                var className = "UnitTestDynamicCompiledCode";

                string codeStr = @"
                 public static class " + className + @"  
                 {
                     public static void Eval()
                     {
                            " + csharpline + @";
                       }
                 }";

                var results = codeProvider.CompileAssemblyFromSource(compilerparams, codeStr);

                var resultsMessage = string.Join(@" | ", results.Errors.OfType<CompilerError>().Select(e => e.ToString()));

                if (string.IsNullOrEmpty(expectedError))
                {
                    Assert.IsFalse(results.Errors.HasErrors, resultsMessage);
                }
                else
                {
                    Assert.IsTrue(resultsMessage.Contains(expectedError), resultsMessage);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                codeProvider.Dispose();
            }
        }
    }
}
