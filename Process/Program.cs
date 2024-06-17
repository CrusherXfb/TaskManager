#define SINGLE_PROCESS
//#define ALL_PROCESSES
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Process
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if SINGLE_PROCESS
			Console.WriteLine("Введите имя программы");
			string process_name = Console.ReadLine();
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			process.StartInfo.FileName = process_name;
			process.Start();

			Console.WriteLine(
				process.ProcessName
				+ "\t" +
				process.Id
				+ "\t" +
				process.MainModule.FileName
				);

			IntPtr handle = IntPtr.Zero;
			OpenProcessToken(process.Handle, 8, out handle);
			System.Security.Principal.WindowsIdentity wi = new System.Security.Principal.WindowsIdentity(handle);
			CloseHandle(handle);
			Console.WriteLine($"Username:{wi.Name}");

			Console.WriteLine($"SessionID: {process.SessionId}");
			Console.WriteLine($"Threads: {process.Threads}");
			Console.WriteLine($"Priority: {process.PriorityClass}");

			PerformanceCounter counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName, true);
			Console.WriteLine("Press any key to continue");
			while(!Console.KeyAvailable)
			{
				Console.Clear();
				double proccent = counter.NextValue();
				Console.WriteLine($"{process.ProcessName} CPU load: {proccent / 10} %");
				int units = 1024 * 1024;
				Console.WriteLine($"Working set: {process.WorkingSet64 / units}");
				Console.WriteLine($"Private Working set: {process.PrivateMemorySize64 / units}");
				System.Threading.Thread.Sleep(100);
			}
			process.CloseMainWindow();
			process.Dispose();
			process = null;





#endif


#if ALL_PROCESSES
			System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
			float cpuUsageTotal = 0;
			for (int i = 0; i < processes.Length; i++)
			{
				Console.Write($"Name: {processes[i].ProcessName}\t");
				Console.Write($"PID: {processes[i].Id}\t");
				Console.Write($"Path: {processes[i].MainModule.FileName}\t");
				//string processName = processes[i].ProcessName; 
				//PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName);
				//cpuCounter.NextValue(); 
				//float cpuUsage = cpuCounter.NextValue();
				//cpuUsageTotal += cpuUsage;
				//Console.Write($"CPU usage: {cpuUsage}\t");
				//PerformanceCounter memoryCounter = new PerformanceCounter("Process", "Working Set", processName);
				//float memoryUsage = memoryCounter.NextValue();
				//Console.WriteLine($"Memory usage: {memoryUsage / 1024} KBytes");
				Console.WriteLine();
			}
			Console.WriteLine($"\n////////////////\nCPU usage total: {cpuUsageTotal}");

#endif


		}
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool OpenProcessToken(IntPtr processHandle, uint desired_access, out IntPtr handle);
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CloseHandle(IntPtr handle);
	}
}
