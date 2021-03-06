﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Project1;
using DataStructures_Algorithms.Project2;

namespace Runner
{
    class Project02_Task01 : IRunner
    {
        public Project02_Task01()
        {
        }

        public void Run(string[] args)
        {
            string inputFileName = "../../Data/Project02/" + args[0];
            string encodedFileName = "../../Data/Project02/" + args[1];
            string decodedFileName = "../../Data/Project02/" + args[2];
            string OriginalFile = "../../Data/Project02/" + inputFileName + "'s-" + "FinalOutput" + System.IO.Path.GetExtension(inputFileName);

            // load input data
            Vector<char> inputData = null;
            DataSerializer<char>.LoadVectorFromAnyFile(inputFileName, ref inputData);

            // create a coder
            HuffmanCoding coder = new HuffmanCoding();

            // encode input data
            Vector<string> encodedData = null;
            encodedData = coder.Encode(inputData);

            // write the encoded data to file
            DataSerializer<string>.SaveVectorToTextFile(encodedFileName, encodedData);

            // reload the encoded data from file
            DataSerializer<string>.LoadVectorFromTextFile(encodedFileName, ref encodedData);
            
            // decode the encoded data
            Vector<char> decodedData = null;
            decodedData = coder.Decode(encodedData);

            // write the decoded data to file
            DataSerializer<char>.SaveFinalOutput(decodedFileName, decodedData);

            // Convert Decoded data to original file
            DataSerializer<char>.GetOriginalFile(OriginalFile, decodedData);

            // reload the decodedData from file
            DataSerializer<char>.LoadVectorFromAnyFile(decodedFileName, ref decodedData);

            // validating the coding result, i.e. checking whether inputData = decodedData
            if (inputData.Count != decodedData.Count)
                Console.WriteLine("Input data is not identical to decoded data -- Coding method does not work accurately!");
            else
            {
                int i;
                for (i = 0; i < inputData.Count; i++)
                {
                    if (!inputData[i].Equals(decodedData[i]))
                    {
                        Console.WriteLine("Input data is not identical to decoded data -- Coding method does not work accurately!");
                        break;
                    }
                }
                if (i == inputData.Count)
                    Console.WriteLine("Coding method works accurately!");
            }

            Console.Read();
        }
    }
}