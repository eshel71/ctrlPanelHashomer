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
using System.Windows.Shapes;
//using Ozeki.Media;
using OurBl;

namespace WPFTestApplication
{
    /// <summary>
    /// Interaction logic for AlertWindow.xaml
    /// </summary>
    public partial class AlertWindow : Window
    {
        OurFarm1 farm;

        public AlertWindow(OurFarm1 o)
        {
            InitializeComponent();
            //we want prevent a situation of closing the window by press 'x'

            farm = o;
            WarningLabel.Content += "  " + o.farmName;
            expander.Content =
                "Farm name: " + o.farmName + '\n' +
                "Owner phone : " + o.phoneNumber + '\n' +
                "Owner name : " + o.ownerName;

        }

        private void FineButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MyArgs args = new MyArgs();
            args.currentFarm = farm;
            AddPushpinToMap.ChangeToGreen(null, args);
        }
    }
}
