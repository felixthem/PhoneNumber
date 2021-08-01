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
    /// Логика взаимодействия для GroupContactUC.xaml
    /// </summary>
    public partial class GroupContactUC : UserControl
    {
        int check = 0;
        public string id, name, surname, patr, icon, number, mail, birthday, dateAdd, nameGroup, comment;

        public GroupContactUC()
        {
            InitializeComponent();
        }

        public GroupContactUC(int i)
        {
            InitializeComponent();
            check = i;
            checkImage.Visibility = Visibility.Visible;
        }

        //Добавление контакта в список контактов для удлания из группы или удаление из списка при повторном нажатии
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (check == 0)
            {
                checkImage.Visibility = Visibility.Visible;
                interm.db.exportContact.Add(new Contact()
                {
                    id = id,
                    name = name,
                    surname = surname,
                    patr = patr,
                    icon = icon,
                    number = number,
                    mail = mail,
                    birthday = birthday,
                    dateAdd = dateAdd,
                    nameGroup = nameGroup,
                    comment = comment
                });
                check++;
            }
            else
            {
                checkImage.Visibility = Visibility.Hidden;
                for (int i = 0; i < interm.db.exportContact.Count; i++)
                {
                    if (interm.db.exportContact[i].id == id)
                    {
                        interm.db.exportContact.RemoveAt(i);
                    }
                }
                check = 0;
            }
        }
    }
}
