using System.Text;

namespace SimpleBankSystem
{
    internal class Program
    {
        private static List<AccountInfo> mockData = new List<AccountInfo>
        {
            new AccountInfo
            {
                Name = "A",
                AccountNumber = "666-9-14153-1",
                Balance = 1000.00m
            },
            new AccountInfo
            {
                Name = "B",
                AccountNumber = "867-7-01317-4",
                Balance = 2000.00m
            },
            new AccountInfo
            {
                Name = "C",
                AccountNumber = "968-0-16794-2",
                Balance = 3000.00m
            },
            new AccountInfo
            {
                Name = "D",
                AccountNumber = "981-4-12265-9",
                Balance = 4000.00m
            },
            new AccountInfo
            {
                Name = "E",
                AccountNumber = "945-1-01709-3",
                Balance = 5000.00m
            },
            new AccountInfo
            {
                Name = "F",
                AccountNumber = "907-9-83706-1",
                Balance = 6000.00m
            },
            new AccountInfo
            {
                Name = "G",
                AccountNumber = "862-0-57067-3",
                Balance = 7000.00m
            },
            new AccountInfo
            {
                Name = "H",
                AccountNumber = "572-9-09243-4",
                Balance = 8000.00m
            },
            new AccountInfo
            {
                Name = "I",
                AccountNumber = "380-0-17781-7",
                Balance = 9000.00m
            },
            new AccountInfo
            {
                Name = "J",
                AccountNumber = "019-5-18145-9",
                Balance = 10000.00m
            }
        };

        static bool isRunning = true;
        static void Main(string[] args)
        {
            var accountInfo = GetUserAccount();
            Console.WriteLine($"Welcome {accountInfo.Name}");

            while (isRunning)
            {
                var option = GetOption();

                switch (option)
                {
                    case "1":
                        DisplayAccountInfo(accountInfo);
                        break;
                    case "2":
                        Diposit(accountInfo);
                        break;
                    case "3":
                        Withdraw(accountInfo);
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Thank you for using bank console app.");
                        break;
                }
            }
        }

        private static AccountInfo GetUserAccount()
        {
            AccountInfo user = new AccountInfo();

            while (true)
            {
                Console.Write("Enter your account number : ");
                string accountNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(accountNumber))
                {
                    Console.WriteLine("Account number cannot be empty. Please try again.");
                    continue;
                }

                user = mockData.FirstOrDefault(a => a.AccountNumber == FormatAccountNumber(accountNumber));
                if (user == null)
                {
                    Console.WriteLine("Account not found. Please try again.");
                    continue;
                }
                else
                {
                    Console.Clear();
                    return user;
                }
            }
        }

        private static string GetOption()
        {
            while (true)
            {
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Exit");
                Console.Write("Select option : ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                if (int.TryParse(input, out int option))
                {
                    if (option < 1 || option > 4)
                    {
                        Console.WriteLine("Invalid option.");
                        continue;
                    }
                    else
                    {
                        return input;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
            }
        }

        public static void DisplayAccountInfo(AccountInfo info)
        {
            Console.Clear();
            Console.WriteLine("Account Information:");
            Console.WriteLine($"Name: {info.Name}");
            Console.WriteLine($"Account Number: {info.AccountNumber}");
            Console.WriteLine($"Balance: {info.Balance:C}");
        }

        public static void Diposit(AccountInfo info)
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter amount to deposit : ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Amount cannot be empty. Please try again.");
                    continue;
                }

                if (decimal.TryParse(input, out decimal amount) && amount > 0)
                {
                    info.Balance += amount;
                    Console.WriteLine($"Successfully deposited {amount:C}. New balance is {info.Balance:C}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number greater than zero.");
                    continue;
                }

            }
        }

        public static void Withdraw(AccountInfo info)
        {
            Console.Clear();
            while (true)
            {
                Console.Write("Enter amount to withdraw : ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Amount cannot be empty. Please try again.");
                    continue;
                }

                if (decimal.TryParse(input, out decimal amount) && amount > 0)
                {
                    if (amount > info.Balance)
                    {
                        Console.WriteLine("Insufficient balance. Please enter a valid amount.");
                        continue;
                    }

                    info.Balance -= amount;
                    Console.WriteLine($"Successfully withdraw {amount:C}. New balance is {info.Balance:C}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number greater than zero.");
                    continue;
                }

            }
        }

        private static string FormatAccountNumber(string rawNumber)
        {
            return rawNumber.Insert(3, "-").Insert(5, "-").Insert(11, "-");
        }
    }
}
