using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPublishSubscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                //[0] type
                //[1] pipename
                //>1 message
                if (string.Equals("/server", args[0], StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Running in SERVER mode");
                    Console.WriteLine("Press 'q' to exit");
                    new Server(args[1]);
                }
                else
                {
                    Console.WriteLine("Running in CLIENT mode");
                    Console.WriteLine("Press 'q' to exit");
                    new Client(args[1]);
                }

            }
            else
            { 
                Console.WriteLine("Invalid number of arguments");

            }
        }
    }
}
