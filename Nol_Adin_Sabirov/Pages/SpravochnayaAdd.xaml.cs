using Nol_Adin_Sabirov.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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
    /// Логика взаимодействия для SpravochnayaAdd.xaml
    /// </summary>
    public partial class SpravochnayaAdd : Window
    {
        Spravochnaya spr;
        bool checknew;
        public SpravochnayaAdd(Spravochnaya c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Spravochnaya();
                checknew = true;
            }
            else
                checknew = false;
            DataContext = spr = c;
            //spr = new Spravochnaya();
            //DataContext = spr;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            
            SpravochnayaAdd spradd = new SpravochnayaAdd(null);
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (checknew)
            {
                Conn.context.Spravochnaya.Add(spr);
                
            }
            try
            {
                Conn.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            //Conn.context.Spravochnaya.Add(spr);
            //Conn.context.SaveChanges();
        }

        public static bool CheckClient(Spravochnaya c)
        {
            throw new NotImplementedException();
        }
    }
}
