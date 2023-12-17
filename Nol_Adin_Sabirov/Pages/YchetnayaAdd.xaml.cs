using Nol_Adin_Sabirov.Misc;
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

namespace Nol_Adin_Sabirov.Pages
{
    /// <summary>
    /// Логика взаимодействия для YchetnayaAdd.xaml
    /// </summary>
    public partial class YchetnayaAdd : Window
    {
        Ychetnaya ych;
        bool checknew;
        public YchetnayaAdd(Ychetnaya c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Ychetnaya();
                checknew = true;
            }
            else
                checknew = false;
            DataContext = ych = c;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            YchetnayaAdd ychadd = new YchetnayaAdd(null);
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (checknew)
            {
                Conn.context.Ychetnaya.Add(ych);
            }
            try
            {
                Conn.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
