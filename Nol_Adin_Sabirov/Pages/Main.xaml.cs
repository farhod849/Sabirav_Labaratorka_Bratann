using Nol_Adin_Sabirov.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using Microsoft.Office.Interop.Excel;
using Page = System.Windows.Controls.Page;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;


namespace Nol_Adin_Sabirov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new SpravochnayaTable());
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new YchetnayaTable());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CustomMsgBox csmg = new CustomMsgBox();
            csmg.ShowDialog();
        }
    }
}
