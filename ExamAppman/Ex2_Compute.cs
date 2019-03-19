using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppman
{
    class Ex2_Compute
    {
        public void Compute()
        {
            Console.Write("\nInput calculate result from input formula: ");
            string formula = Console.ReadLine();
            double result = SeparateFormula(formula);
            Console.Write(formula + " = " + result);
        }

        private double SeparateFormula(string formula)
        {

            Stack<string> stack = new Stack<string>();

            string value = string.Empty;
            for (int i = 0; i < formula.Length; i++)
            {
                string str = formula.Substring(i, 1);
                char chr = str.ToCharArray()[0];

                if (!char.IsDigit(chr) && value != "")
                {
                    stack.Push(value);
                    value = string.Empty;
                }

                if (str.Equals("("))
                {
                    string innerExp = string.Empty;
                    i++;
                    int bracketCount = 0;
                    for (; i < formula.Length; i++)
                    {
                        str = formula.Substring(i, 1);

                        if (str.Equals("("))
                            bracketCount++;

                        if (str.Equals(")"))
                            if (bracketCount == 0)
                            {
                                break;
                            }
                            else
                            {
                                bracketCount--;
                            }

                        innerExp += str;
                    }

                    stack.Push(SeparateFormula(innerExp).ToString());
                }
                else if (str.Equals("+"))
                {
                    stack.Push(str);
                }
                else if (str.Equals("-"))
                {
                    stack.Push(str);
                }
                else if (str.Equals("*"))
                {
                    stack.Push(str);
                }
                else if (str.Equals("/"))
                {
                    stack.Push(str);
                }
                else if (str.Equals(")"))
                {
                }
                else if (char.IsDigit(chr))
                {
                    value += str;
                    if (i == (formula.Length - 1))
                        stack.Push(value);
                }
                else
                {
                    throw new Exception("Invalid character.");
                }
            }

            int ArrayConut = 0;
            while (stack.Count >= 3)
            {
                int result = 0;
                List<string> arrayResult = new List<string>();
                List<string> array = stack.Reverse().ToList();

                //Compute (+) and (-) is the first priority.
                do
                {
                    if (array[ArrayConut].Contains("-"))
                    {
                        if (result == 0 && arrayResult[arrayResult.Count - 1] != "0")
                        {
                            result = Convert.ToInt16(array[ArrayConut - 1]) - Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        else
                        {
                            result -= Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        arrayResult[arrayResult.Count - 1] = result.ToString();
                        ArrayConut++;
                    }
                    else if (array[ArrayConut].Contains("+"))
                    {
                        if (result == 0 && arrayResult[arrayResult.Count - 1] != "0")
                        {
                            result = Convert.ToInt16(array[ArrayConut - 1]) + Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        else
                        {

                            result += Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        arrayResult[arrayResult.Count - 1] = result.ToString();
                        ArrayConut++;
                    }
                    else
                    {
                        result = 0;
                        arrayResult.Add(array[ArrayConut]);
                    }

                    ArrayConut++;

                } while (array.Count - 1 >= ArrayConut);
                // End Compute (+) and (-) is the first priority.

                //Compute (*) and (/).
                ArrayConut = 0;
                array.Clear();
                array = arrayResult;
                List<string> arrayResult2 = new List<string>();
                do
                {
                    if (array[ArrayConut].Contains("*"))
                    {
                        if (result == 0 && arrayResult2[arrayResult2.Count - 1] != "0")
                        {
                            result = Convert.ToInt16(array[ArrayConut - 1]) * Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        else
                        {
                            result *= Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        arrayResult2[arrayResult2.Count - 1] = result.ToString();
                        ArrayConut++;
                    }
                    else if (array[ArrayConut].Contains("/"))
                    {
                        if (result == 0 && arrayResult2[arrayResult2.Count - 1] != "0")
                        {
                            result = Convert.ToInt16(array[ArrayConut - 1]) / Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        else
                        {

                            result /= Convert.ToInt16(array[ArrayConut + 1]);
                        }
                        arrayResult2[arrayResult2.Count - 1] = result.ToString();
                        ArrayConut++;
                    }
                    else
                    {
                        result = 0;
                        arrayResult2.Add(array[ArrayConut]);
                    }

                    ArrayConut++;

                } while (array.Count - 1 >= ArrayConut);
                // End Compute (*) and (/).

                stack.Clear();
                stack.Push(arrayResult2[0].ToString());
            }

            return Convert.ToDouble(stack.Pop());
        }
    }
}

