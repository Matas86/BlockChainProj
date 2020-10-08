using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BlockChainProject;

namespace BlockChainProject
{
    public class Program
    {
        Operations op = new Operations();
        //reads one file of one word in each line
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
        //reads one file with two words in each line
        public List<string> ReadFileToWords(string file)
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
                        string temp = sr.ReadLine();
                        string[] mas = temp.Split(' ');
                        text.Add(mas[0]);
                        text.Add(mas[1]);

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

        public void Hashuok(string file)
        {

            Console.WriteLine("Ar nori lyginti 100 000 zodziu poras, ar hashuoti viena faila kiekviena eilute?");
            Console.WriteLine("Jei norite lyginti zodziu poras vienam faile, pasirinkite 1.");
            Console.WriteLine("Jei norite hashuoti kiekviena failo eilute, pasirinkite 2.");
            string choice;
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Pradedamas vieno failo hashavimas.");
                List<string> lines = ReadFileToWords(file);
                List<string> hashedlines = new List<string>();
                List<string> binarylines = new List<string>();


                //MD5 hash
                var watch = System.Diagnostics.Stopwatch.StartNew();
                foreach (var item in lines)
                {
                    hashedlines.Add(op.TextToMD5(item));
                }
                var elapsedMsMD = watch.ElapsedMilliseconds;

                //checking similarities of MD5 in hex
                List<double> similarities = new List<double>();

                int countMD = 0;
                for (int i = 0; i < hashedlines.Count - 2; i += 2)
                {
                    similarities.Add(op.CheckSimilarity(hashedlines[i], hashedlines[i + 1]));
                    countMD++;

                }
                double sumMD = 0;
                double minMD = 100;
                double maxMD = 0;
                for (int i = 0; i < similarities.Count; i++)
                {
                    sumMD += similarities[i];
                    if (minMD > similarities[i]) minMD = similarities[i];
                    if (maxMD < similarities[i]) maxMD = similarities[i];
                }


                //starting to hash
                hashedlines.Clear();
                watch = System.Diagnostics.Stopwatch.StartNew();
                foreach (var item in lines)
                {
                    List<string> templines = op.Split(item);
                    string temp = op.Hash(templines);
                    binarylines.Add(temp);
                    hashedlines.Add(op.BinaryStringToHexString(temp));
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                //hashing ended


                //checking similiarities
                similarities.Clear();
                int count = 0;
                for (int i = 0; i < hashedlines.Count - 2; i += 2)
                {
                    similarities.Add(op.CheckSimilarity(hashedlines[i], hashedlines[i + 1]));
                    count++;

                }
                double sum = 0;
                double min = 100;
                double max = 0;
                for (int i = 0; i < similarities.Count; i++)
                {
                    sum += similarities[i];
                    if (min > similarities[i]) min = similarities[i];
                    if (max < similarities[i]) max = similarities[i];
                }

                //starting to check similarties in binary
                similarities.Clear();
                int countbi = 0;
                for (int i = 0; i < binarylines.Count - 2; i += 2)
                {

                    similarities.Add(op.CheckSimilarityBi(binarylines[i], binarylines[i + 1]));
                    countbi++;

                }

                double sumbi = 0;
                double minbi = 100;
                double maxbi = 0;
                for (int i = 0; i < similarities.Count; i++)
                {
                    sumbi += similarities[i];
                    if (minbi > similarities[i]) minbi = similarities[i];
                    if (maxbi < similarities[i]) maxbi = similarities[i];
                }

                //output results
                Console.WriteLine("Naudojamas failas: " + file);
                Console.WriteLine("");
                Console.WriteLine("Hashavimas mano algoritmu");
                Console.WriteLine("Maziausias skirtumas hex lygmeny: " + (100 - Math.Round(max, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas hex lygmeny: " + (100 - Math.Round(min, 2)) + "%");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi hex lygmeny: " + (100 - Math.Round(sum / count, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("Maziausias skirtumas binary lygmeny: " + (100 - Math.Round(maxbi, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas binary lygmeny: " + (100 - Math.Round(minbi, 2)) + "%");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi binary lygmeny: " + (100 - Math.Round(sumbi / countbi, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Hashavimas uztruko: " + elapsedMs + " milisekundziu");

                //Hashavimas MD5 algoritmu
                Console.WriteLine("");
                Console.WriteLine("Hashavimas MD5 algoritmu");
                Console.WriteLine("Maziausias skirtumas hex lygmeny: " + (100 - Math.Round(maxMD, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas hex lygmeny: " + (100 - Math.Round(minMD, 2)) + "%");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi hex lygmeny: " + (100 - Math.Round(sumMD / countMD, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("Hashavimas uztruko: " + elapsedMsMD + " milisekundziu");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Pradedamas vieno failo hashavimas.");
                List<string> lines = ReadFile(file);
                List<string> hashedlines = new List<string>();
                List<string> binarylines = new List<string>();
                var watch = System.Diagnostics.Stopwatch.StartNew();
                //starting to hash
                foreach (var item in lines)
                {
                    List<string> templines = op.Split(item);
                    string temp = op.Hash(templines);
                    binarylines.Add(temp);
                    hashedlines.Add(op.BinaryStringToHexString(temp));
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                //starting to check similarities in hex
                List<double> similarities = new List<double>();
                int count = 0;
                for (int i = 0; i < hashedlines.Count - 1; i++)
                {
                    for (int j = i + 1; j < hashedlines.Count; j++)
                    {
                        similarities.Add(op.CheckSimilarity(hashedlines[i], hashedlines[j]));
                        count++;
                    }
                }
                double sum = 0;
                double min = 100;
                double max = 0;
                for (int i = 0; i < similarities.Count; i++)
                {
                    sum += similarities[i];
                    if (min > similarities[i]) min = similarities[i];
                    if (max < similarities[i]) max = similarities[i];
                }

                //starting to check similarties in binary
                similarities.Clear();
                int countbi = 0;
                for (int i = 0; i < binarylines.Count - 1; i++)
                {
                    for (int j = i + 1; j < binarylines.Count; j++)
                    {
                        similarities.Add(op.CheckSimilarityBi(binarylines[i], binarylines[j]));
                        countbi++;
                    }
                }

                double sumbi = 0;
                double minbi = 100;
                double maxbi = 0;
                for (int i = 0; i < similarities.Count; i++)
                {
                    sumbi += similarities[i];
                    if (minbi > similarities[i]) minbi = similarities[i];
                    if (maxbi < similarities[i]) maxbi = similarities[i];
                }

                //output results
                Console.WriteLine("Naudojamas failas: " + file);
                Console.WriteLine("");
                Console.WriteLine("Maziausias skirtumas hex lygmeny: " + (100 - Math.Round(max, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas hex lygmeny: " + (100 - Math.Round(min, 2)) + "%");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi hex lygmeny: " + (100 - Math.Round(sum / count, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("Maziausias skirtumas binary lygmeny: " + (100 - Math.Round(maxbi, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas binary lygmeny: " + (100 - Math.Round(minbi, 2)) + "%");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi binary lygmeny: " + (100 - Math.Round(sumbi / countbi, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Hashavimas uztruko: " + elapsedMs + " milisekundziu");
            }



        }

        public void Hashuok(string one, string two)
        {
            Console.WriteLine("Pradedamas dvieju failu hashavimas.");

            List<string> lines1 = ReadFile(one);
            List<string> lines2 = ReadFile(two);
            List<string> hashedlines1 = new List<string>();
            List<string> hashedlines2 = new List<string>();
            List<string> binarylines1 = new List<string>();
            List<string> binarylines2 = new List<string>();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //starting to hash
            foreach (var item in lines1)
            {
                List<string> templines = op.Split(item);
                string temp = op.Hash(templines);
                binarylines1.Add(temp);
                hashedlines1.Add(op.BinaryStringToHexString(temp));
            }

            foreach (var item in lines2)
            {
                List<string> templines = op.Split(item);
                string temp = op.Hash(templines);
                binarylines2.Add(temp);
                hashedlines2.Add(op.BinaryStringToHexString(temp));
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            //checking similarities
            List<double> similarities = new List<double>();
            int count = 0;
            for (int i = 0; i < hashedlines1.Count - 1; i++)
            {

                similarities.Add(op.CheckSimilarity(hashedlines1[i], hashedlines2[i]));
                count++;

            }

            double sum = 0;
            double min = 100;
            double max = 0;
            for (int i = 0; i < similarities.Count; i++)
            {
                sum += similarities[i];
                if (min > similarities[i]) min = similarities[i];
                if (max < similarities[i]) max = similarities[i];
            }

            //starting to check similarties in binary
            similarities.Clear();
            int countbi = 0;
            for (int i = 0; i < binarylines1.Count - 1; i++)
            {

                similarities.Add(op.CheckSimilarityBi(binarylines1[i], binarylines2[i]));
                countbi++;

            }

            double sumbi = 0;
            double minbi = 100;
            double maxbi = 0;
            for (int i = 0; i < similarities.Count; i++)
            {
                sumbi += similarities[i];
                if (minbi > similarities[i]) minbi = similarities[i];
                if (maxbi < similarities[i]) maxbi = similarities[i];
            }

            //output result
            Console.WriteLine("Naudojamas failas pirmas: " + one);
            Console.WriteLine("Naudojamas failas antras: " + two);

            if (sum == 0 && sumbi == 0)
            {
                Console.WriteLine("Hashai yra visiskai skirtingi hex ir binary lygmenyje.");
                Console.WriteLine("");
                Console.WriteLine("Hashavimas uztruko: " + elapsedMs + " milisekundziu");
            }
            else if(sum == 0)
            {
                Console.WriteLine("Hashai yra visiskai skirtingi hex lygmenyje.");
                Console.WriteLine("");
                Console.WriteLine("Maziausias skirtumas binary lygmeny: " + (100 - Math.Round(maxbi, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas binary lygmeny: " + (100 - Math.Round(minbi, 2)) + "%");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi binary lygmeny: " + (100 - Math.Round(sumbi / countbi, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("Hashavimas uztruko: " + elapsedMs + " milisekundziu");
            }
            else if(sumbi == 0)
            {
                Console.WriteLine("Hashai yra visiskai skirtingi binary lygmenyje.");
                Console.WriteLine("");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi hex lygmenyje: " + (100 - Math.Round(sum / count, 2)) + "%");
                Console.WriteLine("Maziausias skirtumas hex lygmenyje: " + (100 - Math.Round(max, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas hex lygmenyje: " + (100 - Math.Round(min, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("Hashavimas uztruko: " + elapsedMs + " milisekundziu");
            }
            else
            {
                Console.WriteLine("Vidutiniskai hashai yra skirtingi: " + (100 - Math.Round(sum / count, 2)) + "%");
                Console.WriteLine("Maziausias skirtumas: " + (100 - Math.Round(max, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas: " + (100 - Math.Round(min, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("Maziausias skirtumas binary lygmeny: " + (100 - Math.Round(maxbi, 2)) + "%");
                Console.WriteLine("Didziausias skirtumas binary lygmeny: " + (100 - Math.Round(minbi, 2)) + "%");
                Console.WriteLine("Vidutiniskai hashai yra skirtingi binary lygmeny: " + (100 - Math.Round(sumbi / countbi, 2)) + "%");
                Console.WriteLine("");
                Console.WriteLine("Hashavimas uztruko: " + elapsedMs + " milisekundziu");
            }


        }
        static void Main(string[] args)
        {

            Program start = new Program();
            if (args.Length == 1)
            {
                start.Hashuok(args[0]);
            }
            else if (args.Length == 2)
            {
                start.Hashuok(args[0], args[1]);
            }
            else
            {
                string choice = "";
                Console.WriteLine("Ar norite hashuoti viena faila ar du?");
                Console.WriteLine("Iveskite 1, jei norite hashuoti viena faila.");
                Console.WriteLine("Iveskite 2, jei norite hashuoti du failus.");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    string filename = "";
                    Console.WriteLine("Iveskite failo pavadinima");
                    filename = Console.ReadLine();
                    start.Hashuok(filename);
                }
                else
                {
                    Console.WriteLine("Iveskite dvieju failu pavadinimus.");
                    Console.WriteLine("1. ");
                    string filename = Console.ReadLine();
                    Console.WriteLine("2. ");
                    string filename2 = Console.ReadLine();
                    start.Hashuok(filename, filename2);
                }
            }


        }



    }


}
