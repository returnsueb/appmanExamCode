using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppman
{
    class Ex1_Bingo
    {
        public bool Bingo()
        {  
            Console.WriteLine("1. Bingo Game.");
            int colSize = 5;
            int rowSize = 5;
            int indexCount = 0;
            //Create  bingo in array
            int[,] bingoArray = new int[colSize, rowSize];
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    indexCount++;
                    bingoArray[i, j] = indexCount;
                    Console.Write("\t" + indexCount);
                }
                Console.Write("\n");
            }


            return resultBingo(bingoArray);

        }
        /// <summary>
        /// Method for check bingo
        /// </summary>
        /// <param name="param">Bingo Array</param>
        /// <returns></returns>
        private bool resultBingo(int[,] param)
        {

            Console.Write("\nInput elements of an array: ");

            //
            int numberOfMember = int.Parse(Console.ReadLine());

            int[] inputArray = new int[numberOfMember];

            //Input int in array
            for (int x = 0; x < numberOfMember; x++)
            {
                Console.Write("element - {0} : ", x + 1);
                inputArray[x] = Convert.ToInt32(Console.ReadLine());
            }

            //Declare diagonal for check
            int diagonal = (int)(Math.Sqrt(param.Length));

            //Declare mactch member and input
            int matchMemberRow = 0;
            int matchMemberCol = 0;
            int matchMemberDai1 = 0;
            int matchMemberDai2 = 0;


            for (int i = 0; i < diagonal; i++)
            {
                matchMemberRow = 0;
                matchMemberCol = 0;
                for (int j = 0; j < diagonal; j++)
                {
                    //Find bingo row
                    if (Array.FindAll(inputArray, x => x == param[i, j]).Any())
                    {
                        matchMemberRow++;
                    }
                    //Find bingo column
                    if (Array.FindAll(inputArray, x => x == param[j, i]).Any())
                    {
                        matchMemberCol++;
                    }
                }
                //Check bingo row and column
                if (matchMemberRow == diagonal || matchMemberCol == diagonal)
                {
                    return true;
                }

                //Find diagonal right
                if (Array.FindAll(inputArray, x => x == param[i, i]).Any())
                {
                    matchMemberDai1++;
                }
                //Find diagonal left
                if (Array.FindAll(inputArray, x => x == param[i, ((diagonal - 1) - i)]).Any())
                {
                    matchMemberDai2++;
                }
            }

            //Check bingo right and left
            if (matchMemberDai1 == diagonal || matchMemberDai2 == diagonal)
            {
                return true;
            }

            return false;
        }
    }
}
