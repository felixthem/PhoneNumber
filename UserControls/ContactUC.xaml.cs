using System.Windows.Controls;

namespace Моя_телефонная_книга.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ContactUC.xaml
    /// </summary>
    public partial class ContactUC : UserControl
    {
        public string id, name, surname, patr, icon, number, mail, birthday, dateAdd, nameGroup, comment;

        //Передаются значения в MenuWindow
        private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            interm.db.GetFromContactUC(id, name, surname, patr, icon, number, mail, birthday, dateAdd, nameGroup, comment);
        }

        public ContactUC()
        {
            InitializeComponent();
        }
    }
}
