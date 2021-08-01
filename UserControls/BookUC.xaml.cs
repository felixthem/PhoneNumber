using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Моя_телефонная_книга.Window_s;

namespace Моя_телефонная_книга.UserControls
{
    /// <summary>
    /// Логика взаимодействия для BookUC.xaml
    /// </summary>
    public partial class BookUC : UserControl
    {
        public string id, nameBook, nameOwner, dateCreate, iconOwner, mailOwner, password, areChecked;

        //Проверка на наличие пароля и по результату переход в записную книгу
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (password.Replace(" ", "") != "")
            {
                PasswordWindow passwordWindow = new PasswordWindow();

                if (passwordWindow.ShowDialog() == true)
                {
                    if (passwordWindow.Password == password)
                    {
                        MessageBox.Show("Авторизация пройдена");
                        MenuWindow menu = new MenuWindow(id);
                        menu.nameBook = nameBook;
                        menu.nameBookTB.Text = nameBook;
                        menu.nameOwner = nameOwner;
                        menu.nameOwnerTB.Text = nameOwner;
                        menu.dateCreate = dateCreate;
                        menu.iconOwner = iconOwner;
                        menu.FilePathBookAvatar = iconOwner;
                        try
                        {
                            menu.avatarBookImage.Source = new BitmapImage(new Uri(iconOwner));
                        }
                        catch
                        {
                            menu.avatarBookImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                        }
                        menu.mailOwner = mailOwner;
                        menu.password = password;
                        menu.areChecked = areChecked;
                        menu.UpdateContact("select * from Contact where idNotebook = " + id);
                        menu.Show();
                        Application.Current.MainWindow.Hide();
                    }
                    else
                        MessageBox.Show("Неверный пароль");
                }
                else
                {
                    MessageBox.Show("Авторизация не пройдена");
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы выбрали ту самую книгу?", "Проверка", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MenuWindow menu = new MenuWindow(id);
                        menu.id = id;
                        menu.nameBook = nameBook;
                        menu.nameBookTB.Text = nameBook;
                        menu.nameOwnerTB.Text = nameOwner;
                        menu.nameOwner = nameOwner;
                        menu.dateCreate = dateCreate;
                        menu.FilePathBookAvatar = iconOwner;
                        menu.avatarBookImage.Source = new BitmapImage(new Uri(iconOwner));
                        menu.iconOwner = iconOwner;
                        menu.mailOwner = mailOwner;
                        menu.password = password;
                        menu.areChecked = areChecked;
                        menu.UpdateContact("select * from Contact where idNotebook = " + id);
                        menu.Show();
                        Application.Current.MainWindow.Hide();
                        break;
                    case MessageBoxResult.No:

                        break;
                }
            }
        }

        public BookUC()
        {
            InitializeComponent();
        }
    }
}
