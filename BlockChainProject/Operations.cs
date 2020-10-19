using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainProject
{
    public class Operations
    {
        //MD5 operations

        public string TextToMD5(string input)
        {
            //Sukurti kodavimo objecta.
            var md5 = new MD5CryptoServiceProvider();
            //Konvertuoti teksta i baitu masyva
            byte[] inBytes = Encoding.UTF8.GetBytes(input);
            //Paskaiciuoti hasha
            byte[] OutBytes = md5.ComputeHash(inBytes);
            // Konvertuoti i teksta
            StringBuilder output = new StringBuilder();
            foreach (var item in OutBytes)
            {
                output.Append(item.ToString("X2"));
            }
            // grazinti reiksme
            return output.ToString();
        }

        //constants
        double c1 = Math.Sqrt(2) * Math.Pow(2, 32);
        double c2 = Math.Sqrt(3) * Math.Pow(2, 32);
        double c3 = Math.Sqrt(5) * Math.Pow(2, 32);
        double c4 = Math.Sqrt(7) * Math.Pow(2, 32);
        double c5 = Math.Sqrt(11) * Math.Pow(2, 32);
        double c6 = Math.Sqrt(13) * Math.Pow(2, 32);
        double c7 = Math.Sqrt(17) * Math.Pow(2, 32);
        double c8 = Math.Sqrt(19) * Math.Pow(2, 32);

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
            long c3b = BitConverter.DoubleToInt64Bits(c3);
            string tempas = ConvertToBytes(c3b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);

            return tempas;
        }

        public string ConvertConstantc4()
        {
            long c4b = BitConverter.DoubleToInt64Bits(c4);
            string tempas = ConvertToBytes(c4b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);

            return tempas;
        }

        public string ConvertConstantc5()
        {
            long c5b = BitConverter.DoubleToInt64Bits(c5);
            string tempas = ConvertToBytes(c5b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);

            return tempas;
        }

        public string ConvertConstantc6()
        {
            long c6b = BitConverter.DoubleToInt64Bits(c6);
            string tempas = ConvertToBytes(c6b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);

            return tempas;
        }

        public string ConvertConstantc7()
        {
            long c7b = BitConverter.DoubleToInt64Bits(c7);
            string tempas = ConvertToBytes(c7b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);

            return tempas;
        }

        public string ConvertConstantc8()
        {
            long c8b = BitConverter.DoubleToInt64Bits(c8);
            string tempas = ConvertToBytes(c8b.ToString());
            tempas = tempas.Remove(64, tempas.Length - 64);

            return tempas;
        }


        //Basic operations

        public double CheckSimilarity(string a, string b)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    sum++;
                }
            }
            return (sum / 144 * 100);
        }

        public double CheckSimilarityBi(string a, string b)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    sum++;
                }
            }
            return (sum / 512 * 100);
        }

        public List<string> Split(string a)
        {
            List<string> ats = new List<string>();
            int length = a.Length;

            if (length >= 64)
            {
                while (a.Length >=64)
                {
                    ats.Add(a.Substring(0, 64));
                    a = a.Remove(0, 64);
                }
            }

            if (a.Length < 64 && a.Length >0)
            {
                StringBuilder strB = new StringBuilder(a);
                for (int j = 0; j < 64 - a.Length - 8; j++)
                {
                    strB.Append(0);
                }
                for (int j = 0; j < 8; j++) strB.Append(1);
                ats.Add(strB.ToString());
            }


            return ats;

        }


        public string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }
        public string ConvertToBytes(string a)
        {
            if (a == "") a = " ";
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

            strB.Append(strB[strB.Length - 1]);

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


        //main operation
        public string Hash(List<string> a)
        {
            if (a.Count == 0)
            {
                a.Add(ConvertToBytes(" "));
            }
            string ats = "";
            string T1 = "";
            string T2 = "";
            string T3 = "";
            string T4 = "";
            string T5 = "";
            string T6 = "";
            string T7 = "";
            string T8 = "";
            for (int i = 0; i < a.Count; i++)
            {

                T1 = XOR(a[i], ConvertConstantc1());
                T1 = ROTR(T1, 10);
                T1 = ROTR(T1, 25);
                T1 = SHR(T1, 6);


                T2 = XOR(a[i], ConvertConstantc2());
                T2 = ROTR(T2, 42);
                T2 = SHR(T2, 5);

                T3 = XOR(a[i], ConvertConstantc3());
                T3 = ROTR(T3, 22);
                T3 = SHR(T3, 4);

                T4 = XOR(a[i], ConvertConstantc4());
                T4 = ROTR(T4, 33);
                T4 = SHR(T4, 3);


                T5 = XOR(a[i], ConvertConstantc5());
                T5 = ROTR(T5, 18);
                T5 = SHR(T5, 8);


                T6 = XOR(a[i], ConvertConstantc6());
                T6 = ROTR(T6, 37);
                T6 = SHR(T6, 4);


                T7 = XOR(a[i], ConvertConstantc7());
                T7 = ROTR(T7, 18);
                T7 = SHR(T7, 6);


                T8 = XOR(a[i], ConvertConstantc8());
                T8 = ROTR(T8, 29);

            }

            for (int i = 0; i < 32; i++)
            {
                T8 = T7;
                T7 = T6;
                T6 = T5;
                T5 = T4;
                T4 = T3;
                T3 = T2;
                T2 = T1;
                T1 = XOR(T1, T8);
                T1 = XOR(T1, T2);
                T5 = XOR(T5, T1);
            }

            List<string> T = new List<string>();

            T.Add(XOR(T1, T2));
            T.Add(XOR(T1, T3));
            T.Add(XOR(T2, T4));
            T.Add(XOR(T3, T5));
            T.Add(XOR(T4, T7));
            T.Add(XOR(T5, T8));
            T.Add(XOR(T7, T2));

            string Tt = "";

            for (int i = 8; i < 64; i++)
            {
                Tt = ROTR(T[i - 8], 14);
                Tt = XOR(T[i - 8], T[i - 5]);
                Tt = ROTR(Tt, 6);
                T.Add(Tt);
            }

            for (int i = 0; i < 62; i++)
            {
                T8 = T7;
                T7 = T6;
                T6 = T5;
                T5 = T4;
                T4 = T3;
                T3 = T2;
                T2 = T1;
                T1 = XOR(T[i], T[i + 1]);
                T5 = XOR(T5, T[i]);
            }

            ats += T1;
            ats += T2;
            ats += T3;
            ats += T4;
            ats += T5;
            ats += T6;
            ats += T7;
            ats += T8;

            //ats = BinaryStringToHexString(ats);


            return ats;
        }
    }
}
