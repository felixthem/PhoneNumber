using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Моя_телефонная_книга.UserControls
{
    /// <summary>
    /// Логика взаимодействия для GroupUC.xaml
    /// </summary>
    public partial class GroupUC : UserControl
    {
        public GroupUC()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Хотите внести изменения в выбранную группу?", "Проверка", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    interm.db.GetFromGroupUC(nameGroupTB.Text);
                    break;
                case MessageBoxResult.No:
                    interm.db.GetFromGroupUC("doorpe45");
                    break;
            }
        }
    }
}
