using AnalaizerClassLibrary;
using ErrorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace GetPriorityTest
{
    [TestClass]
    public class TestGetPriority
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=LAPTOP-7BBHUUPD\MSSQLSERVER2;Initial Catalog=GetPropertyTetst;Integrated Security=True", "TestTable", DataAccessMethod.Sequential)]
        public void GetPriorityTest()
        {
            // Arrange
            Console.WriteLine("Starting GetPriorityTest...");

            
            MethodInfo methodInfo = typeof(AnalaizerClass).GetMethod("GetPriority", BindingFlags.Static | BindingFlags.NonPublic);

            if (methodInfo == null)
            {
               
                Console.WriteLine("Method GetPriority not found");
                Assert.Fail("Method GetPriority not found");
                return;
            }

            try
            {
                // Act
               
                string test_value = TestContext.DataRow["test_value"].ToString();
                byte expected = Convert.ToByte(TestContext.DataRow["result_value"]);

                Console.WriteLine($"Testing input: {test_value}");

             
                byte result = (byte)methodInfo.Invoke(null, new object[] { test_value });

                // Assert
                Console.WriteLine($"Expected result: {expected}, Actual result: {result}");

              
                Assert.AreEqual(expected, result);
            }
            catch (Exception ex)
            {
                
                if (ex.InnerException is ArgumentOutOfRangeException)
                {
                  
                    Console.WriteLine($"Exception: {ErrorsExpression.ERROR_06}, ParamName: {(ex.InnerException as ArgumentOutOfRangeException).ParamName}");
                    Assert.AreEqual(ErrorsExpression.ERROR_06, (ex.InnerException as ArgumentOutOfRangeException).ParamName);
                }
                else
                {
                 
                    Console.WriteLine("Unexpected exception: " + ex.ToString());
                    Assert.Fail("Unexpected exception: " + ex.ToString());
                }
            }
            finally
            {
               
                Console.WriteLine("GetPriorityTest completed.");
            }
        }
    }
}
