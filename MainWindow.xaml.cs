using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Моя_телефонная_книга.UserControls;

namespace Моя_телефонная_книга
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FilePathAvatar { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            UpdateNoteBooks();
            FilePathAvatar = @"C:\Users\Жмых\source\repos\Моя телефонная книга\Picture\avatar.png";
            //FilePathAvatar = @"C:\Users\Жмых\source\repos\Моя телефонная книга\Picture\avatar.png";
            //FilePathAvatar = @"C:\Users\Жмых\source\repos\Моя телефонная книга\Picture\avatar.png";
            //nameBookTextBox.MaxLength = 30;
            //ownerBookTextBox.MaxLength = 30;
            //mailBookTextBox.MaxLength = 43;
            //passwordBookPB.MaxLength = 20;
        }

        //Работа кнопок правой верхней панели
        private void closeGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            closeGrid.Background = Brushes.Red;
            //closeImage.Opacity = 1;
        }

        private void closeGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            closeGrid.Background = null;
            closeImage.Opacity = 0.5;
        }

        private void closeGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void hideGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            hideGrid.Background = Brushes.White;
            hideImage.Opacity = 1;
        }

        private void hideGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            hideGrid.Background = null;
            hideImage.Opacity = 0.5;
        }

        private void hideGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Визуал кнопок вызова формы добавления новой книги
        private void addBookTextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            adGrid.Background = Brushes.White;
        }

        private void addBook2TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            adGrid.Background = null;
        }

        //Переход на Grid добавления новой книги
        private void addBookTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            addBookGrid.Visibility = Visibility.Visible;
        }

        //Визуал выбора новой автарки для записной книги
        private void photoElipse_MouseEnter(object sender, MouseEventArgs e)
        {
            changePhotoGrid.Visibility = Visibility.Visible;
            changePhotoClickGrid.Visibility = Visibility.Visible;
        }

        private void photoElipse_MouseLeave(object sender, MouseEventArgs e)
        {
            changePhotoGrid.Visibility = Visibility.Hidden;
            changePhotoClickGrid.Visibility = Visibility.Hidden;
        }

        //Выбор новой аватарки записной книги
        private void avatarImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathAvatar = openFileDialog.FileName;
                try
                {
                    avatarImage.Source = new BitmapImage(new Uri(FilePathAvatar));
                }
                catch
                {
                    MessageBox.Show("Выбран неверный формат файла.");
                    avatarImage.Source = new BitmapImage(new Uri("Picture/avatar.png", UriKind.Relative));
                    FilePathAvatar = @"C:\Users\Жмых\source\repos\Моя телефонная книга\Picture\avatar.png";
                }
            }
        }

        //Визуал кнопки возврата на первый Grid
        private void backImage_MouseEnter(object sender, MouseEventArgs e)
        {
            backImage.Opacity = 1;
        }

        private void backImage_MouseLeave(object sender, MouseEventArgs e)
        {
            backImage.Opacity = 0.7;
        }

        //Убирается форма добавления книги и обновляется список книг на первом Grid
        private void backImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            addBookGrid.Visibility = Visibility.Hidden;
            UpdateNoteBooks();
        }

        //Убирает красную линию при нажатии на TextBox
        private void nameBookTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            nameBookRedLine.Visibility = Visibility.Hidden;
        }

        //Убирает красную линию при нажатии на TextBox, но TextBox уже другой
        private void ownerBookTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ownerBookRedLine.Visibility = Visibility.Hidden;
        }

        //Убирает красную линию при нажатии на TextBox, да и в третий раз напишу
        private void mailBookTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            mailBookRedLine.Visibility = Visibility.Hidden;
        }

        //----------------------------------------------------------------------------//
        //----------------------   Часть работы с БД  --------------------------------//
        //----------------------------------------------------------------------------//

        //Вывод в ListBox всех имеющихся записных книг
        private void UpdateNoteBooks()
        {
            bookListBox.Items.Clear();
            List<Notebooks> note = new List<Notebooks>();
            note = interm.db.GetNotebook("select * from Notebook;");
            foreach (Notebooks Note in note)
            {
                BookUC bk = new BookUC();
                bk.id = Note.id;
                bk.nameBookTB.Text = Note.nameBook;
                bk.nameBook = Note.nameBook;
                bk.nameOwnerTB.Text = Note.nameOwner;
                bk.nameOwner = Note.nameOwner;
                bk.dateCreate = Note.dateCreate;
                bk.mailOwner = Note.mailOwner;
                bk.password = Note.password;
                bk.iconOwner = Note.iconOwner;
                bk.areChecked = Note.areCheked;
                try
                {
                    bk.avatarImage.Source = new BitmapImage(new Uri(Note.iconOwner));
                }
                catch
                {
                   bk.avatarImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                }
                bookListBox.Items.Add(bk);
            }
        }

        //Добавление новой записной книги
        private void acceptAddBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameBookTextBox.Text.Replace(" ", "") != "" & ownerBookTextBox.Text.Replace(" ", "") != "" & mailBookTextBox.Text.Replace(" ", "") != "" & (mailBookTextBox.Text.Contains(".com") | mailBookTextBox.Text.Contains(".ru") | mailBookTextBox.Text.Contains(".by")))
            {

                bool check = interm.db.AskWithCheck
                    ("insert into Notebook values(N'" + nameBookTextBox.Text + "',N'" + ownerBookTextBox.Text + "',SYSDATETIME()," +
                    "N'" + FilePathAvatar + "',N'" + mailBookTextBox.Text + "',N'" + passwordBookPB.Password.ToString() + "',N'Показывать')",
                    "select * from Notebook where nameBook = N'" + nameBookTextBox.Text + "' or emailOwner = N'" + mailBookTextBox.Text + "'"); ;
                if (check == false)
                {
                    addBookGrid.Visibility = Visibility.Hidden;
                    nameBookTextBox.Text = "";
                    ownerBookTextBox.Text = "";
                    mailBookTextBox.Text = "";
                    passwordBookPB.Password = "";
                    avatarImage.Source = new BitmapImage(new Uri("Picture/avatar.png", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Запись с такими данными уже существует.");
                }
                UpdateNoteBooks();
            }
            else
            {
                MessageBox.Show("Не вся поля заполненны корректно.");

                if (nameBookTextBox.Text.Replace(" ", "") == "")
                {
                    nameBookRedLine.Visibility = Visibility.Visible;
                }
                if (ownerBookTextBox.Text.Replace(" ", "") == "")
                {
                    ownerBookRedLine.Visibility = Visibility.Visible;
                }
                if (mailBookTextBox.Text.Replace(" ", "") == "")
                {
                    mailBookRedLine.Visibility = Visibility.Visible;
                }
            }
        }

        //Обновление книг при входе мышки
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            UpdateNoteBooks();
        }

        //
        private void quest_MouseEnter(object sender, MouseEventArgs e)
        {
            quest.Opacity = 1;
        }

        private void quest_MouseLeave(object sender, MouseEventArgs e)
        {
            quest.Opacity = 0.5;
        }

        private void quest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            questGrid.Visibility = Visibility.Visible;
            bluerGrid.Visibility = Visibility.Visible;
        }

        //
        private void bluerGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            questGrid.Visibility = Visibility.Hidden;
            bluerGrid.Visibility = Visibility.Hidden;
        }

        //
        private void closeQuestButton_Click(object sender, RoutedEventArgs e)
        {
            questGrid.Visibility = Visibility.Hidden;
            bluerGrid.Visibility = Visibility.Hidden;
        }
    }
}
