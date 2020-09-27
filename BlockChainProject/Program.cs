using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainProject
{
    public class Program
    {
        const int MUST_BE_LESS_THAN = 100000000;

        /*public byte[] GetStableHash(string s)
        {
            uint hash = 0;
            
            foreach (byte b in System.Text.Encoding.Unicode.GetBytes(s))
            {
                hash += b;
                //hash += (hash << 10);
                //hash ^= (hash >> 6);
            }
            
            //hash += (hash << 3);
            //hash ^= (hash >> 11);
            //hash += (hash << 15);
       
            return (hash);
        }*/

        public void Hashuok()
        {
            string num = "asd";
            byte[] temp = Encoding.UTF8.GetBytes(num); //pakeicia i byte array
            string hashString = "";
            foreach (byte x in temp)
            {
                hashString += String.Format("{0:x2}", x);
            }
            //int tempas = GetStableHash(num);
            //var str = System.Text.Encoding.Default.GetString(temp); //atkeicia atgal is byte i string
            Console.WriteLine(str);
        }
        static void Main(string[] args)
        {
            Program moto = new Program();

            moto.Hashuok();
        }

        

    }

    
}
