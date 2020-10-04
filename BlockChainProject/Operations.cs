using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockChainProject
{
    class Operations
    {
        //Basic operations


        public List<string> Split(string a)
        {
            List<string> ats = new List<string>();
            int length = a.Length;
            for (int i = 0; i < length/256 +1; i++)
            {
                if (a.Length >= 256)
                {
                    ats.Add(a.Substring(0, 256));
                    a = a.Remove(i, 256);
                }
                else
                {
                    ats.Add(a.Substring(0, a.Length-1));
                    
                }
                
            }
            return ats;

        }


        public string ConvertToBytes(string a)
        {
            byte[] test = Encoding.UTF8.GetBytes(a);
            string yourByteString = "";
            foreach (var item in test)
            {
                yourByteString += Convert.ToString(item, 2).PadLeft(8, '0');
            }
            return yourByteString;
        }


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
