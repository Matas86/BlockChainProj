using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockChainProject
{
    class Operations
    {
        //constants
        double c1 = Math.Pow(13.0, 1.0 / 3);
        double c2 = Math.Pow(17.0, 1.0 / 3);
        double c3 = Math.Pow(23.0, 1.0 / 3);

        public string ConvertConstantc1()
        {
            long c1b = BitConverter.DoubleToInt64Bits(c1);
            string tempas = ConvertToBytes(c1b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);
            return tempas;
        }

        public string ConvertConstantc2()
        {
            long c2b = BitConverter.DoubleToInt64Bits(c2);
            string tempas = ConvertToBytes(c2b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);
            return tempas;
        }

        public string ConvertConstantc3()
        {
            long c2b = BitConverter.DoubleToInt64Bits(c3);
            string tempas = ConvertToBytes(c2b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);
            return tempas;
        }


        //Basic operations


        public List<string> Split(string a)
        {
            List<string> ats = new List<string>();
            int length = a.Length;
            for (int i = 0; i < length/64 +1; i++)
            {
                if (a.Length >= 64)
                {
                    ats.Add(a.Substring(0, 64));
                    a = a.Remove(i, 64);
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
                    c += "1";
                }
                else if (a[i] == '1' && b[i] == '1')
                {
                    c += "0";
                }
                else
                {
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

        public string Hash(List<string> a)
        {
            string ats = "";
            for (int i = 0; i < a.Count; i++)
            {
                a[i] = SHR(a[i], 33);
                a[i] = ROTR(a[i], 56);
                a[i] = SHR(a[i], 13);
                a[i] = ROTR(a[i], 42);
            }
            if (a.Count > 1)
            {
                ats = a[0];
                for (int i = 1; i < a.Count; i++)
                {
                    if (ats.Length == a[i].Length)
                    {
                        Console.WriteLine("IF");
                        Console.WriteLine(ats.Length + " " + a[i].Length);
                        ats = XOR(ats, a[i]);
                    }
                    else
                    {
                        Console.WriteLine("ELSE");
                        Console.WriteLine(ats.Length + " " + a[i].Length);
                        StringBuilder strB = new StringBuilder(a[i]);
                        for (int j = 0; j < 256-(a[i].Length); j++)
                        {
                            strB.Append(0);
                        }
                        a[i] = strB.ToString();
                        Console.WriteLine(ats.Length + " " + a[i].Length);
                        ats = XOR(ats, a[i]);
                    }
                }
            }
            
            

            return ats;
        }
    }
}
