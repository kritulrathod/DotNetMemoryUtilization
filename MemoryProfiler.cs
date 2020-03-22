using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryUtilization
{
  public static class MemoryProfiler
  {
    static Process currentProcess;
    static StringBuilder sb;

    public static void LogHeader()
    {
      Debug.WriteLine($@"DumpUsedMemory{'\t'}PagedMemorySize64{'\t'}PeakPagedMemorySize64{'\t'}PrivateMemorySize64{'\t'}VirtualMemorySize64");
    }

    public static void LogMemoryFootPrint(int arg)
    {
      sb = new StringBuilder();

      currentProcess = System.Diagnostics.Process.GetCurrentProcess();

      //x86
      //sb.Append($@",NonpagedSystemMemorySize {currentProcess.NonpagedSystemMemorySize}");
      //sb.Append($@",PagedMemorySize {currentProcess.PagedMemorySize}");
      //sb.Append($@",PagedSystemMemorySize {currentProcess.PagedSystemMemorySize}");
      //sb.Append($@",PeakPagedMemorySize {currentProcess.PeakPagedMemorySize}");
      //sb.Append($@",PeakVirtualMemorySize {currentProcess.PeakVirtualMemorySize}");
      //sb.Append($@",PrivateMemorySize {currentProcess.PrivateMemorySize}");
      //sb.Append($@",VirtualMemorySize {currentProcess.VirtualMemorySize}");

      //x64
      sb.Append($@"{arg.ToString("00000")}");
      sb.Append($@"{'\t'}{currentProcess.PagedMemorySize64}");
      sb.Append($@"{'\t'}{currentProcess.PeakPagedMemorySize64}");
      sb.Append($@"{'\t'}{currentProcess.PrivateMemorySize64}");
      sb.Append($@"{'\t'}{currentProcess.VirtualMemorySize64}");


      Debug.WriteLine(sb.ToString());
      sb = null;
    }

  }
}
