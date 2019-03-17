using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppman
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            ///EX 1 Bingo ---> Run ex 1 uncomment below ***





            //Ex1_Bingo ex1Bingo = new Ex1_Bingo();
            //do
            //{
            //    try
            //    {
            //        bool binggoResult = ex1Bingo.Bingo();
            //        if (binggoResult)
            //            Console.Write(binggoResult + " - " + "Bingo");
            //        else
            //            Console.Write(binggoResult + " - " + "Not Bingo");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.Write("Input Error.");
            //    }

            //    cki = Console.ReadKey();
            //} while (cki.Key != ConsoleKey.Escape);






            ///End of ex 1 Bingo

            ///EX 2 Compute  ---> Run ex 2 uncomment below ***





            do
            {
                try
                {

                    Ex2_Compute ex2Compute = new Ex2_Compute();
                    ex2Compute.Compute();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }

                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);






            //End of ex 2 Compute
        }
    }
}
