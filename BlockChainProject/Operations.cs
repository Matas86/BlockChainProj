using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChainProject
{
    class Operations
    {
        

        //functions
        string sigma0(string a) //ROTR 7, ROTR18, SHR3, XOR 2-3, XOR 1-2
        {






            return a;
        }

        string sigma1(string a) //ROTR 17, ROTR 19, SHR10
        {
            return a;
        }

        string usigma0(string a) //ROTR2, ROTR 13, ROTR22
        {
            return a;
        }

        string usigma1(string a, string b) //ROTR6, ROTR11, ROTR25
        {
            return a;
        }

        string choice(string a, string b, string c) //use the first input, to determine, whether to use the second or the third, if its a 1, it takes string b, if its 0, it takes string c
        {
            return a;
        }
        string majority(string a, string b) //it takes the majority of bits
        {
            return a;
        }


        //Basic operations
       public string XOR(string a, string b) //sum of two bites - 1+0 = 1, 1+1 = 0, 0+1 = 1, 0+0 = 0.
        {
            string c = "";
            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i] == '1' && b[i] == '0') || (a[i] == '0' && b[i] == '1'))
                {
                    Console.WriteLine("1. " +a[i] + " " + b[i]);
                    c += "1";
                }
                else if (a[i] == '1' && b[i] == '1')
                {
                    Console.WriteLine("2. " + a[i] + " " + b[i]);
                    c += "0";
                }
                else
                {
                    Console.WriteLine("3. " + a[i] + " " + b[i]);
                    c += "0";
                }
            }
            return c;
        }

        public string ROTR(string a, int amount)
        {
            StringBuilder strB = new StringBuilder(a);

            for (int i = 0; i < amount; i++)
            {
                strB.Append(strB[strB.Length - 1]);
                for (int j = 0; j < strB.Length - 1; j++)
                {
                    strB[strB.Length - 1 - j] = strB[strB.Length - 2 - j];
                }
                strB[0] = strB[strB.Length - 1];
                strB.Remove(strB.Length - 1, 1);
            }

            return strB.ToString();

        }

        public string SHR(string a, int amount)
        {
            StringBuilder strB = new StringBuilder(a);

            strB.Append(strB[strB.Length-1]);

            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < strB.Length - 1; j++)
                {
                    strB[strB.Length - 1 - j] = strB[strB.Length - 2 - j];
                }
                strB[0] = '0';
            }

            strB.Remove(strB.Length - 1, 1);

            return strB.ToString();
        }
    }
}
