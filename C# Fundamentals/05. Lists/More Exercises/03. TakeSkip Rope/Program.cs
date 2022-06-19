using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._TakeSkip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            List<int> numberList = new List<int>();
            List<string> nonNumberList = new List<string>();
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (encryptedMessage[i] >= '0' && encryptedMessage[i] <= '9')
                {
                    numberList.Add(encryptedMessage[i] - '0');
                }
                else
                {
                    nonNumberList.Add(encryptedMessage[i].ToString());
                }
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            int position = 1;
            for (int i = 0; i < numberList.Count; i++)
            {
                if (position % 2 == 0)
                {
                    skipList.Add(numberList[i]);
                    position++;
                }
                else
                {
                    takeList.Add(numberList[i]);
                    position++;
                }
            }
            //
            StringBuilder result = new StringBuilder();
            int indexForSkip = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(nonNumberList);

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();

                result.Append(string.Join("", temp));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());


        }
    }
}
