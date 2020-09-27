using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainProject
{
    public class Program
    {
        //const int MUST_BE_LESS_THAN = 100000000;

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

        long hash(string str)
        {
            long hash = 5381;
            //int c;

            foreach (var item in str)
            {
                hash = ((hash << 5) + hash) + item;
            }


            return hash;
        }

        public List<string> ReadFile(string file)
        {
            List<string> text = new List<string>();
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(file))
                {
                    // Read the stream as a string, and write the string to the console.
                    while (!sr.EndOfStream)
                    {
                        text.Add(sr.ReadLine());

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return text;
        }
        public void Hashuok(string filename)
        {
            string num = "asd";
            byte[] temp = Encoding.UTF8.GetBytes(num); //pakeicia i byte array
            string hashString = "";
            foreach (byte x in temp)
            {
                hashString += String.Format("{0:x2}", x);
            }

            List<string> lines = ReadFile(filename);
            Console.WriteLine(lines.Count.ToString());
            List<long> hashlines = new List<long>();
            int counter = 0;
            foreach (var item in lines)
            {
                hashlines.Add(hash(item));
                Console.WriteLine(hashlines[counter].ToString());
                counter++;
            }

            //int tempas = GetStableHash(num);
            //var str = System.Text.Encoding.Default.GetString(temp); //atkeicia atgal is byte i string
            //Console.WriteLine(test.ToString());

        }
        static void Main(string[] args)
        {
            Program start = new Program();
            Console.WriteLine(args[0]);
            start.Hashuok(args[0]);
        }



    }


}
