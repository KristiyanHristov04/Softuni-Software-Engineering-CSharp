using System;
using System.Collections.Generic;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();
            string[] input = Console.ReadLine().Split(',');

            for (int i = 0; i < input.Length; i++)
            {
                string[] currentbankAccount = input[i].Split('-');
                int id = Convert.ToInt32(currentbankAccount[0]);
                double balance = Convert.ToDouble(currentbankAccount[1]);
                bankAccounts.Add(id, balance);
            }

            while (true)
            {
                string secondInput = Console.ReadLine();
                if (secondInput == "End")
                {
                    break;
                }

                try
                {
                    string[] tokens = secondInput.Split(' ');
                    string mainCommand = tokens[0];
                    int accountNumber = Convert.ToInt32(tokens[1]);
                    double accountBalance = Convert.ToDouble(tokens[2]);

                    switch (mainCommand)
                    {
                        case "Deposit":
                            if (!bankAccounts.ContainsKey(accountNumber))
                            {
                                throw new InvalidOperationException("Invalid account!");
                            }

                            bankAccounts[accountNumber] += accountBalance;
                            Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
                            break;
                        case "Withdraw":
                            if (!bankAccounts.ContainsKey(accountNumber))
                            {
                                throw new InvalidOperationException("Invalid account!");
                            }

                            if (bankAccounts[accountNumber] - accountBalance < 0)
                            {
                                throw new InvalidOperationException("Insufficient balance!");
                            }

                            bankAccounts[accountNumber] -= accountBalance;
                            Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
