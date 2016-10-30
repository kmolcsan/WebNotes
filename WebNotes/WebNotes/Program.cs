using System;
using System.Diagnostics;
using ServiceStack.Text;

namespace WebNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppHost().Init().Start("http://*:8088/");
            "WebNotes API is listening at http://127.0.0.1:8088".Print();
            Process.Start("http://127.0.0.1:8088/");

            Console.ReadLine();
        }
    }
}
