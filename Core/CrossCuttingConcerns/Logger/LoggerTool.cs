using Castle.DynamicProxy;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logger
{
    public  class LoggerTool
    {
        public static void LoggerService(string detail , string kind,string methodName)
        {
            string connnectionstring = @"Server=(localdb)\mssqllocaldb;Database=Logging;Trusted_Connection=true";
            string tableName = "Logs";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("D:\\repos\\ETrade\\Console\\file.txt")
                .WriteTo.MSSqlServer(connnectionstring, tableName)
            .CreateLogger();

            try
            {
                Log.Debug("->Operation : " + methodName +
                    " ->Type of: " + kind +
                    " ->Details: " + detail +
                    " ->Date: " + DateTime.Now.Date.ToString().Split(" ").First() +
                    " ->Hour: " + DateTime.Now.Hour +
                    " ->Minute: " + DateTime.Now.Minute
                    );

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
        
    }
}
