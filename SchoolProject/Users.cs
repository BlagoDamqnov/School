using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{
    public class Users
    {
        private string street;
        private int IdUser;
        private double dailyElectricity;
        private double nightElectricity;
        private double feePrice;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public int IDUser
        {
            get { return IdUser; }
            set { IdUser = value; }
        }

        public double DailyElectricity
        {
            get { return dailyElectricity; }
            set { dailyElectricity = value; }
        }

        public double NightElectricity
        {
            get { return nightElectricity; }
            set { nightElectricity = value; }
        }

        public double FeePrice
        {
            get { return feePrice; }
            set { feePrice = value; }
        }
        public Users(string street,int IdUser, double dailyElectricity, double nightElectricity, double feePrice)
        {
            this.street=street;
            this.IdUser = IdUser;
            this.dailyElectricity = dailyElectricity;
            this.nightElectricity = nightElectricity;
            this.feePrice = feePrice;
        }

        public double  TransferElectricityFee()
        {
            return Math.Round((DailyElectricity+NightElectricity) * 0.10,2);
        }
    }
}
