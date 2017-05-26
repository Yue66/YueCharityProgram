using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //var mycharityProgram = Foundation.CreateCharityProgram()
            //var charityProgram = new CharityProgram("David", 5000.00M);
            //charityProgram.Description="David has heart disease";
            //charityProgram.BankAccountNumber = 654321;

            ////charityProgram.ProcessDonation(500.00M);

            //var moneyneeded = charityProgram.MoneyStillNeeded();


            Console.WriteLine("*************Welcome **************");
            while (true)
            {
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.Create a charityProgram");
                Console.WriteLine("2.MoneyStillNeeded");
                Console.WriteLine("3.ProcessDonation");
                Console.WriteLine("4.Print all charityPrograms");
                Console.WriteLine("5.Print all donations");
                Console.WriteLine("Please select a choice from the above:");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting!");
                        return;

                    case "1":
                        Console.WriteLine("Name:");
                        var name = Console.ReadLine();
                        Console.WriteLine("MoneyGoal:");
                        var moneyGoal = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Please choose from the type of emergency level: ");
                        var emergencyLevels = Enum.GetNames(typeof(EmergencyLevels));

                        for (int i = 0; i < emergencyLevels.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{emergencyLevels[i]}");
                        }

                        var emergencyLevel = (EmergencyLevels)((Convert.ToInt32(Console.ReadLine()) - 1));
                        var charityProgram = Foundation.CreateCharityProgram(name, moneyGoal, emergencyLevel);
                        Console.WriteLine($"Id:{charityProgram.Id},Name: {charityProgram.Name },MoneyGoal:{charityProgram.MoneyGoal},EmergencyLevel:{charityProgram.EmergencyLevel}");
                        break;
                    case "2":
                        PrintAllCharityPrograms();
                        Console.Write("Pick an Id to see money still needed:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        decimal moneyStillNeeded = Foundation.MoneyStillNeeded(id);
                        Console.WriteLine($"money still needed:{moneyStillNeeded}" );
                        break;
                    case "3":
                        PrintAllCharityPrograms();
                        Console.Write("Pick an Id to donate:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Donation amount: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        decimal moneyAlreadGot = Foundation.ProcessDonation(id, amount);
                        Console.WriteLine($"Successful!!!  Money already got:{moneyAlreadGot}");
                        break;
                    case "4":
                        PrintAllCharityPrograms();
                        break;
                    case "5":
                        PrintAllCharityPrograms();
                        Console.Write("Pick an Id to see donate:");
                        id = Convert.ToInt32(Console.ReadLine());
                        var donations=Foundation.GetAllDonationsByCharityProgram(id);
                        foreach (var a in donations)
                        {
                            Console.WriteLine($"DonationId:{a.DonationId},Description:{a.Description},Amount:{a.Amount},DonationDate:{a.DonationDate}");
                        }
                        break;
                    default:
                        break;

                }
            }
        }

        private static void PrintAllCharityPrograms()
        {
            var charityPrograms = Foundation.GetallCharityPrograms();
            foreach (var a in charityPrograms)
            {
                Console.WriteLine($"Id:{a.Id},Name: {a.Name },MoneyGoal:{a.MoneyGoal},EmergencyLevel:{a.EmergencyLevel}");
            }
        }
    }
}