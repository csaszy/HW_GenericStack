using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_GenericStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericStack<int> genericStack = new GenericStack<int>();
            for(int i = 0; i < 10; i++) genericStack.Push(i);    

            Console.WriteLine($"Base: \n{genericStack.ToString()}\n");

            //1.feladat
            var slicedStack = genericStack.slice(1, 4);
            Console.WriteLine($"1.feladat: \n{string.Join("\t", slicedStack.Reverse())}\n");

            //2.feladat
            var splicedStack = genericStack.splice(2, 3, new int[]{9,9,9});
            Console.WriteLine($"2.feladat: \n{splicedStack.ToString()}\n");

            //3.feladat
            Console.WriteLine($"3.feladat: \n{genericStack.shift()}\n{genericStack.ToString()}\n");

            //4.feladat
            genericStack.unshift(9);
            Console.WriteLine($"4.feladat: \n{genericStack.ToString()}\n");

            //5.feladat
            Stack<float> floatStack = genericStack.map<float>(i => i / 100f);
            Console.WriteLine($"5.feladat: \n{string.Join("\t",floatStack.Reverse())}\n");
        }
    }
}
