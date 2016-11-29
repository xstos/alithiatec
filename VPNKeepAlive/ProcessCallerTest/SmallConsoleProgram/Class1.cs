using System;
using System.Threading;

namespace SmallConsoleProgram
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            for (int lineNumber = 0; lineNumber < 5000; lineNumber++)
            {
                Console.WriteLine ("Printing line: " + lineNumber);
                Thread.Sleep(2); // immitate doing something between Console Writes.
            }
            Console.WriteLine ("Wow, I'm exhausted!");
		}
	}
}
