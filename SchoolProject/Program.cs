using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Dictionary<string,Dictionary<int,List<double>>> dic = new Dictionary<string,Dictionary<int,List<double>>>();

             Console.WriteLine("Enter how many do you want?");
             int countStreet=int.Parse(Console.ReadLine());

              Console.WriteLine();

            int counter = 0;


            using (StreamWriter sw  = new StreamWriter("information.txt"))
            {
                for (int i = 0; i < countStreet; i++)
                {

                    Console.WriteLine("Enter Street:");
                    string street = Console.ReadLine();

                    sw.WriteLine("StreetName is: {0}", street);
                    sw.WriteLine();

                    Console.WriteLine("UserId | Daily | Night | FeePerHour");

                    try
                    {
                        string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        while (command[0] != "End")
                        {
                            counter++;

                            int UserId = int.Parse(command[0]);
                            double dailyElectricity = double.Parse(command[1]);
                            double nightEelctricyty = double.Parse(command[2]);
                            double feePerHour = double.Parse(command[3]);

                            Users user = new Users(street,UserId, dailyElectricity, nightEelctricyty, feePerHour);

                            if (!dic.ContainsKey(street))
                            {
                                dic.Add(street, new Dictionary<int, List<double>>());
                            }
                            if (!dic[street].ContainsKey(UserId))
                            {
                                dic[user.Street].Add(UserId, new List<double>() {counter, user.DailyElectricity, user.NightElectricity, user.FeePrice, user.TransferElectricityFee() });
                            }
                            else
                            {
                                Console.WriteLine("User Id is already done");
                                return;
                            }

                            Console.WriteLine("------------------------------------");

                           
                            sw.WriteLine("{0}. UserId: {1} ==> DailyElectricyty: {2}, NightElectricyty: {3} FeePerHour: {4}, TotalTransferMoney {5}lv.", counter, user.IDUser, user.DailyElectricity, user.NightElectricity, user.FeePrice, user.TransferElectricityFee());

                            sw.WriteLine();

                            command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid enter data! Please try again!");
                    }
                }
            }

            ReadFromFile(); 
        }

        private static void ReadFromFile()
        {
            StreamReader sr = new StreamReader("information.txt");

            while (!sr.EndOfStream) 
            {
                Console.WriteLine(sr.ReadLine());
            }

            sr.Close();
        }
    }
}
