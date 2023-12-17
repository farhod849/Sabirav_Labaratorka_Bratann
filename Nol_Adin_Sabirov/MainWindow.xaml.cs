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
using Nol_Adin_Sabirov.Misc;
using Nol_Adin_Sabirov.Pages;

namespace Nol_Adin_Sabirov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Nav.MainFrame = MFrame;
            Nav.MainFrame.Navigate(new Main());
        }

        private void MFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
