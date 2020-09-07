using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSystemTest
{
    class Program
    {
        //static List<int> charCodeArray = null;
        static string[] stringArray = new string[10000];
        static char[,] byteArray = new char[10000, 3];
        static void Main(string[] args)
        {
            initArray();
            Console.ReadLine();
        }

        static int getIndex(ref int i)
        {
            if (i >= 126)
            {
                i = 33;
            }
            else
            {
                i = i + 1;
            }
            return i;
        }

        static void initArray()
        {
            int cIdx = 0;
            for (int p1 = 33; p1 < 126; p1++)
            {
                for (int p2 = 33; p2 < 126; p2++)
                {
                    for (int p3 = 33; p3 < 126; p3++)
                    {
                        if (cIdx >= 9999)
                        {
                            return;
                        }
                        stringArray[cIdx] = Convert.ToString((char)p1) +
                           Convert.ToString((char)p2) +
                           Convert.ToString((char)p3);
                        //byteArray[cIdx] = stringArray[cIdx].ToCharArray();
                        var cs = stringArray[cIdx].ToCharArray();
                        byteArray[cIdx, 0] = cs[0];
                        byteArray[cIdx, 1] = cs[1];
                        byteArray[cIdx, 2] = cs[2];
                        cIdx += 1;
                    }
                }
            }
        }
    }
}
