using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialise a bank account
            BankAccount bankAccount = new BankAccount(0);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Banking System ---");
                Console.WriteLine("1. Deposit Money");
                Console.WriteLine("2. Withdraw Money");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option: ");

                String input = Console.ReadLine();

                switch (input)
                {
                    case "1": //Desposit money
                        Console.WriteLine("Enter amount to deposit: ");
                        if (double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            bankAccount.AddMoney(depositAmount);
                            Console.WriteLine("Deposit successfull.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "2": //Withdraw money
                        Console.Write("Enter amount to withdraw: ");
                        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            if (bankAccount.Subtract(withdrawAmount))
                            {
                                Console.WriteLine("Withdrawal successful.");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient balance.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "3": //Show balance
                        bankAccount.getInfo();
                        break;

                    case "4": //Exit
                        Console.WriteLine("Exiting the banking system. Goodbye!");
                        running = false;
                        break;

                    default: //Invalid option
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nDo you want to perform another task? (Y/N): ");
                    string continueResponse = Console.ReadLine().ToUpper();
                    if (continueResponse != "Y")
                    {
                        Console.WriteLine("Exiting the bank system. Goodbye!");
                        running = false;
                    }
                }
            }
        }
    }
}
