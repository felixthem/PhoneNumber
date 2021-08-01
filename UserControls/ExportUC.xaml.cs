using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Моя_телефонная_книга.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ExportUC.xaml
    /// </summary>
    public partial class ExportUC : UserControl
    {
        int check = 0;
        public string id, name, surname, patr, icon, number, mail, birthday, dateAdd, nameGroup, comment;

        public ExportUC()
        {
            InitializeComponent();
        }

        //public ExportUC(int i)
        //{
        //    InitializeComponent();
        //    check = i;
        //    checkImage.Visibility = Visibility.Visible;
        //    interm.db.exportContact.Add(new Contact()
        //    {
        //        id = id,
        //        name = name,
        //        surname = surname,
        //        patr = patr,
        //        icon = icon,
        //        number = number,
        //        mail = mail,
        //        birthday = birthday,
        //        dateAdd = dateAdd,
        //        nameGroup = nameGroup,
        //        comment = comment
        //    });
        //}

        //Добавление контакта в список контактов для экспорта или удаление из списка при повторном нажатии
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
                    if(interm.db.exportContact[i].id == id)
                    {
                        interm.db.exportContact.RemoveAt(i);
                    }
                }
                check = 0;
            }
        }
    }
}
