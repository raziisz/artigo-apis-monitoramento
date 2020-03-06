using System;
using System.Diagnostics;

namespace MonitorProcessamentoSimples
{
  class Program
  {
    static void Main(string[] args)
    {
      // Define variables to track the peak
      // memory usage of the process.
      long peakPagedMem = 0,
           peakWorkingSet = 0,
           peakVirtualMem = 0;

      // Start the process.
      using (Process myProcess = new Process())
      {
        myProcess.StartInfo.UseShellExecute = false;
        // You can start any process
        // myProcess.StartInfo.FileName = @"C:\Users\luiz.libertino\Documents\trabs\estudos\Artigo\Apis\api-dotnet\bin\Debug\netcoreapp3.1\api-dotnet.exe";
        myProcess.StartInfo.FileName = @"C:\Users\luiz.libertino\Documents\trabs\estudos\Artigo\Apis\api-node\index.exe";
        myProcess.StartInfo.CreateNoWindow = false;
        myProcess.Start();
        // Display the process statistics until
        // the user closes the program.
        do
        {
          if (!myProcess.HasExited)
          {
            // Refresh the current process property values.
            myProcess.Refresh();

            Console.WriteLine();

            // Display current process statistics.

            Console.WriteLine($"{myProcess} -");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine($"  Physical memory usage     : {ConvertToMegaByte(myProcess.WorkingSet64)}");
            Console.WriteLine($"  Base priority             : {myProcess.BasePriority}");
            Console.WriteLine($"  Priority class            : {myProcess.PriorityClass}");
            Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
            Console.WriteLine($"  Privileged processor time : {myProcess.PrivilegedProcessorTime}");
            Console.WriteLine($"  Total processor time      : {myProcess.TotalProcessorTime}");
            Console.WriteLine($"  Paged system memory size  : {ConvertToMegaByte(myProcess.PagedSystemMemorySize64)}");
            Console.WriteLine($"  Paged memory size         : {ConvertToMegaByte(myProcess.PagedMemorySize64)}");
            Console.WriteLine("-------------------------------------");
            // Update the values for the overall peak memory statistics.
            peakPagedMem = myProcess.PeakPagedMemorySize64;
            peakVirtualMem = myProcess.PeakVirtualMemorySize64;
            peakWorkingSet = myProcess.PeakWorkingSet64;

            if (myProcess.Responding)
            {
              Console.WriteLine("Status = Running");
            }
            else
            {
              Console.WriteLine("Status = Not Responding");
            }
          }
        }
        while (!myProcess.WaitForExit(1000));

        Console.WriteLine();
        Console.WriteLine($"  Process exit code          : {myProcess.ExitCode}");

        // Display peak memory statistics for the process.
        Console.WriteLine($"  Peak physical memory usage : {ConvertToMegaByte(peakWorkingSet)}");
        Console.WriteLine($"  Peak paged memory usage    : {ConvertToMegaByte(peakPagedMem)}");
        Console.WriteLine($"  Peak virtual memory usage  : {ConvertToMegaByte(peakVirtualMem)}");
      }
    }

    static private string ConvertToMegaByte(long bytes)
    {
      long megabytes = (bytes / 1024) / 1024;


      return $"{megabytes.ToString("F2")}mb";
    }
  }
}
