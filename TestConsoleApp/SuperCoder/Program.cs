using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SuperCoder
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("This is Rizwan");
            Console.WriteLine(Add(6,8));
        }

        public static int Add(int a, int b){
            return a + b;
        } 
        public static bool IsOdd(int a){
            return a%2 == 1;
        }

    }

}
