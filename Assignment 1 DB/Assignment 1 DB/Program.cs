﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment_1_DB
{
    class Program
    {
        private static readonly Dictionary<string, long> Hashmap = new Dictionary<string, long>();
        private const string FileName = "simple_db.txt";
        static void Main(string[] args)
        {
            ReCreateHashMapFromFile();

            AddToHashMapAndFile("Cake", "testCake");
            AddToHashMapAndFile("Fish", "testFish");
            AddToHashMapAndFile("Cat", "testCat");

            OutputToConsole();
        }

        static void OutputToConsole()
        {
            Console.WriteLine("Hashmap:");
            Hashmap.ToList().ForEach(h => Console.WriteLine("Key: " + h.Key + " Value: " + h.Value));

            Console.WriteLine("From file:");
            foreach (KeyValuePair<string, long> keyValuePair in Hashmap)
            {
                string fromFile = ReadFromFile(keyValuePair.Value);
                string[] fromFileSplit = fromFile.Split(new[] { "--|--" }, StringSplitOptions.None);
                Console.WriteLine("Key: " + fromFileSplit[0] + " Value: " + fromFileSplit[1]);
            }
        }

        #region set
        static void AddToHashMapAndFile(string key, string value)
        {
            long byteOffSet = WriteToFile(key, value);
            Hashmap[key] = byteOffSet;
        }
        static long WriteToFile(string key, string value)
        {
            long byteOffSet;

            using (FileStream fileStream = new FileStream(FileName, FileMode.Append))
            {
                byteOffSet = fileStream.Position;
                fileStream.Write(Encoding.ASCII.GetBytes(key + "--|--" + value + "\n"));
            }

            return byteOffSet;
        }
        #endregion

        static string ReadFromFile(long byteOffSet)
        {
            List<byte> bytes = new List<byte>();

            using (FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    fileStream.Position = byteOffSet;

                    while (binaryReader.PeekChar() != Encoding.ASCII.GetBytes("\n").First())
                    {
                        bytes.Add(binaryReader.ReadByte());
                    }
                }
            }

            string byteString = Encoding.ASCII.GetString(bytes.ToArray());

            return byteString;
        }

        static void ReCreateHashMapFromFile()
        {
            long currentPosition = 0;

            using (FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                while (currentPosition < fileStream.Length)
                {
                    string fromFile = ReadFromFile(currentPosition);

                    string[] fromFileSplit = fromFile.Split(new[] { "--|--" }, StringSplitOptions.None);

                    Hashmap[fromFileSplit[0]] = currentPosition;

                    currentPosition += fromFile.Length + 1;
                }
            }
        }
    }
}