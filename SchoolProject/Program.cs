using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<double>> dic = new Dictionary<int, List<double>>();

            int counter = 0;
            StreamWriter sw = sw = new StreamWriter("information.txt");
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

                    Users user = new Users(UserId, dailyElectricity, nightEelctricyty, feePerHour);

                    if (!dic.ContainsKey(UserId))
                    {
                        dic.Add(UserId, new List<double>() { counter,dailyElectricity, nightEelctricyty, feePerHour,user.TransferElectricityFee() });
                    }
                    else
                    {
                        throw new ArgumentException("UserId is already here!");
                    }
                    Console.WriteLine("------------------------------------");

                   
                    sw.WriteLine("{0}. UserId: {1} ==> DailyElectricyty: {2}, NightElectricyty: {3} FeePerHour: {4}, TotalTransferMoney {5}lv.", counter,UserId,dailyElectricity,nightEelctricyty,feePerHour,user.TransferElectricityFee());
                    
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                }
                sw.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid enter data!");
            }

              foreach (var item in dic)
               {

                 Console.WriteLine("{0}. UserId: {1} ==> DailyElectricyty: {2}, NightElectricyty: {3} FeePerHour: {4} TotalTransferMoney {5}lv.",item.Value[0],item.Key,item.Value[1],item.Value[2],item.Value[3],item.Value[4]);
               }

            Console.WriteLine();
            Console.WriteLine("This is from file");

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
