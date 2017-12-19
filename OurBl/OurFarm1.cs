using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Ozeki.Media;
//using Ozeki.Camera;
//d xsda

namespace OurBl
{
    public class OurFarm1
    {

        private List<OurCamera1> cameraList;
        public string farmName { get; set; }
        public string details { get; set; }
        private int farmId;
        public string ownerName { get; set; }
        public string phoneNumber { get; set; }
        public double co1 { get; set; }//coordinate 1
        public double co2 { get; set; }//coordinate 2
        public bool AlarmMode { get; set; }//to prevent a situation of opening many windows for one problem

        public int FarmId
        {
            get
            {
                return farmId;
            }

            set
            {
                farmId = value;
            }
        }

        public OurFarm1()
        {
            cameraList = new List<OurCamera1>();
        }

        public IEnumerable<OurCamera1> GetAllTheCams() //running on the cameras of the Farm
        {
            return cameraList.AsEnumerable();
        }
    }
}
