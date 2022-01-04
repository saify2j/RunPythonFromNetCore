using System;
using System.Diagnostics;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
namespace RunPythonConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunPythonWithIronPy();
            RunPythonWithBashLinux();
        }
        private static void RunPythonWithIronPy()
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.ExecuteFile(@"test.py");
        }
        private static void RunPythonWithBashLinux()
        {
            var resp = RunCommandWithBashLinux("python3  /var/www/testpythoncode/test.py");
            Console.WriteLine(resp);
        }
        private static string RunCommandWithBashLinux(string command)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = "/bin/bash";
            psi.Arguments = command;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            using var process = Process.Start(psi);

            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();

            return output;
        }
    }
}
