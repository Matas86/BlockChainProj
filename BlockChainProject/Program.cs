﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainProject
{
    public class Program
    {
        const int MUST_BE_LESS_THAN = 100000000;

        long hash(string str)
        {
            long hash = 5381;
            //int c;

            foreach (var item in str)
            {
                hash = ((hash << 5) + hash) + item;
                hash += (hash << 3);
                hash ^= (hash >> 11);
                hash += (hash << 15);
            }


            return (hash/MUST_BE_LESS_THAN);
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

        public int CheckCollision(List<long> hashlines)
        {
            int counter = 0;

            for (int i = 0; i < hashlines.Count; i++)
            {
                for (int j = i; j < hashlines.Count; j++)
                {
                    if (hashlines[i] == hashlines[j])
                    {
                        counter++;
                    }
                }
            }
            return counter - hashlines.Count;
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
            List<long> hashlines = new List<long>();
            foreach (var item in lines)
            {
                if (hash(item) < 0)
                {
                    hashlines.Add(Math.Abs(hash(item)));
                }
                else
                {
                    hashlines.Add(hash(item));
                }
                
            }
            int collisioncount = CheckCollision(hashlines);
            Console.WriteLine("Collision = " + collisioncount.ToString());

        }
        static void Main(string[] args)
        {
            Program start = new Program();
            Console.WriteLine("Naudojamas failas : " + args[0]);
            start.Hashuok(args[0]);
        }



    }


}
