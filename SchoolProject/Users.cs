using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{
    public class Users
    {
        private int IdUser;
        private double dailyElectricity;
        private double nightElectricity;
        private double KwHourPrice;

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

        public double KWHourPrice
        {
            get { return KWHourPrice; }
            set { KWHourPrice = value; }
        }
        public Users(int IdUser, double dailyElectricity, double nightElectricity, double KwHourPrice)
        {
            this.IdUser = IdUser;
            this.dailyElectricity = dailyElectricity;
            this.nightElectricity = nightElectricity;
            this.KwHourPrice = KwHourPrice;
        }

        public double  TransferElectricityFee()
        {
            return KwHourPrice * 0.10;
        }
    }
}
