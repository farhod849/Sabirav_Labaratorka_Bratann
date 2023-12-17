using Nol_Adin_Sabirov.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nol_Adin_Sabirov.Pages
{
    /// <summary>
    /// Логика взаимодействия для SpravochnayaTable.xaml
    /// </summary>
    public partial class SpravochnayaTable : Page
    {
        public SpravochnayaTable()
        {
            InitializeComponent();
            SprTable.ItemsSource = Conn.context.Spravochnaya.ToList();
        }

        private void SprTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SpravochnayaAdd spradd = new SpravochnayaAdd(null);
            spradd.ShowDialog();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var delYche = SprTable.SelectedItems.Cast<Spravochnaya>().ToList();
            foreach (var delYch in delYche)
                if (Conn.context.Ychetnaya.Any(x => x.IdReysa == delYch.IdReys))
                {
                    MessageBox.Show("Данные используются в справочной таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить{delYche.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) ;
            //Conn.context.Ychetnaya.RemoveRange(delYche);
            try
            {
                Conn.context.SaveChanges();
                SprTable.ItemsSource = Conn.context.Ychetnaya.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {           
            SprTable.ItemsSource = Conn.context.Spravochnaya.ToList();
        }
    

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SprTable.ItemsSource = Conn.context.Spravochnaya.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SprTable.ItemsSource = Conn.context.Spravochnaya.Where(x => x.NameReys.StartsWith(SearchBox.Text)).ToList();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {

           
            SprTable.Items.SortDescriptions.Add(new SortDescription("KolVoSeat", ListSortDirection.Descending));
            MessageBox.Show("Группировка по количеству мест выполнена (От большего к меньшему)");
        }
        public static bool CheckSpravochanya(Spravochnaya c)
        {
            if (string.IsNullOrEmpty(c.NameReys) || c.NameReys.Length < 10)
            
                return false;
            return true;
            
        }
    }
}
