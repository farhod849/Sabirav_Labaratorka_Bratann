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

using Nol_Adin_Sabirov.Pages;
using System.ComponentModel;

namespace Nol_Adin_Sabirov.Pages
{
    /// <summary>
    /// Логика взаимодействия для YchetnayaTable.xaml
    /// </summary>
    public partial class YchetnayaTable : Page
    {
        public YchetnayaTable()
        {
            InitializeComponent();
            YchTable.ItemsSource = Conn.context.Ychetnaya.ToList();

        }

       
        

        private void YchTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            YchetnayaAdd ychadd = new YchetnayaAdd(null);
            ychadd.ShowDialog();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var delYchetnaya = YchTable.SelectedItems.Cast<Ychetnaya>().ToList();


            if (MessageBox.Show($"Удалить {delYchetnaya.Count} записей?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Conn.context.Ychetnaya.RemoveRange(delYchetnaya);


            Conn.context.SaveChanges();
            YchTable.ItemsSource = Conn.context.Ychetnaya.ToList();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            YchTable.ItemsSource = Conn.context.Ychetnaya.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            YchTable.Items.SortDescriptions.Add(new SortDescription("PriceTicket", ListSortDirection.Descending));
            MessageBox.Show("Группировка по стоимости билета выполнена (От большего к меньшему)");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            YchTable.ItemsSource = Conn.context.Ychetnaya.Where(x => x.IdZapis.ToString().StartsWith(SearchBox.Text)).ToList();
        }
    }
}
