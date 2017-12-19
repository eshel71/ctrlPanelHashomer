using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
//using Ozeki; //downloading of ozeki dll is needed
//using Ozeki.Media;

using OurBl;

using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
namespace WPFTestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddPushpinToMap : Window
    {

        OurBl.DataSource db;
        LocationConverter locConverter = new LocationConverter();
        public static EventHandler<MyArgs> ChangeToGreen;

        public AddPushpinToMap()
        {
            InitializeComponent();
            db = new DataSource();
            ChangeToGreen += ChangingToGreen;
            Pushpin pin;
            myMap.Focus();
            foreach (var item in db.GetAllTheFarms())
            {
                OurFarm1 f5 = item as OurFarm1;
                Location pinLocation = new Location(item.co1, item.co2);
                pin = new Pushpin();
                pin.Location = pinLocation;
                pin.Background = Brushes.Green;
                myMap.Children.Add(pin);
            }

            /* foreach (var item in db.GetAllTheFarms())   // we got no time to work on that
             {
                 foreach (var i in item.GetAllTheCams())

                 {
                     i._motionDetector.MotionDetection += _motionDetector_MotionDetection;//adding the function to the delegate 
                 }
             }
             */

            var center = myMap.Center;
            var zoom = myMap.ZoomLevel;

            myMap.ViewChangeOnFrame += (s, e) =>
            {
                if (myMap.ZoomLevel != zoom)
                    myMap.ZoomLevel = zoom;

                if (!myMap.Center.Equals(center))
                    myMap.Center = center;
            };
        }

        #region Functions that will be neccesary when using the ozeki dll 
        /*
         private void _motionDetector_MotionDetection(object sender, MotionDetectionEvent e)//a function that will work by the motion detector// we check the if everything will work good by the function in the bottom of the page
         {
             if (e.Detection)
             {
                 MotionDetector o = sender as MotionDetector;
                 string FarmNAME1 = GetTheFarmByTheDet(o);
                 foreach (var item in db.GetAllTheFarms())
                 {
                     if (item.farmName == FarmNAME1)
                     {
                         OurFarm1 f2 = item;
                         if (f2.AlarmMode == true)//already handled
                             return;
                         f2.AlarmMode = true;
                         Location pinLocation = new Location(item.co1, item.co2);
                         foreach (var item3 in myMap.Children)//changine the matched pushpin to be color red
                         {
                             if (item3 is Pushpin)
                             {
                                 Pushpin o2 = item3 as Pushpin;
                                 if (o2.Location == pinLocation)
                                 {


                                     o2.Background = Brushes.Red;
                                     var temp = new AlertWindow(GetTheObjFarmByTheDet(o));
                                     temp.Show();
                                 }
                             }
                         }
                     }
                 }
             }

         }

         private string GetTheFarmByTheDet(MotionDetector o)
         {

             foreach (var item in db.GetAllTheFarms())
             {
                 foreach (var i in item.GetAllTheCams())

                 {
                     if (i._motionDetector == o)
                     {
                         return i.farmName;


                     }
                 }
             }
             return "";
         }

         private OurFarm1 GetTheObjFarmByTheDet(MotionDetector o)
         {

             foreach (var item in db.GetAllTheFarms())
             {
                 foreach (var i in item.GetAllTheCams())

                 {
                     if (i._motionDetector == o)
                     {
                         string temp = i.farmName;
                         foreach (var v1 in db.GetAllTheFarms())
                         {
                             if (v1.farmName == temp)
                                 return v1;

                         }

                     }
                 }
             }
             return null;
         }
       */
        #endregion

        private Pushpin GetThePin(OurFarm1 f)
        {
            Location pinLocation = new Location(f.co1, f.co2);
            foreach (var item3 in myMap.Children)
                if (item3 is Pushpin)
                {
                    Pushpin o2 = item3 as Pushpin;
                    if (o2.Location == pinLocation)
                        return o2;

                }

            return null;
        }

        public void ChangingToGreen(object sender, MyArgs e)
        {
            OurFarm1 Temp = new OurFarm1();
            Temp = e.currentFarm;
            Temp.AlarmMode = false;
            Location pinLocation = new Location(Temp.co1, Temp.co2);
            foreach (var item3 in myMap.Children)
            {
                if (item3 is Pushpin)
                {
                    Pushpin o2 = item3 as Pushpin;
                    if (o2.Location == pinLocation)
                        o2.Background = Brushes.Green;
                }
            }
        }

        //thus we can know if our code is working (by the func' "myMap_MouseDoubleClick")
        private void myMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)//function for demonstration only!
        {
            Random r = new Random();
            OurFarm1 myRandomFarm = db.GetAllTheFarms().ElementAt(r.Next(0, 5));//demonstration only

            if (myRandomFarm.AlarmMode == true)
                return;
            myRandomFarm.AlarmMode = true;

            Location pinLocation = new Location(myRandomFarm.co1, myRandomFarm.co2);
            foreach (var item3 in myMap.Children)
            {
                if (item3 is Pushpin)
                {
                    Pushpin o2 = item3 as Pushpin;
                    if (o2.Location == pinLocation)
                    {
                        o2.Background = Brushes.Red;
                        AlertWindow newAlert = new AlertWindow(myRandomFarm);
                        newAlert.Show();
                    }
                }
            }

        }

    }

}
