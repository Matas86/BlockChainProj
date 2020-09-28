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
        string XOR(string a, string b) //sum of two bites - 1+0 = 1, 1+1 = 0, 0+1 = 1, 0+0 = 0.
        {

            return a;
        }

        string ROTR(string a, int amount)
        {

            return a;
        }

        string SHR(string a, int amount)
        {
            StringBuilder strB = new StringBuilder(a);

            strB.Append(strB[strB.Length-1]);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < strB.Length - 1; j++)
                {
                    strB[strB.Length - 1 - j] = strB[strB.Length - 2 - j];
                }
                strB[0] = '0';
            }

            strB.Remove(strB.Length - 2, 2);

            return a;
        }
    }
}
