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

namespace Моя_телефонная_книга.UserControls
{
    /// <summary>
    /// Логика взаимодействия для AllLogUC.xaml
    /// </summary>
    public partial class AllLogUC : UserControl
    {
        public AllLogUC()
        {
            InitializeComponent();
        }

        public string idContact;

        //
        private void fioCall_MouseEnter(object sender, MouseEventArgs e)
        {
            fioBluerGrid.Visibility = Visibility.Visible;
        }

        private void fioCall_MouseLeave(object sender, MouseEventArgs e)
        {
            fioBluerGrid.Visibility = Visibility.Hidden;
        }

        private void fioCall_MouseDown(object sender, MouseButtonEventArgs e)
        {
            interm.db.OutFromAllLogUc(idContact);
        }
    }
}
