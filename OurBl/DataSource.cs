using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurBl
{
    public class DataSource
    {
        public static List<OurFarm1> FarmList = new List<OurFarm1>();
        public DataSource()
        {

            OurFarm1 f = new OurFarm1() { FarmId = 1111, farmName = "Acre", co1 = 32.921581, co2 = 35.086036, ownerName = "Yossi", phoneNumber = "054-8274673", AlarmMode = false };
            FarmList.Add(f);
            f = new OurFarm1() { FarmId = 2222, farmName = "Jerusalem", co1 = 31.764784, co2 = 35.191158, ownerName = "Ariel", phoneNumber = "052-8364782", AlarmMode = false };
            FarmList.Add(f);
            f = new OurFarm1() { FarmId = 3333, farmName = "Moreshet", co1 = 32.825284, co2 = 35.231064, ownerName = "Naftaly", phoneNumber = "052-9384627", AlarmMode = false };
            FarmList.Add(f);
            f = new OurFarm1() { FarmId = 4444, farmName = "Gedera", co1 = 31.806700, co2 = 35.231064, ownerName = "Moshe", phoneNumber = "052-7483796", AlarmMode = false };
            FarmList.Add(f);
            f = new OurFarm1() { FarmId = 5555, farmName = "Afula", co1 = 32.600345, co2 = 35.287977, ownerName = "Yaakov", phoneNumber = "053-14312456", AlarmMode = false };
            FarmList.Add(f);
            f = new OurFarm1() { FarmId = 6666, farmName = "Beer Sheva", co1 = 31.257915, co2 = 34.784930, ownerName = "Yosef", phoneNumber = "051-1324245", AlarmMode = false };
            FarmList.Add(f);
            f = new OurFarm1() { FarmId = 7777, farmName = "Kfar-Saba", co1 = 32.172368, co2 = 34.893293, ownerName = "Rivka", phoneNumber = "052-1456745", AlarmMode = false };
            FarmList.Add(f);
        }


        public IEnumerable<OurFarm1> GetAllTheFarms()
        {
            return FarmList.AsEnumerable();
        }
    }

}
