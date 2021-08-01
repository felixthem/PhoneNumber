using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Моя_телефонная_книга.UserControls;

namespace Моя_телефонная_книга.Window_s
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public string id, nameBook, nameOwner, dateCreate, iconOwner, mailOwner, password, areChecked;
        string idContact, name, surname, patr, icon, number, mail, birthday, dateAdd, nameGroup, comment;

        public string FilePathContactAvatar { get; private set; }
        public string FilePathSVG { get; private set; }
        public string FilePathBookAvatar { get; set; }

        public MenuWindow()
        {
            InitializeComponent();
            UpdateContact("select * from Contact where idNotebook = '" + id + "'");
            FilePathContactAvatar = @"C:\Users\Жмых\source\repos\Моя телефонная книга\Picture\avatar.png";
            typeComboBox.Items.Add("Все");
            typeComboBox.Items.Add("Входящие");
            typeComboBox.Items.Add("Исходящие");
            typeComboBox.Items.Add("Пропущенные");
            typeComboBox.SelectedIndex = 0;
            periodComboBox.Items.Add("За всё время");
            periodComboBox.Items.Add("За год");
            periodComboBox.Items.Add("За месяц");
            periodComboBox.Items.Add("За неделю");
            periodComboBox.Items.Add("За период");
            periodComboBox.SelectedIndex = 0;

            searchTextBox.MaxLength = 33;
            commentContactAddTextBox.MaxLength = 32;
            mailContactAddTextBox.MaxLength = 43;
            numberContactAddTextBox.MaxLength = 16;
            patrContactAddTextBox.MaxLength = 30;
            surnameContactAddTextBox.MaxLength = 30;
            nameContactAddTextBox.MaxLength = 30;
            mailExportTextBox.MaxLength = 53;
            searchGroupTextBox.MaxLength = 33;
            changeNameGroupTextBox.MaxLength = 30;
            newNameGroupHideTextBox.MaxLength = 30;
            changePasswordBookTextBox.MaxLength = 20;
            changeMailBookTextBox.MaxLength = 43;
            changeOwnerBookTextBox.MaxLength = 30;
            changeNameBookTextBox.MaxLength = 30;

            this.numberContactAddTextBox.PreviewTextInput += new TextCompositionEventHandler(numberContactAddTextBox_TextInput);

            changeNameGroupTextBox.IsEnabled = true;
        }

        //Конструктор класса принимающий значение ID
        public MenuWindow(string Id)
        {
            id = Id;
            InitializeComponent();
            UpdateContact("select * from Contact where idNotebook = '" + id + "'");
            FilePathContactAvatar = @"C:\Users\Жмых\source\repos\Моя телефонная книга\Picture\avatar.png";
            typeComboBox.Items.Add("Все");
            typeComboBox.Items.Add("Входящие");
            typeComboBox.Items.Add("Исходящие");
            typeComboBox.Items.Add("Пропущенные");
            typeComboBox.SelectedIndex = 0;
            periodComboBox.Items.Add("За всё время");
            periodComboBox.Items.Add("За год");
            periodComboBox.Items.Add("За месяц");
            periodComboBox.Items.Add("За неделю");
            periodComboBox.Items.Add("За период");
            periodComboBox.SelectedIndex = 0;

            searchTextBox.MaxLength = 33;
            commentContactAddTextBox.MaxLength = 32;
            mailContactAddTextBox.MaxLength = 43;
            numberContactAddTextBox.MaxLength = 16;
            patrContactAddTextBox.MaxLength = 30;
            surnameContactAddTextBox.MaxLength = 30;
            nameContactAddTextBox.MaxLength = 30;
            mailExportTextBox.MaxLength = 53;
            searchGroupTextBox.MaxLength = 33;
            changeNameGroupTextBox.MaxLength = 30;
            newNameGroupHideTextBox.MaxLength = 30;
            changePasswordBookTextBox.MaxLength = 20;
            changeMailBookTextBox.MaxLength = 43;
            changeOwnerBookTextBox.MaxLength = 30;
            changeNameBookTextBox.MaxLength = 30;

            changeNameGroupTextBox.IsEnabled = true;
        }

        //Открытие богового меню
        private void moreImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuGrid.Visibility = Visibility.Visible;
            bluerGrid.Visibility = Visibility.Visible;
        }

        //Наведение на краткую информацию о записной книге
        private void nameOwnerTB_MouseEnter(object sender, MouseEventArgs e)
        {
            nameBookTB.Opacity = 1;
            nameOwnerTB.Opacity = 1;
        }

        private void nameBookTB_MouseLeave(object sender, MouseEventArgs e)
        {
            nameBookTB.Opacity = 0.85;
            nameOwnerTB.Opacity = 0.7;
        }

        //Наведение на пункты меню
        private void createContact_MouseEnter(object sender, MouseEventArgs e)
        {
            createContact.Opacity = 1;
            createContactGrid.Visibility = Visibility.Visible;
        }

        private void createContact_MouseLeave(object sender, MouseEventArgs e)
        {
            createContact.Opacity = 0.9;
            createContactGrid.Visibility = Visibility.Hidden;

        }

        private void createGroup_MouseEnter(object sender, MouseEventArgs e)
        {
            createGroup.Opacity = 1;
            createGroupGrid.Visibility = Visibility.Visible;
        }
        private void createGroup_MouseLeave(object sender, MouseEventArgs e)
        {
            createGroup.Opacity = 0.9;
            createGroupGrid.Visibility = Visibility.Hidden;
        }

        private void stat_MouseEnter(object sender, MouseEventArgs e)
        {
            stat.Opacity = 1;
            statGrid.Visibility = Visibility.Visible;
        }

        private void stat_MouseLeave(object sender, MouseEventArgs e)
        {
            stat.Opacity = 0.9;
            statGrid.Visibility = Visibility.Hidden;
        }

        private void import_MouseEnter(object sender, MouseEventArgs e)
        {
            import.Opacity = 1;
            importGrid.Visibility = Visibility.Visible;
        }

        private void import_MouseLeave(object sender, MouseEventArgs e)
        {
            import.Opacity = 0.9;
            importGrid.Visibility = Visibility.Hidden;
        }

        private void export_MouseEnter(object sender, MouseEventArgs e)
        {
            export.Opacity = 1;
            exportGrid.Visibility = Visibility.Visible;
        }

        private void export_MouseLeave(object sender, MouseEventArgs e)
        {
            export.Opacity = 0.9;
            exportGrid.Visibility = Visibility.Hidden;
        }


        private void print_MouseEnter(object sender, MouseEventArgs e)
        {
            print.Opacity = 1;
            printGrid.Visibility = Visibility.Visible;
        }

        private void print_MouseLeave(object sender, MouseEventArgs e)
        {
            print.Opacity = 0.9;
            printGrid.Visibility = Visibility.Hidden;
        }

        private void help_MouseEnter(object sender, MouseEventArgs e)
        {
            help.Opacity = 1;
            helpGrid.Visibility = Visibility.Visible;
        }

        private void help_MouseLeave(object sender, MouseEventArgs e)
        {
            help.Opacity = 0.9;
            helpGrid.Visibility = Visibility.Hidden;
        }

        private void deleteBook_MouseEnter(object sender, MouseEventArgs e)
        {
            deleteBook.Opacity = 0.8;
            deleteBookGrid.Visibility = Visibility.Visible;
        }

        private void deleteBook_MouseLeave(object sender, MouseEventArgs e)
        {
            deleteBook.Opacity = 0.69;
            deleteBookGrid.Visibility = Visibility.Hidden;
        }

        private void exit_MouseEnter(object sender, MouseEventArgs e)
        {
            exit.Opacity = 1;
            exitGrid.Visibility = Visibility.Visible;
        }

        private void exit_MouseLeave(object sender, MouseEventArgs e)
        {
            exit.Opacity = 0.8;
            exitGrid.Visibility = Visibility.Hidden;
        }

        //Выход к стартовому окну 
        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Уверены что хотите выйти?", "Проверка", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Application.Current.MainWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        //Нажатие на bluerGrid
        private void bluerGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            journalGrid.Visibility = Visibility.Hidden;
            menuGrid.Visibility = Visibility.Hidden;
            bluerGrid.Visibility = Visibility.Hidden;
            contactSV.Visibility = Visibility.Hidden;
            exportContactStartGrid.Visibility = Visibility.Hidden;
            exportContactFinishGrid.Visibility = Visibility.Hidden;
            groupGrid.Visibility = Visibility.Hidden;
            groupChangeGrid.Visibility = Visibility.Hidden;
            groupAddContactGrid.Visibility = Visibility.Hidden;
            changeBookGrid.Visibility = Visibility.Hidden;
            bigHelpGrid.Visibility = Visibility.Hidden;
            clearGrid.Visibility = Visibility.Hidden;
            bluerGrid.Visibility = Visibility.Hidden;
            helpDGrid.Visibility = Visibility.Hidden;
            selectTypeCallGrid.Visibility = Visibility.Hidden;
            //Убирает значения в добавление контакта(и редактирование)
            nameContactAddTextBox.Text = "";
            surnameContactAddTextBox.Text = "";
            patrContactAddTextBox.Text = "";
            numberContactAddTextBox.Text = "";
            mailContactAddTextBox.Text = "";
            groupContactComboBox.Text = "";
            commentContactAddTextBox.Text = "";


            avatarContactAddImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));

            //Убирает e-mail в экспорте
            mailExportTextBox.Text = "";
            //Очищает поле поиска в groupGrid
            searchGroupTextBox.Text = "";
            searchGroupHideTextBox.Visibility = Visibility.Visible;
            //Очищает список выделеных контактов
            interm.db.exportContact.Clear();
            //Убирает название при создании новой группы
            newNameGroupTextBox.Text = "";
        }

        //Работа кнопок правой верхней панели
        private void closeGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            closeGrid.Background = Brushes.Red;
            closeImage.Opacity = 1;
        }

        private void closeGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            closeGrid.Background = null;
            closeImage.Opacity = 0.5;
        }

        private void closeGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Close();
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


        //Убирает красную полосу под номером
        private void numberContactAddTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            numberContactAddRedLine.Visibility = Visibility.Hidden;
        }

        //Закрытие формы ввода почты и вывод формы выбора контактов для экспорта
        private void nextExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (mailExportTextBox.Text.Contains("@") & (mailExportTextBox.Text.Contains(".com") | mailExportTextBox.Text.Contains(".ru") | mailExportTextBox.Text.Contains(".by")))
            {
                exportContactStartGrid.Visibility = Visibility.Hidden;
                exportContactFinishGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Неверный формат e-mail.");
            }
        }

        //Убирает красную полосу под именем
        private void nameContactAddTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            nameContactAddRedLine.Visibility = Visibility.Hidden;
        }

        //Визуал смены аватарки у контакта
        private void photoElipse_MouseEnter(object sender, MouseEventArgs e)
        {
            changeContactPhotoGrid.Visibility = Visibility.Visible;
            changeContactPhotoClickGrid.Visibility = Visibility.Visible;
        }


        private void photoElipse_MouseLeave(object sender, MouseEventArgs e)
        {
            changeContactPhotoGrid.Visibility = Visibility.Hidden;
            changeContactPhotoClickGrid.Visibility = Visibility.Hidden;
        }

        //Визуал кнопки добавления новой группы
        private void addGroupImage_MouseEnter(object sender, MouseEventArgs e)
        {
            addGroupImage.Opacity = 1;
        }

        private void addGroupImage_MouseLeave(object sender, MouseEventArgs e)
        {
            addGroupImage.Opacity = 0.6;
        }

        //Визуал нажатия клавиши на TextBox поиска группы
        private void searchGroupTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            searchGroupHideTextBox.Visibility = Visibility.Hidden;
        }

        //Вывод на экран groupGrid + вывод н ListBox всех групп с количеством контактов в них
        private void createGroup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuGrid.Visibility = Visibility.Hidden;
            groupGrid.Visibility = Visibility.Visible;
            UpdateGroup("select distinct(nameGroup), count(nameGroup) from Contact where nameGroup != '' and idNotebook = " + id + " group by nameGroup");
        }

        //Выбор новой аватарки контакта
        private void avatarImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string ava = avatarContactAddImage.Source.ToString();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathContactAvatar = openFileDialog.FileName;
                try
                {
                    avatarContactAddImage.Source = new BitmapImage(new Uri(FilePathContactAvatar));
                }
                catch
                {
                    MessageBox.Show("Выбран неверный формат файла.");

                    avatarContactAddImage.Source = new BitmapImage(new Uri(ava));
                    FilePathContactAvatar = ava;
                }
            }
        }

        //Визуал кнопки удаления контактов из группы
        private void deleteFromGroupImage_MouseEnter(object sender, MouseEventArgs e)
        {
            deleteFromGroupImage.Opacity = 1;
        }

        private void deleteFromGroupImage_MouseLeave(object sender, MouseEventArgs e)
        {
            deleteFromGroupImage.Opacity = 0.6;
        }

        //Наведение на кнопку вызова правого меню
        private void moreImage_MouseEnter(object sender, MouseEventArgs e)
        {
            moreImage.Opacity = 1;
        }

        private void moreImage_MouseLeave(object sender, MouseEventArgs e)
        {
            moreImage.Opacity = 0.6;
        }

        //Убирает надпись Поиск
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            searchHideTextBox.Visibility = Visibility.Hidden;
        }

        //Визуал TextBox названия новой группы
        private void newNameGroupTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            newNameGroupRedLine.Visibility = Visibility.Hidden;
        }

        private void newNameGroupTextBox_Copy_KeyDown(object sender, KeyEventArgs e)
        {
            newNameGroupHideTextBox.Visibility = Visibility.Hidden;
        }

        private void newNameGroupTextBox_Copy_KeyUp(object sender, KeyEventArgs e)
        {
            if (newNameGroupTextBox.Text == "")
            {
                newNameGroupHideTextBox.Visibility = Visibility.Visible;
            }
        }

        //Вывод нового Grid с добавлением контактов в группу
        private void addGroupImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            groupGrid.Visibility = Visibility.Hidden;
            groupAddContactGrid.Visibility = Visibility.Visible;
            UpdateContactWithoutGroup();
        }

        //Визуал изменения аватарки записной книги
        private void avatarBookChangeImage_MouseEnter(object sender, MouseEventArgs e)
        {
            avatarBookChangePhotoGrid.Visibility = Visibility.Visible;
            avatarBookChangePhotoClickGrid.Visibility = Visibility.Visible;
        }

        private void avatarBookChangeImage_MouseLeave(object sender, MouseEventArgs e)
        {
            avatarBookChangePhotoGrid.Visibility = Visibility.Hidden;
            avatarBookChangePhotoClickGrid.Visibility = Visibility.Hidden;
        }

        //Выбор новой автарки записной книги
        private void avatarBookChangeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathBookAvatar = openFileDialog.FileName;
                try
                {
                    avatarBookChangeImage.Source = new BitmapImage(new Uri(FilePathBookAvatar));
                }
                catch
                {
                    MessageBox.Show("Выбран неверный формат файла.");
                    avatarBookChangeImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                    FilePathBookAvatar = avatarBookChangeImage.Source.ToString();
                }
            }
        }

        //Перенос данных на форму редактирования записной книги
        private void nameBookTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            changeNameBookTextBox.Text = nameBookTB.Text;
            changeOwnerBookTextBox.Text = nameOwnerTB.Text;
            changeMailBookTextBox.Text = mailOwner;
            changePasswordBookTextBox.Text = password;
            try
            {
                avatarBookChangeImage.Source = new BitmapImage(new Uri(FilePathBookAvatar));
            }
            catch
            {
                avatarBookChangeImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
            }
            changeBookGrid.Visibility = Visibility.Visible;
            menuGrid.Visibility = Visibility.Hidden;
        }

        //Убирает крансые полосы
        private void changeNameBookTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            changeNameBookRedLine.Visibility = Visibility.Hidden;
        }

        private void changeOwnerBookTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            changeOwnerBookRedLine.Visibility = Visibility.Hidden;
        }

        private void changeMailBookTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            changeMailBookRedLine.Visibility = Visibility.Hidden;
        }

        private void changePasswordBookTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            changePasswordBookRedLine.Visibility = Visibility.Hidden;
        }

        //Визуал выбора всех контактов в группее
        private void checkAkkContactTB_MouseEnter(object sender, MouseEventArgs e)
        {
            checkAkkContactTB.Opacity = 1;
            checkEllipse.Opacity = 1;
            checkImage.Opacity = 1;
        }

        private void checkAkkContactTB_MouseLeave(object sender, MouseEventArgs e)
        {
            checkAkkContactTB.Opacity = 0.8;
            checkEllipse.Opacity = 0.8;
            checkImage.Opacity = 0.8;
        }

        //Визуал кнопки настроек
        private void settingImage_MouseEnter(object sender, MouseEventArgs e)
        {
            settingImage.Opacity = 1;
        }

        private void settingImage_MouseLeave(object sender, MouseEventArgs e)
        {
            settingImage.Opacity = 0.5;
        }

        private void settingImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            settingGrid.Visibility = Visibility.Visible;
            panelGrid.Width = 895;
        }

        //Визуал кнопки закрытия настроек
        private void closeSettingImage_MouseEnter(object sender, MouseEventArgs e)
        {
            closeSettingImage.Opacity = 1;
        }

        private void closeSettingImage_MouseLeave(object sender, MouseEventArgs e)
        {
            closeSettingImage.Opacity = 0.5;
        }

        private void closeSettingImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            settingGrid.Visibility = Visibility.Hidden;
            panelGrid.Width = 1302;
        }

        //Визуал кнопки удаления контакта
        private void deleteContact_MouseEnter(object sender, MouseEventArgs e)
        {
            deleteContactGrid.Visibility = Visibility.Visible;
            deleteContact.Opacity = 1;
        }

        private void deleteContact_MouseLeave(object sender, MouseEventArgs e)
        {
            deleteContactGrid.Visibility = Visibility.Hidden;
            deleteContact.Opacity = 0.7;
        }

        //Визуал редактирования контакта
        private void changeContact_MouseEnter(object sender, MouseEventArgs e)
        {
            changeContact.Opacity = 1;
            changeContactGrid.Visibility = Visibility.Visible;
        }

        private void changeContact_MouseLeave(object sender, MouseEventArgs e)
        {
            changeContact.Opacity = 0.9;
            changeContactGrid.Visibility = Visibility.Hidden;
        }

        //Визуал настроек выборки
        private void allTB_MouseEnter(object sender, MouseEventArgs e)
        {
            allTB.Opacity = 1;
        }

        private void allTB_MouseLeave(object sender, MouseEventArgs e)
        {
            allTB.Opacity = 0.7;
        }

        private void inTB_MouseEnter(object sender, MouseEventArgs e)
        {
            inTB.Opacity = 1;
        }

        private void inTB_MouseLeave(object sender, MouseEventArgs e)
        {
            inTB.Opacity = 0.7;
        }

        private void outTB_MouseEnter(object sender, MouseEventArgs e)
        {
            outTB.Opacity = 1;
        }

        private void outTB_MouseLeave(object sender, MouseEventArgs e)
        {
            outTB.Opacity = 0.7;
        }

        private void missTB_MouseEnter(object sender, MouseEventArgs e)
        {
            missTB.Opacity = 1;
        }

        private void missTB_MouseLeave(object sender, MouseEventArgs e)
        {
            missTB.Opacity = 0.7;
        }

        int a = 1, g = 0, c = 0, d = 0;
        private void allTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (a == 0)
            {
                inCheckImage.Visibility = Visibility.Hidden;
                outCheckImage.Visibility = Visibility.Hidden;
                missCheckImage.Visibility = Visibility.Hidden;
                allCheckImage.Visibility = Visibility.Visible;
                a++;
                g = 0; c = 0; d = 0;
                type = "";
                ForOurConvers();
            }
            else { allCheckImage.Visibility = Visibility.Hidden; a = 0; }
        }

        private void inTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (g == 0)
            {
                outCheckImage.Visibility = Visibility.Hidden;
                missCheckImage.Visibility = Visibility.Hidden;
                allCheckImage.Visibility = Visibility.Hidden;
                inCheckImage.Visibility = Visibility.Visible;
                a = 0; c = 0; d = 0;
                g++;
                type = " and type = 'incoming' ";
                ForOurConvers();
            }
            else { inCheckImage.Visibility = Visibility.Hidden; g = 0; }
        }

        private void outTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (c == 0)
            {
                inCheckImage.Visibility = Visibility.Hidden;
                outCheckImage.Visibility = Visibility.Visible;
                missCheckImage.Visibility = Visibility.Hidden;
                allCheckImage.Visibility = Visibility.Hidden;
                c++;
                a = 0; g = 0; d = 0;
                type = " and type = 'outgoing' ";
                ForOurConvers();
            }
            else { outCheckImage.Visibility = Visibility.Hidden; c = 0; }
        }

        private void missTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (d == 0)
            {
                inCheckImage.Visibility = Visibility.Hidden;
                outCheckImage.Visibility = Visibility.Hidden;
                missCheckImage.Visibility = Visibility.Visible;
                allCheckImage.Visibility = Visibility.Hidden;
                d++;
                a = 0; g = 0; c = 0;
                type = " and type = 'missed' ";
                ForOurConvers();
            }
            else { missCheckImage.Visibility = Visibility.Hidden; d = 0; }
        }

        //
        private void allTimeTB_MouseEnter(object sender, MouseEventArgs e)
        {
            allTimeTB.Opacity = 1;
        }

        private void allTimeTB_MouseLeave(object sender, MouseEventArgs e)
        {
            allTimeTB.Opacity = 0.7;
        }

        private void yearTB_MouseEnter(object sender, MouseEventArgs e)
        {
            yearTB.Opacity = 1;
        }

        private void yearTB_MouseLeave(object sender, MouseEventArgs e)
        {
            yearTB.Opacity = 0.7;
        }

        private void monthTB_MouseEnter(object sender, MouseEventArgs e)
        {
            monthTB.Opacity = 1;
        }

        private void monthTB_MouseLeave(object sender, MouseEventArgs e)
        {
            monthTB.Opacity = 0.7;
        }

        private void weekTB_MouseEnter(object sender, MouseEventArgs e)
        {
            weekTB.Opacity = 1;
        }

        private void weekTB_MouseLeave(object sender, MouseEventArgs e)
        {
            weekTB.Opacity = 0.7;
        }
        private void periodTB_MouseEnter(object sender, MouseEventArgs e)
        {
            periodTB.Opacity = 1;
        }

        private void periodTB_MouseLeave(object sender, MouseEventArgs e)
        {
            periodTB.Opacity = 0.7;
        }

        private void periodTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (p == 0)
            {
                allTimeCheckImage.Visibility = Visibility.Hidden;
                yearCheckImage.Visibility = Visibility.Hidden;
                monthCheckImage.Visibility = Visibility.Hidden;
                weekCheckImage.Visibility = Visibility.Hidden;
                periodCheckImage.Visibility = Visibility.Visible;
                p++;
                w = 0; t = 0; r = 0; q = 0;
                startContactDatePicker.IsEnabled = true;
                endContactDatePicker.IsEnabled = true;
            }
            else { allTimeCheckImage.Visibility = Visibility.Hidden; p = 0; }
        }

        int q = 0, w = 0, t = 0, r = 0, p = 0;
        private void allTimeTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (q == 0)
            {
                allTimeCheckImage.Visibility = Visibility.Visible;
                yearCheckImage.Visibility = Visibility.Hidden;
                monthCheckImage.Visibility = Visibility.Hidden;
                weekCheckImage.Visibility = Visibility.Hidden;
                p = 0;
                periodCheckImage.Visibility = Visibility.Hidden;
                startContactDatePicker.IsEnabled = false;
                endContactDatePicker.IsEnabled = false;
                q++;
                w = 0; t = 0; r = 0;
                period = "";
                ForOurConvers();
            }
            else { allTimeCheckImage.Visibility = Visibility.Hidden; q = 0; }
        }

        private void yearTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (w == 0)
            {
                allTimeCheckImage.Visibility = Visibility.Hidden;
                yearCheckImage.Visibility = Visibility.Visible;
                monthCheckImage.Visibility = Visibility.Hidden;
                weekCheckImage.Visibility = Visibility.Hidden;
                p = 0;
                periodCheckImage.Visibility = Visibility.Hidden;
                startContactDatePicker.IsEnabled = false;
                endContactDatePicker.IsEnabled = false;
                w++;
                q = 0; t = 0; r = 0;
                period = " and dateCall between (year(getdate())) and getdate() and year(dateCall) = year(sysdatetime()) ";
                ForOurConvers();
            }
            else { yearCheckImage.Visibility = Visibility.Hidden; w = 0; }
        }

        private void monthTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (t == 0)
            {
                allTimeCheckImage.Visibility = Visibility.Hidden;
                yearCheckImage.Visibility = Visibility.Hidden;
                monthCheckImage.Visibility = Visibility.Visible;
                weekCheckImage.Visibility = Visibility.Hidden;
                p = 0;
                periodCheckImage.Visibility = Visibility.Hidden;
                startContactDatePicker.IsEnabled = false;
                endContactDatePicker.IsEnabled = false;
                t++;
                w = 0; q = 0; r = 0;
                period = " and dateCall between (month(getdate())) and getdate() and year(dateCall) = year(sysdatetime()) ";
                ForOurConvers();
            }
            else { monthCheckImage.Visibility = Visibility.Hidden; t = 0; }
        }

        private void weekTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (r == 0)
            {
                allTimeCheckImage.Visibility = Visibility.Hidden;
                yearCheckImage.Visibility = Visibility.Hidden;
                monthCheckImage.Visibility = Visibility.Hidden;
                weekCheckImage.Visibility = Visibility.Visible;
                p = 0;
                periodCheckImage.Visibility = Visibility.Hidden;
                startContactDatePicker.IsEnabled = false;
                endContactDatePicker.IsEnabled = false;
                r++;
                period = " and dateCall between (getdate() - 7) and getdate() and year(dateCall) = year(sysdatetime()) ";
                w = 0; t = 0; q = 0;
                ForOurConvers();
            }
            else { weekCheckImage.Visibility = Visibility.Hidden; r = 0; }
        }

        //
        private void help_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuGrid.Visibility = Visibility.Hidden;
            bigHelpGrid.Visibility = Visibility.Visible;
        }

        //
        private void closeHelpImage_MouseEnter(object sender, MouseEventArgs e)
        {
            closeHelpImage.Opacity = 1;
        }

        private void closeHelpImage_MouseLeave(object sender, MouseEventArgs e)
        {
            closeHelpImage.Opacity = 0.5;
        }

        private void closeHelpImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bigHelpGrid.Visibility = Visibility.Hidden;
            bluerGrid.Visibility = Visibility.Hidden;
        }

        //
        private void cancelClear_Click(object sender, RoutedEventArgs e)
        {
            clearGrid.Visibility = Visibility.Hidden;
            bluerGrid.Visibility = Visibility.Hidden;
        }

        //
        private void clearContactLog_MouseEnter(object sender, MouseEventArgs e)
        {
            clearContactLogGrid.Visibility = Visibility.Visible;
        }

        private void clearContactLog_MouseLeave(object sender, MouseEventArgs e)
        {
            clearContactLogGrid.Visibility = Visibility.Hidden;
        }

        private void clearContactLog_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (areChecked == "Показывать")
            {
                clearGrid.Visibility = Visibility.Visible;
                bluerGrid.Visibility = Visibility.Visible;
            }
            else
            {
                interm.db.Ask("delete from Log where idContact =" + idContact + period + type);
                GetCallLog("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type from Log where idContact = " + idContact + period + type);
            }
        }

        //
        private void clearJournal_MouseEnter(object sender, MouseEventArgs e)
        {
            clearJournalGrid.Visibility = Visibility.Visible;
        }

        private void clearJournal_MouseLeave(object sender, MouseEventArgs e)
        {
            clearJournalGrid.Visibility = Visibility.Hidden;
        }

        private void clearJournal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (areChecked == "Показывать")
            {
                clearGrid.Visibility = Visibility.Visible;
                bluerGrid.Visibility = Visibility.Visible;
            }
            else
            {
                interm.db.Ask("delete from Log where idContact in (select idContact from Contact where idNotebook = " + id + ") " + periodLog + typeLog);
                GetJournal();
                GetStatJournal();
            }
        }

        //
        private void helpDiagrammButton_Click(object sender, RoutedEventArgs e)
        {
            helpDGrid.Visibility = Visibility.Visible;
            bluerGrid.Visibility = Visibility.Visible;
        }

        private void closeHelpDButton_Click(object sender, RoutedEventArgs e)
        {
            helpDGrid.Visibility = Visibility.Hidden;
            bluerGrid.Visibility = Visibility.Hidden;
        }



        //
        private void doCallImage_MouseEnter(object sender, MouseEventArgs e)
        {
            doCallImage.Opacity = 1;
        }

        private void doCallImage_MouseLeave(object sender, MouseEventArgs e)
        {
            doCallImage.Opacity = 0.7;
        }

        private void doCallImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bluerGrid2.Visibility = Visibility.Visible;
            selectTypeCallGrid.Visibility = Visibility.Visible;
        }

        //
        private void inCallTB_MouseEnter(object sender, MouseEventArgs e)
        {
            outCallGrid.Visibility = Visibility.Visible;
        }

        private void inCallTB_MouseLeave(object sender, MouseEventArgs e)
        {
            outCallGrid.Visibility = Visibility.Hidden;
        }

        private void outCallTB_MouseEnter(object sender, MouseEventArgs e)
        {
            inCallGrid.Visibility = Visibility.Visible;
        }

        private void outCallTB_MouseLeave(object sender, MouseEventArgs e)
        {
            inCallGrid.Visibility = Visibility.Hidden;
        }

        private void missedCallTB_MouseEnter(object sender, MouseEventArgs e)
        {
            missedCallGrid.Visibility = Visibility.Visible;
        }

        private void missedCallTB_MouseLeave(object sender, MouseEventArgs e)
        {
            missedCallGrid.Visibility = Visibility.Hidden;
        }

        private void cancekCallButton_Click(object sender, RoutedEventArgs e)
        {
            bluerGrid2.Visibility = Visibility.Hidden;
            selectTypeCallGrid.Visibility = Visibility.Hidden;
        }
        //
        private void inCallTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CallWindow call = new CallWindow(idContact, avatarContactImage.Source.ToString(), "incoming", fioContactTB.Text, numberContactTB.Text);
            call.Show();
            selectTypeCallGrid.Visibility = Visibility.Hidden;
            bluerGrid2.Visibility = Visibility.Hidden;
        }

        private void outCallTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CallWindow call = new CallWindow(idContact, avatarContactImage.Source.ToString(), "outgoing", fioContactTB.Text, numberContactTB.Text);
            call.Show();
            selectTypeCallGrid.Visibility = Visibility.Hidden;
            bluerGrid2.Visibility = Visibility.Hidden;
        }

        private void missedCallTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectTypeCallGrid.Visibility = Visibility.Hidden;
            bluerGrid2.Visibility = Visibility.Hidden;
            interm.db.Ask("insert into Log values(" + idContact + ",'00:00:00','00:00:00', sysdatetime(), 'missed');");
            ForOurConvers();
        }

        //
        private void numberContactAddTextBox_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        //
        private void numberContactAddTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            int count = 0;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || (c == '+' && c == 0))
                {
                    newText += c;
                    if (c == '+')
                        count += 1;
                }
            }
            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
        }

        //----------------------------------------------------------------------------//
        //----------------------   Часть работы с БД  --------------------------------//
        //----------------------------------------------------------------------------//

        string period, type;
        public void ForOurConvers()
        {
            GetCallLog("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type from Log where idContact = " + idContact + period + type);
            double[] data = interm.db.GetDouble("select count(type) from Log where idContact = " + idContact + period + type);
            double o, i, m, max, point;
            i = data[0];
            o = data[1];
            m = data[2];
            outgoing.Text = Convert.ToString(o);
            incoming.Text = Convert.ToString(i);
            missed1.Text = Convert.ToString(m);
            max = o + i + m;
            maxTextLock.Text = Convert.ToString(max);
            halfTextLock.Text = Convert.ToString(max / 2.0);
            point = 3760 / max;
            _in.Height = point * i / 10;
            _out.Height = point * o / 10;
            missed.Height = point * m / 10;
        }

        //Поиск контактов
        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            searchHideTextBox.Visibility = Visibility.Hidden;
            if (searchTextBox.Text == "")
            {
                searchHideTextBox.Visibility = Visibility.Visible;
                UpdateContact("select * from Contact where idNotebook = '" + id + "'");
            }
            else
            {
                UpdateContact("select * from Contact where idNotebook = '" + id + "' and (name like N'%" + searchTextBox.Text + "%' or patr like N'%" + searchTextBox.Text + "%' or surname like N'%" + searchTextBox.Text + "%' or number like N'%" + searchTextBox.Text + "%')");
            }
        }

        //Добавление контактов в группу
        private void acceptCreateGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (interm.db.exportContact.Count != 0)
            {
                bool check = interm.db.AskWithCheck("select * from Contact", "select * from Contact where idNotebook = " + id + " and nameGroup = N'" + newNameGroupTextBox.Text + "'");
                if (check == false)
                {
                    if (newNameGroupTextBox.Text.Replace(" ", "") != "")
                    {
                        int i = interm.db.AddContactToGroup(id, newNameGroupTextBox.Text);
                        MessageBox.Show("Группа " + newNameGroupTextBox.Text + " успешно создана, добавление контактов(" + i + ") успешно.");
                        UpdateContact("select * from Contact where idNotebook = '" + id + "' and (name like N'%" + searchTextBox.Text + "%' or patr like N'%" + searchTextBox.Text + "%' or surname like N'%" + searchTextBox.Text + "%' or number like N'%" + searchTextBox.Text + "%')");
                        groupAddContactGrid.Visibility = Visibility.Hidden;
                        bluerGrid.Visibility = Visibility.Hidden;
                        newNameGroupTextBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное название группы.");
                    }
                }
                else
                {
                    MessageBox.Show("Такая группа уже сущестует.");
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одного контакта.");
            }
            interm.db.exportContact.Clear();
        }

        //Обновление списка контактов на основе запроса
        public void UpdateContact(string Ask)
        {
            contactListBox.Items.Clear();
            List<Contact> cont = new List<Contact>();
            cont = interm.db.GetContact(Ask);
            foreach (Contact Contact in cont)
            {
                ContactUC contact = new ContactUC();
                contact.id = Contact.id;
                contact.name = Contact.name;
                contact.surname = Contact.surname;
                contact.patr = Contact.patr;
                contact.fioContactTB.Text = Contact.name + " " + Contact.surname + " " + Contact.patr;
                try
                {
                    contact.avatarImage.Source = new BitmapImage(new Uri(Contact.icon));
                }
                catch
                {
                    contact.avatarImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                }
                contact.icon = Contact.icon;
                contact.number = Contact.number;
                contact.numberContactTB.Text = Contact.number;
                contact.mail = Contact.mail;
                contact.birthday = Contact.birthday;
                contact.dateAdd = Contact.dateAdd;
                contact.nameGroup = Contact.nameGroup;
                contact.comment = Contact.comment;
                contactListBox.Items.Add(contact);
            }
        }

        int i = 0;
        //Выделение всех контактов в выбранной группе
        private void checkAkkContactTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (i == 0)
            {
                interm.db.exportContact.Clear();
                groupChangeListBox.Items.Clear();
                List<Contact> cont = new List<Contact>();
                cont = interm.db.GetContact("select * from Contact where idNotebook = '" + id + "' and nameGroup = N'" + groupName + "'");
                foreach (Contact Contact in cont)
                {
                    GroupContactUC contact = new GroupContactUC(1);
                    contact.id = Contact.id;
                    contact.name = Contact.name;
                    contact.surname = Contact.surname;
                    contact.patr = Contact.patr;
                    contact.fioContactTB.Text = Contact.name + " " + Contact.surname + " " + Contact.patr;

                    try
                    {
                        contact.avatarImage.Source = new BitmapImage(new Uri(Contact.icon));
                    }
                    catch
                    {
                        contact.avatarImage.Source = new BitmapImage(new Uri(Contact.icon, UriKind.Relative));
                    }
                    contact.icon = Contact.icon;
                    contact.number = Contact.number;
                    contact.numberContactTB.Text = Contact.number;
                    contact.mail = Contact.mail;
                    contact.birthday = Contact.birthday;
                    contact.dateAdd = Contact.dateAdd;
                    contact.nameGroup = Contact.nameGroup;
                    contact.comment = Contact.comment;
                    groupChangeListBox.Items.Add(contact);
                    interm.db.exportContact.Add(Contact);
                }
                checkImage.Visibility = Visibility.Visible;
                i++;
            }
            else
            {
                interm.db.exportContact.Clear();
                UpdateContactGroup("select * from Contact where idNotebook = '" + id + "' and nameGroup = N'" + groupName + "'");
                checkImage.Visibility = Visibility.Hidden;
                i = 0;
            }
        }

        //Удаление контакта
        private void deleteContact_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Уверены что хоитте удалить контакт?", "Проверка", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    interm.db.Ask("delete from Contact where idNotebook = " + id + " and number = '" + number + "'");
                    UpdateContact("select * from Contact where idNotebook = '" + id + "' and (name like N'%" + searchTextBox.Text + "%' or patr like N'%" + searchTextBox.Text + "%' or surname like N'%" + searchTextBox.Text + "%' or number like N'%" + searchTextBox.Text + "%')");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        //Редактирование контакта
        private void changeContact_MouseDown(object sender, MouseButtonEventArgs e)
        {
            groupContactComboBox.Items.Clear();
            bluerGrid.Visibility = Visibility.Visible;
            contactSV.Visibility = Visibility.Visible;
            nameContactAddTextBox.Text = name;
            surnameContactAddTextBox.Text = surname;
            patrContactAddTextBox.Text = patr;
            numberContactAddTextBox.Text = number;
            mailContactAddTextBox.Text = mail;
            if (birthday != "")
            {
                birthdayContactAddDatePicker.SelectedDate = Convert.ToDateTime(birthday);
            }
            else
            {
                birthdayContactAddDatePicker.SelectedDate = DateTime.Now;
            }
            List<Group> group = new List<Group>();
            group = interm.db.GetGroup("select distinct(nameGroup), count(nameGroup) from Contact where nameGroup != '' and idNotebook = " + id + " group by nameGroup");
            foreach (Group Group in group)
            {
                groupContactComboBox.Items.Add(Group.name);
            }
            groupContactComboBox.Items.Add("");
            groupContactComboBox.Text = nameGroup;
            commentContactAddTextBox.Text = comment;

            avatarContactAddImage.Source = new BitmapImage(new Uri(avatarContactImage.Source.ToString()));
            b = 1;
        }

        //Получение информации из ContactUC
        private void contactListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            interm.db.OutFromContactUC(out idContact, out name, out surname, out patr, out icon, out number, out mail, out birthday, out dateAdd, out nameGroup, out comment);
            groupContactTB.Text = nameGroup;
            dateAddContactTB.Text = dateAdd;
            if (comment == "")
            {
                commnetContactTB.Text = "-";
            }
            else
            {
                commnetContactTB.Text = comment;
            }
            if (birthday == "")
            {
                birthContactTB.Text = "-";
            }
            else
            {
                birthContactTB.Text = birthday;
            }
            if (mail == "")
            {
                mailContactTB.Text = "-";
            }
            else
            {
                mailContactTB.Text = mail;
            }

            try
            {
                avatarContactImage.Source = new BitmapImage(new Uri(icon));
            }
            catch
            {

                avatarContactImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
            }
            fioContactTB.Text = name + " " + surname + " " + patr;
            numberContactTB.Text = number;
            settingImage.IsEnabled = true;
            clearContactLog.IsEnabled = true;
            doCallImage.IsEnabled = true;
            ForOurConvers();
        }



        //Удаление записной книги
        private void deleteBook_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Уверены что хотите удалить?", "Проверка", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    interm.db.Ask("delete from Notebook where idNotebook = " + id);
                    Application.Current.MainWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }

        int b = 0;
        //Добавление или принятие изменений контакта
        private void acceptAddContactButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = birthdayContactAddDatePicker.SelectedDate.Value;
            if (b == 0)
            {
                Contact("insert into Contact values(" + id + ", N'" + nameContactAddTextBox.Text + "',N'" + surnameContactAddTextBox.Text + "', N'" +
                            patrContactAddTextBox.Text + "', N'" + FilePathContactAvatar + "', N'+" + numberContactAddTextBox.Text + "', N'" + mailContactAddTextBox.Text + "'," +
                            "'" + date.Month + "." + date.Day + "." + date.Year + "', SYSDATETIME(), N'" + groupContactComboBox.Text + "'," +
                            "N'" + commentContactAddTextBox.Text + "')",
                            "select * from Contact where number = '" + numberContactAddTextBox.Text + "' and idNotebook = " + id);
            }
            else
            {
                Contact("update Contact set name = N'" + nameContactAddTextBox.Text + "', surname = N'" + surnameContactAddTextBox.Text + "', patr = N'" +
                            patrContactAddTextBox.Text + "', icon = N'" + FilePathContactAvatar + "',number = N'+" + numberContactAddTextBox.Text + "', email = N'" + mailContactAddTextBox.Text + "'," +
                            "birthday = '" + date.Month + "." + date.Day + "." + date.Year + "', nameGroup =  N'" + groupContactComboBox.Text + "'," +
                            "comment = N'" + commentContactAddTextBox.Text + "' where idContact = " + idContact,
                            "select * from Contact where number = '" + numberContactAddTextBox.Text + "' and idNotebook = " + id + " and idContact != " + idContact);
            }
        }

        //Редактирование/добавление нового контаткта
        public void Contact(string Ask, string Check)
        {
            if (i == 0)
            {
                if (nameContactAddTextBox.Text.Replace(" ", "") != "" & numberContactAddTextBox.Text.Replace(" ", "") != "")
                {
                    bool check = interm.db.AskWithCheck(Ask, Check);
                    if (check == false)
                    {
                        bluerGrid.Visibility = Visibility.Hidden;
                        contactSV.Visibility = Visibility.Hidden;
                        nameContactAddTextBox.Text = "";
                        surnameContactAddTextBox.Text = "";
                        patrContactAddTextBox.Text = "";
                        numberContactAddTextBox.Text = "";
                        mailContactAddTextBox.Text = "";
                        groupContactComboBox.Text = "";
                        commentContactAddTextBox.Text = "";

                        avatarContactAddImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                        UpdateContact("select * from Contact where idNotebook = '" + id + "' and (name like N'%" + searchTextBox.Text + "%' or patr like N'%" + searchTextBox.Text + "%' or surname like N'%" + searchTextBox.Text + "%' or number like N'%" + searchTextBox.Text + "%')");
                    }
                    else
                    {
                        MessageBox.Show("Запись с такими данными уже существует.");
                    }
                }
                else
                {
                    MessageBox.Show("Не все требуемые поля заполнены.");
                    if (nameContactAddTextBox.Text.Replace(" ", "") == "")
                    {
                        nameContactAddRedLine.Visibility = Visibility.Visible;
                    }
                    if (numberContactAddTextBox.Text.Replace(" ", "") == "")
                    {
                        numberContactAddRedLine.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {

            }
        }

        //Импорт контактов, получение пути к файлу
        private void import_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FilePathSVG = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathSVG = openFileDialog.FileName;
            }

            if (FilePathSVG.Contains(".vcf"))
            {
                interm.db.ImportContact(FilePathSVG, id, out int Col);
                MessageBox.Show("Было добавлено " + Col + " новых контакта.");
            }
            else
            {
                MessageBox.Show("Выбран не верный формат файла.");
            }
            UpdateContact("select * from Contact where idNotebook = '" + id + "' and (name like N'%" + searchTextBox.Text + "%' or patr like N'%" + searchTextBox.Text + "%' or surname like N'%" + searchTextBox.Text + "%' or number like N'%" + searchTextBox.Text + "%')");
        }

        //Вывод на экран Grid с вводом почты для эскпорта
        private void export_MouseDown(object sender, MouseButtonEventArgs e)
        {
            exportContactStartGrid.Visibility = Visibility.Visible;
            menuGrid.Visibility = Visibility.Hidden;
            exportContactListBox.Items.Clear();
            List<Contact> cont = new List<Contact>();
            cont = interm.db.GetContact("select * from Contact where idNotebook = '" + id + "'");
            foreach (Contact Contact in cont)
            {
                ExportUC contact = new ExportUC();
                contact.id = Contact.id;
                contact.name = Contact.name;
                contact.surname = Contact.surname;
                contact.patr = Contact.patr;
                contact.fioContactTB.Text = Contact.name + " " + Contact.surname + " " + Contact.patr;

                try
                {
                    contact.avatarImage.Source = new BitmapImage(new Uri(Contact.icon));
                }
                catch
                {
                    contact.avatarImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                }
                contact.icon = Contact.icon;
                contact.number = Contact.number;
                contact.numberContactTB.Text = Contact.number;
                contact.mail = Contact.mail;
                contact.birthday = Contact.birthday;
                contact.dateAdd = Contact.dateAdd;
                changeNameGroupTextBox.Text = Contact.nameGroup;
                contact.nameGroup = Contact.nameGroup;
                contact.comment = Contact.comment;
                exportContactListBox.Items.Add(contact);
            }
        }

        //Экспорта контактов
        private void acceptExportButton_Click(object sender, RoutedEventArgs e)
        {
            interm.db.ExportContact(mailExportTextBox.Text, nameOwner, mailOwner);
            bluerGrid.Visibility = Visibility.Hidden;
            exportContactStartGrid.Visibility = Visibility.Hidden;
            exportContactFinishGrid.Visibility = Visibility.Hidden;
            mailExportTextBox.Text = "";
            interm.db.exportContact.Clear();
        }

        //Поиск группы
        private void searchGroupTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            searchGroupHideTextBox.Visibility = Visibility.Hidden;
            if (searchGroupTextBox.Text == "")
            {
                searchGroupHideTextBox.Visibility = Visibility.Visible;
                UpdateGroup("select distinct(nameGroup), count(nameGroup) from Contact where nameGroup != '' and idNotebook = " + id + " group by nameGroup");
            }
            else
            {
                UpdateGroup("select distinct(nameGroup), count(nameGroup) from Contact where nameGroup != '' and idNotebook = " + id + " and nameGroup like N'%" + searchGroupTextBox.Text + "%' group by nameGroup");
            }
        }

        //Обновление списка групп
        public void UpdateGroup(string Ask)
        {
            groupListBox.Items.Clear();
            List<Group> group = new List<Group>();
            group = interm.db.GetGroup(Ask);
            foreach (Group Group in group)
            {
                GroupUC gr = new GroupUC();
                gr.nameGroupTB.Text = Group.name;
                gr.countContGroupTB.Text = "Контактов в группе: " + Group.count;
                groupListBox.Items.Add(gr);
            }
        }

        string groupName;
        //Получение информации из GroupUC
        private void groupListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            interm.db.OutFromGroupUC(out groupName);
            if (groupName != "doorpe45")
            {
                groupGrid.Visibility = Visibility.Hidden;
                groupChangeGrid.Visibility = Visibility.Visible;
                UpdateContactGroup("select * from Contact where idNotebook = '" + id + "' and nameGroup = N'" + groupName + "'");
            }
        }

        //Обновление списка контактов в определённой группе
        public void UpdateContactGroup(string Ask)
        {
            groupChangeListBox.Items.Clear();
            List<Contact> cont = new List<Contact>();
            cont = interm.db.GetContact(Ask);
            foreach (Contact Contact in cont)
            {
                GroupContactUC contact = new GroupContactUC();
                contact.id = Contact.id;
                contact.name = Contact.name;
                contact.surname = Contact.surname;
                contact.patr = Contact.patr;
                contact.fioContactTB.Text = Contact.name + " " + Contact.surname + " " + Contact.patr;

                try
                {
                    contact.avatarImage.Source = new BitmapImage(new Uri(Contact.icon));
                }
                catch
                {
                    contact.avatarImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                }
                contact.icon = Contact.icon;
                contact.number = Contact.number;
                contact.numberContactTB.Text = Contact.number;
                contact.mail = Contact.mail;
                contact.birthday = Contact.birthday;
                contact.dateAdd = Contact.dateAdd;
                changeNameGroupTextBox.Text = Contact.nameGroup;
                contact.nameGroup = Contact.nameGroup;
                contact.comment = Contact.comment;
                groupChangeListBox.Items.Add(contact);
            }
        }

        //Удаление контактов из группы
        private void deleteFromGroupImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить из группы выбранные контакты(" + interm.db.exportContact.Count + ")? Если в группе всего " + interm.db.exportContact.Count + " контакта, она будет удалена.", "Проверка", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    interm.db.DeleteContactFromGroup(id);
                    MessageBox.Show("Из группы " + groupName + " удалено " + interm.db.exportContact.Count + " контактов.", "Проверка");
                    interm.db.exportContact.Clear();
                    UpdateContact("select * from Contact where idNotebook = '" + id + "' and (name like N'%" + searchTextBox.Text + "%' or patr like N'%" + searchTextBox.Text + "%' or surname like N'%" + searchTextBox.Text + "%' or number like N'%" + searchTextBox.Text + "%')");
                    UpdateContactGroup("select * from Contact where idNotebook = '" + id + "' and nameGroup = N'" + groupName + "'");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        //Получение контактов без группы
        public void UpdateContactWithoutGroup()
        {
            newGroupContactListBox.Items.Clear();
            List<Contact> cont = new List<Contact>();
            cont = interm.db.GetContact("select * from Contact where idNotebook = " + id + " and nameGroup = '' or nameGroup = NULL");
            foreach (Contact Contact in cont)
            {
                ExportUC adToGroup = new ExportUC();
                adToGroup.id = Contact.id;
                adToGroup.name = Contact.name;
                adToGroup.surname = Contact.surname;
                adToGroup.patr = Contact.patr;
                adToGroup.fioContactTB.Text = Contact.name + " " + Contact.surname + " " + Contact.patr;

                try
                {
                    adToGroup.avatarImage.Source = new BitmapImage(new Uri(Contact.icon));
                }
                catch
                {
                    adToGroup.avatarImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                }
                adToGroup.icon = Contact.icon;
                adToGroup.number = Contact.number;
                adToGroup.numberContactTB.Text = Contact.number;
                adToGroup.mail = Contact.mail;
                adToGroup.birthday = Contact.birthday;
                adToGroup.dateAdd = Contact.dateAdd;
                adToGroup.nameGroup = Contact.nameGroup;
                adToGroup.comment = Contact.comment;
                newGroupContactListBox.Items.Add(adToGroup);
            }
        }

        //Принятие изменений записной книги
        private void acceptChangeBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (changeNameBookTextBox.Text.Replace(" ", "") != "" & changeOwnerBookTextBox.Text.Replace(" ", "") != "" & changeMailBookTextBox.Text.Replace(" ", "") != "" & (changeMailBookTextBox.Text.Contains(".com") | changeMailBookTextBox.Text.Contains(".ru") | changeMailBookTextBox.Text.Contains(".by")))
            {
                bool check = interm.db.AskWithCheck
                     ("update Notebook set nameBook = N'" + changeNameBookTextBox.Text + "', nameOwner = N'" + changeOwnerBookTextBox.Text + "' " +
                     ",iconOwner = N'" + FilePathBookAvatar + "' ,emailOwner = N'" + changeMailBookTextBox.Text + "', password = N'" + changePasswordBookTextBox.Text + "'" +
                     " where idNotebook = " + id,
                     "select * from Notebook where nameBook = N'" + changeNameBookTextBox.Text + "' and idNotebook != " + id);
                if (check == false)
                {
                    nameBookTB.Text = changeNameBookTextBox.Text;
                    nameOwnerTB.Text = changeOwnerBookTextBox.Text;
                    mailOwner = changeMailBookTextBox.Text;
                    nameBook = changeNameBookTextBox.Text;
                    nameOwner = changeOwnerBookTextBox.Text;
                    password = changePasswordBookTextBox.Text;
                    changeNameBookTextBox.Text = "";
                    changeOwnerBookTextBox.Text = "";
                    changeMailBookTextBox.Text = "";

                    try
                    {
                        avatarBookImage.Source = new BitmapImage(new Uri(FilePathBookAvatar));
                    }
                    catch
                    {
                        avatarBookImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                    }
                    changeBookGrid.Visibility = Visibility.Hidden;
                    menuGrid.Visibility = Visibility.Visible;
                    changeMailBookRedLine.Visibility = Visibility.Hidden;
                    changeOwnerBookRedLine.Visibility = Visibility.Hidden;
                    changeNameBookRedLine.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Запись с такими данными уже существует.");
                }
            }
            else
            {
                MessageBox.Show("Не все требуемые поля заполнены корректно.");
                if (changeNameBookTextBox.Text.Replace(" ", "") == "")
                {
                    changeNameBookRedLine.Visibility = Visibility.Visible;
                }
                if (changeOwnerBookTextBox.Text.Replace(" ", "") == "")
                {
                    changeOwnerBookRedLine.Visibility = Visibility.Visible;
                }
                if (changeMailBookTextBox.Text.Replace(" ", "") == "")
                {
                    changeMailBookRedLine.Visibility = Visibility.Visible;
                }
                if (changePasswordBookTextBox.Text.Replace(" ", "") == "")
                {
                    changePasswordBookTextBox.Visibility = Visibility.Visible;
                }
            }
        }

        //Открытие ScrollViewer с добавлением контакта и заполнение списка групп
        private void createContact_MouseDown(object sender, MouseButtonEventArgs e)
        {
            menuGrid.Visibility = Visibility.Hidden;
            contactSV.Visibility = Visibility.Visible;
            groupContactComboBox.Items.Clear();
            birthdayContactAddDatePicker.SelectedDate = DateTime.Now;
            List<Group> group = new List<Group>();
            group = interm.db.GetGroup("select distinct(nameGroup), count(nameGroup) from Contact where nameGroup != '' and idNotebook = " + id + " group by nameGroup");
            foreach (Group Group in group)
            {
                groupContactComboBox.Items.Add(Group.name);
            }
            groupContactComboBox.Items.Add("");
            b = 0;
        }

        //
        public void GetCallLog(string Ask)
        {
            callLog.Items.Clear();
            List<Call> call = new List<Call>();
            call = interm.db.GetCallLog(Ask);
            foreach (Call Call in call)
            {
                LogUC log = new LogUC();
                log.dateCall.Text = Call.dateCall.Replace(".", "/");
                switch (Call.type)
                {
                    case "incoming":
                        if (Convert.ToDouble(Call.duration) < 60.0)
                        {
                            log.infoCall.Text = "Входящий вызов, 0 мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        else
                        {
                            log.infoCall.Text = "Входящий вызов, " + Convert.ToInt32(Convert.ToDouble(Call.duration) / 60.0) + " мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        log.picTypeCall.Source = new BitmapImage(new Uri("in.png", UriKind.Relative));
                        break;
                    case "outgoing":
                        if (Convert.ToDouble(Call.duration) < 60.0)
                        {
                            log.infoCall.Text = "Исходящий вызов, 0 мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        else
                        {
                            log.infoCall.Text = "Исходящий вызов, " + Convert.ToInt32(Convert.ToDouble(Call.duration) / 60.0) + " мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        log.picTypeCall.Source = new BitmapImage(new Uri("out.png", UriKind.Relative));
                        break;
                    case "missed":
                        log.infoCall.Text = "Пропущенный вызов.";
                        log.picTypeCall.Source = new BitmapImage(new Uri("miss.png", UriKind.Relative));
                        break;
                    default:
                        break;
                }
                callLog.Items.Add(log);
            }
        }

        //
        private void stat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            journalGrid.Visibility = Visibility.Visible;
            menuGrid.Visibility = Visibility.Hidden;
            GetJournal();
            GetStatJournal();
        }

        //
        public void GetStatJournal()
        {
            List<Call> call = new List<Call>();
            //
            call = interm.db.GetAllCallLog("select avg(DATEDIFF(second, timeStartCall, timeEndCall)), count(idCall), count(idCall),avg(DATEDIFF(second, timeStartCall, timeEndCall)), count(idCall)," +
                "avg(DATEDIFF(second, timeStartCall, timeEndCall)), count(idCall), Log.idContact " +
                " from Log, Contact where Contact.idContact = Log.idContact and type != 'missed' and idNotebook = " + id + " " + periodLog + " " + typeLog + " group by Log.idContact");
            foreach (Call Call in call)
            {
                try
                {
                    countCallTB.Text = "Всего вызовов: " + Call.count;
                    if (Convert.ToDouble(Call.duration) < 60.0)
                    {
                        avgDurationCallTB.Text = "Средняя продолжительность: 0 мин. " + (Convert.ToDouble(Call.avgDuration) % 60.0 - 2) + " сек. ";
                    }
                    else
                    {
                        avgDurationCallTB.Text = "Средняя продолжительность: " + Convert.ToInt32(Convert.ToDouble(Call.avgDuration) / 60.0) + " мин. " + Convert.ToDouble(Call.avgDuration) % 60.0 + " сек. ";
                    }
                    
                }
                catch
                {
                    avgDurationCallTB.Text = "Средняя продолжительность: 0 мин. 0 сек. ";

                }
            }
        }

        //
        public void GetJournal()
        {
            journalListBox.Items.Clear();
            //ЕСТЬ ВОПРОСЫ
            List<Call> call = new List<Call>();
            call = interm.db.GetAllCallLog("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type, name + ' ' + ISNULL(surname, '') + ' ' + ISNULL(patr, ''), number, number, number, Log.idContact " +
                "from Log, Contact where Contact.idContact = Log.idContact and idNotebook = " + id + " " + periodLog + " " + typeLog);
            foreach (Call Call in call)
            {
                AllLogUC log = new AllLogUC();
                log.dateCall.Text = Call.dateCall.Replace(".", "/");
                log.fioCall.Text = Call.fio;
                log.numberCall.Text = Call.number;
                log.idContact = Call.idContact;

                switch (Call.type)
                {
                    case "incoming":
                        if (Convert.ToDouble(Call.duration) < 60.0)
                        {
                            log.infoCall.Text = "Входящий вызов, 0 мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        else
                        {
                            log.infoCall.Text = "Входящий вызов, " + Convert.ToInt32(Convert.ToDouble(Call.duration) / 60.0) + " мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        log.picTypeCall.Source = new BitmapImage(new Uri("in.png", UriKind.Relative));
                        break;
                    case "outgoing":
                        if (Convert.ToDouble(Call.duration) < 60.0)
                        {
                            log.infoCall.Text = "Исходящий вызов, 0 мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        else
                        {
                            log.infoCall.Text = "Исходящий вызов, " + Convert.ToInt32(Convert.ToDouble(Call.duration) / 60.0) + " мин. " + (Convert.ToDouble(Call.duration) % 60.0 - 2.0) + " сек.";
                        }
                        log.picTypeCall.Source = new BitmapImage(new Uri("out.png", UriKind.Relative));
                        break;
                    case "missed":
                        log.infoCall.Text = "Пропущенный вызов.";
                        log.picTypeCall.Source = new BitmapImage(new Uri("miss.png", UriKind.Relative));
                        break;
                    default:
                        break;
                }
                journalListBox.Items.Add(log);
            }
        }

        string periodLog, typeLog = "";
        //
        private void typeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (typeComboBox.SelectedItem.ToString())
            {
                case "Все":
                    typeLog = "";
                    break;
                case "Входящие":
                    typeLog = " and type = 'incoming'  ";
                    break;
                case "Исходящие":
                    typeLog = " and type = 'outgoing' ";
                    break;
                case "Пропущенные":
                    typeLog = " and type = 'missed'  ";
                    break;
                default:
                    break;
            }
            GetJournal();
            GetStatJournal();
        }

        //
        private void periodComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (periodComboBox.SelectedItem.ToString())
            {
                case "За всё время":
                    periodLog = "";
                    break;
                case "За год":
                    periodLog = " and dateCall between (getdate() - 365) and getdate() and year(dateCall) = year(sysdatetime()) ";
                    startDatePicker.IsEnabled = false;
                    endDatePicker.IsEnabled = false;
                    break;
                case "За месяц":
                    periodLog = " and dateCall between (getdate() - 31) and getdate() and year(dateCall) = year(sysdatetime()) ";
                    startDatePicker.IsEnabled = false;
                    endDatePicker.IsEnabled = false;
                    break;
                case "За неделю":
                    periodLog = " and dateCall between (getdate() - 7) and getdate() and year(dateCall) = year(sysdatetime()) ";
                    startDatePicker.IsEnabled = false;
                    endDatePicker.IsEnabled = false;
                    break;
                case "За период":
                    periodLog = "";
                    startDatePicker.IsEnabled = true;
                    endDatePicker.IsEnabled = true;
                    break;
                default:
                    break;
            }
            GetJournal();
            GetStatJournal();
        }

        //
        private void startDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (endDatePicker.SelectedDate != null)
            {
                DateTime date = startDatePicker.SelectedDate.Value;
                DateTime date2 = endDatePicker.SelectedDate.Value;
                if (date > date2)
                {
                    MessageBox.Show("Период дат выбран не верно.");
                }
                else
                {
                    periodLog = " and dateCall between '" + date.Month + "." + date.Day + "." + date.Year + "' " +
                              "and '" + date2.Month + "." + date2.Day + "." + date2.Year + "' ";
                    GetJournal();
                    GetStatJournal();
                }
            }
        }

        //
        private void endDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (startDatePicker.SelectedDate != null)
            {
                DateTime date = startDatePicker.SelectedDate.Value;
                DateTime date2 = endDatePicker.SelectedDate.Value;
                if (date > date2)
                {
                    MessageBox.Show("Период дат выбран не верно.");
                }
                else
                {
                    periodLog = " and dateCall between '" + date.Month + "." + date.Day + "." + date.Year + "' " +
                                              "and '" + date2.Month + "." + date2.Day + "." + date2.Year + "' ";
                }
                GetJournal();
                GetStatJournal();
            }
        }

        //
        private void print_MouseDown(object sender, MouseButtonEventArgs e)
        {
            interm.db.PrintPlease(id);
        }

        //
        private void pechatJournal_Click(object sender, RoutedEventArgs e)
        {
            interm.db.PrintPleaseOneMoreTime("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type, name + ' ' + surname + ' ' + patr, number, number, number, number " +
                "from Log, Contact where Contact.idContact = Log.idContact and idNotebook = " + id + periodLog + typeLog);
        }

        //
        private void acceptChangeGroupButton_Click(object sender, RoutedEventArgs e)
        {
            //changeNameGroupTextBox
            if (changeNameGroupTextBox.Text.Replace(" ", "") != "")
            {
                interm.db.AskWithCheck("update Contact set nameGroup = '" + changeNameGroupTextBox.Text + "' where nameGroup = '" + groupName + "' and idNotebook = " + id
                    , "select * from Contact where nameGroup = '" + changeNameGroupTextBox.Text + "' and nameGroup != '" + groupName + "' and idNotebook = " + id);
            }
            else
            {
                MessageBox.Show("Не все поля поля заполнены корректно.");
            }
        }

        //
        private void acceptClear_MouseDown(object sender, RoutedEventArgs e)
        {
            if (clearCheckBox.IsChecked == true)
            {
                clearGrid.Visibility = Visibility.Hidden;
                bluerGrid.Visibility = Visibility.Hidden;
                interm.db.Ask("delete from Log where idContact =" + idContact + period + type);
                interm.db.Ask("update Notebook set areChecked = 'Не показывать' where idNotebook = " + id);
                GetCallLog("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type from Log where idContact = " + idContact + period + type);
                GetJournal();
                GetStatJournal();
            }
            else
            {
                clearGrid.Visibility = Visibility.Hidden;
                bluerGrid.Visibility = Visibility.Hidden;
                interm.db.Ask("delete from Log where idContact =" + idContact + period + type);
                GetCallLog("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type from Log where idContact = " + idContact + period + type);
                GetJournal();
                GetStatJournal();
            }
            UpadteInfoNotebook();
        }

        //
        public void UpadteInfoNotebook()
        {
            List<Notebooks> note = new List<Notebooks>();
            note = interm.db.GetNotebook("select * from Notebook where idNotebook = " + id);
            foreach (Notebooks Note in note)
            {
                areChecked = Note.areCheked;
            }
        }

        //
        private void startContactDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (endContactDatePicker.SelectedDate != null)
            {

                DateTime date = startContactDatePicker.SelectedDate.Value;
                DateTime date2 = endContactDatePicker.SelectedDate.Value;
                if (date > date2)
                {
                    MessageBox.Show("Период дат выбран не верно.");
                }
                else if (date == date2)
                {

                }
                else
                {
                    period = " and dateCall between '" + date.Month + "." + date.Day + "." + date.Year + "' " +
                              "and '" + date2.Month + "." + date2.Day + "." + date2.Year + "' ";
                    GetCallLog("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type from Log where idContact = " + idContact + period + type);
                }
            }
        }

        private void endContactDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (startContactDatePicker.SelectedDate != null)
            {
                DateTime date = startContactDatePicker.SelectedDate.Value;
                DateTime date2 = endContactDatePicker.SelectedDate.Value;
                if (date > date2)
                {
                    MessageBox.Show("Период дат выбран не верно.");
                }
                else if (date == date2)
                {

                }
                else
                {
                    period = " and dateCall between '" + date.Month + "." + date.Day + "." + date.Year + "' " +
                                              "and '" + date2.Month + "." + date2.Day + "." + date2.Year + "' ";
                }
                GetCallLog("select DATEDIFF(second, timeStartCall, timeEndCall), dateCall, type from Log where idContact = " + idContact + period + type);
            }
        }

        //
        private void journalListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            idContact = interm.db.GetFromAllLogUC();
            if (idContact != null)
            {
                bluerGrid.Visibility = Visibility.Hidden;
                journalGrid.Visibility = Visibility.Hidden;
                List<Contact> cont = new List<Contact>();
                cont = interm.db.GetContact("select * from Contact where idContact = '" + idContact + "'");
                foreach (Contact Cont in cont)
                {
                    groupContactTB.Text = Cont.nameGroup;
                    dateAddContactTB.Text = Cont.dateAdd;
                    if (Cont.comment == "")
                    {
                        commnetContactTB.Text = "-";
                    }
                    else
                    {
                        commnetContactTB.Text = Cont.comment;
                    }
                    if (Cont.birthday == "")
                    {
                        birthContactTB.Text = "-";
                    }
                    else
                    {
                        birthContactTB.Text = Cont.birthday;
                    }
                    if (Cont.mail == "")
                    {
                        mailContactTB.Text = "-";
                    }
                    else
                    {
                        mailContactTB.Text = Cont.mail;
                    }

                    try
                    {
                        avatarContactImage.Source = new BitmapImage(new Uri(Cont.icon));
                    }
                    catch
                    {
                        avatarContactImage.Source = new BitmapImage(new Uri("avatar.png", UriKind.Relative));
                    }
                    fioContactTB.Text = Cont.name + " " + Cont.surname + " " + Cont.patr;
                    numberContactTB.Text = Cont.number;
                    settingImage.IsEnabled = true;
                    clearContactLog.IsEnabled = true;
                    doCallImage.IsEnabled = true;
                    ForOurConvers();
                }
            }
        }
    }
}
