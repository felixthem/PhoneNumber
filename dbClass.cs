using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Моя_телефонная_книга
{
    class dbClass
    {
        static string sqlExpression = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\PhoneBook.mdf';Integrated Security=True";
        SqlConnection connection = new SqlConnection(sqlExpression);
        public List<Contact> exportContact = new List<Contact>();

        //
        public DataTable UpdateTable(string sqlExpression)
        {
            SqlCommand myCommand = new SqlCommand(sqlExpression, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(myCommand);
            connection.Open();
            DataTable cont = new DataTable();
            dataAdapter.Fill(cont);
            connection.Close();
            return cont;
        }

        //Запрос к базе данных, без возврата значений
        public void Ask(string Ask)
        {
            SqlCommand command = new SqlCommand(Ask, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        //Получение информации о записных книгах из БД
        public List<Notebooks> GetNotebook(string Ask)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(Ask, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Notebooks> notes = new List<Notebooks>();
            while (reader.Read())
            {
                notes.Add(new Notebooks()
                {
                    id = Convert.ToString(reader.GetValue(0)),
                    nameBook = Convert.ToString(reader.GetValue(1)),
                    nameOwner = Convert.ToString(reader.GetValue(2)),
                    dateCreate = Convert.ToString(reader.GetValue(3)),
                    iconOwner = Convert.ToString(reader.GetValue(4)),
                    mailOwner = Convert.ToString(reader.GetValue(5)),
                    password = Convert.ToString(reader.GetValue(6)),
                    areCheked = Convert.ToString(reader.GetValue(7))
                });
            }
            connection.Close();
            return notes;
        }

        string id, name, surname, patr, icon, number, mail, birthday, dateAdd, nameGroup, comment;
        //Получение информации из ContactUC
        public void GetFromContactUC(string Id, string Name, string Surname, string Patr, string Icon, string Number, string Mail, string Birthday, string DateAdd, string NameGroup, string Comment)
        {
            id = Id;
            name = Name;
            surname = Surname;
            patr = Patr;
            icon = Icon;
            number = Number;
            mail = Mail;
            birthday = Birthday;
            dateAdd = DateAdd;
            nameGroup = NameGroup;
            comment = Comment;
        }

        //Передача информации о контакте на MenuWindow
        public void OutFromContactUC(out string Id, out string Name, out string Surname, out string Patr, out string Icon, out string Number, out string Mail, out string Birthday, out string DateAdd, out string NameGroup, out string Comment)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patr = patr;
            Icon = icon;
            Number = number;
            Mail = mail;
            Birthday = birthday;
            DateAdd = dateAdd;
            NameGroup = nameGroup;
            Comment = comment;
        }

        //Получение информации о контактах из БД
        public List<Contact> GetContact(string Ask)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(Ask, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Contact> contact = new List<Contact>();
            while (reader.Read())
            {
                contact.Add(new Contact()
                {
                    id = Convert.ToString(reader.GetValue(0)),
                    name = Convert.ToString(reader.GetValue(2)),
                    surname = Convert.ToString(reader.GetValue(3)),
                    patr = Convert.ToString(reader.GetValue(4)),
                    icon = Convert.ToString(reader.GetValue(5)),
                    number = Convert.ToString(reader.GetValue(6)),
                    mail = Convert.ToString(reader.GetValue(7)),
                    birthday = Convert.ToString(reader.GetValue(8)),
                    dateAdd = Convert.ToString(reader.GetValue(9)),
                    nameGroup = Convert.ToString(reader.GetValue(10)),
                    comment = Convert.ToString(reader.GetValue(11))
                });
            }
            connection.Close();
            return contact;
        }

        //Запрос к базе данных с получением ответа о том, имеется ли уже такая запись
        public bool AskWithCheck(string Ask, string Check)
        {
            bool check;
            connection.Open();
            SqlCommand command = new SqlCommand(Check, connection);
            SqlDataReader reader = command.ExecuteReader();
            check = reader.Read();
            reader.Close();
            if (check != true)
            {
                SqlCommand command2 = new SqlCommand(Ask, connection);
                command2.ExecuteNonQuery();
            }
            connection.Close();
            return check;
        }

        //Импорт контактов
        public void ImportContact(string Path, string Id, out int Col)
        {
            int check = 0;
            Col = 0;
            using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("FN:"))
                    {
                        if (line.Contains("FN:Contacts+ Support"))
                        {
                            check = 0;
                        }
                        else
                        {
                            name = line.Replace("FN:", "");
                            check++;
                        }
                    }
                    if (line.Contains("CATEGORIES:"))
                    {
                        nameGroup = line.Replace("CATEGORIES:", "");
                        check++;
                    }
                    if (line.Contains("TEL;TYPE=CELL:"))
                    {
                        check++;
                        number = line.Replace("TEL;TYPE=CELL:", "");
                    }
                    if (check == 3)
                    {
                        bool tr = AskWithCheck("insert into Contact(idNotebook, name, number, icon, dateAdd, nameGroup) values(" + Id + ", N'" + name + "',N'" + number + "'," +
                            @"N'C:\Users\Жмых\source\repos\Моя телефонная книга\Picture\avatar.png',SYSDATETIME(),N'" + nameGroup + "')",
                            "select * from Contact where number = N'" + number + "' and idNoteBook = '" + Id + "'");
                        if (tr == false) Col++;
                        check = 0;
                    }
                }
            }
        }

        //Экспорт контактов
        public void ExportContact(string MailTo, string OwnerName, string MailBack)
        {
            using (StreamWriter sw = new StreamWriter("Export.vcf", false, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                foreach (Contact Contact in exportContact)
                {
                    sw.WriteLine("BEGIN:VCARD");
                    sw.WriteLine("VERSION:3.0");
                    sw.WriteLine("FN:" + Contact.name);
                    sw.WriteLine("N:;" + Contact.name + ";;;");
                    sw.WriteLine("TEL;TYPE=CELL:" + Contact.number);
                    sw.WriteLine("CATEGORIES:" + Contact.nameGroup);
                    sw.WriteLine("END:VCARD");
                }
                sw.Close();
            }
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("diplom.proyekt@bk.ru", OwnerName);
                // кому отправляем
                MailAddress to = new MailAddress(MailTo);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Экспорт контактов";
                // текст письма
                m.Body = "<h2>Экспорт контактов осуществлён при помощи приложения 'Моя телефонная книга', почта для обратной связи: " + MailBack + "</h2>";
                m.Attachments.Add(new Attachment("Export.vcf"));
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("diplom.proyekt@bk.ru", "lbgkjvysqghjtrn");
                smtp.EnableSsl = true;
                smtp.Send(m);
                m.Dispose();
                smtp.Dispose();
                exportContact.Clear();
                System.Windows.MessageBox.Show("Данныю успешно отправлены.");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            File.Delete("Export.vcf");
        }

        //Получение информации о группах из БД
        public List<Group> GetGroup(string Ask)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(Ask, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Group> group = new List<Group>();
            while (reader.Read())
            {
                group.Add(new Group()
                {
                    name = Convert.ToString(reader.GetValue(0)),
                    count = Convert.ToString(reader.GetValue(1))

                });
            }
            connection.Close();
            return group;
        }

        //Получение информации из ContactUC
        public void GetFromGroupUC(string NameGroup)
        {
            nameGroup = NameGroup;
        }

        //Передача информации о контакте на MenuWindow
        public void OutFromGroupUC(out string NameGroup)
        {

            NameGroup = nameGroup;
        }

        //Удаление контактов из группы
        public void DeleteContactFromGroup(string Id)
        {
            foreach (Contact Contact in exportContact)
            {
                Ask("update Contact set nameGroup = '' where idNotebook = " + Id + " and number = '" + Contact.number + "'");
            }
        }

        //Добавление контаков в группу
        public int AddContactToGroup(string Id, string groupName)
        {
            int i = 0;
            foreach (Contact Contact in exportContact)
            {
                Ask("update Contact set nameGroup = N'" + groupName + "' where idNotebook = " + Id + " and number = '" + Contact.number + "'");
                i++;
            }
            return i;
        }

        //
        public List<Call> GetCallLog(string Ask)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(Ask, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Call> call = new List<Call>();
            while (reader.Read())
            {
                call.Add(new Call()
                {
                    duration = Convert.ToString(reader.GetValue(0)),
                    dateCall = Convert.ToString(reader.GetValue(1)),
                    type = Convert.ToString(reader.GetValue(2))
                });
            }
            connection.Close();
            return call;
        }

        //
        public double[] GetDouble(string Ask)
        {
            double[] data = new double[] { 1, 1, 1 };
            connection.Open();
            SqlCommand command = new SqlCommand(Ask + " and type = 'incoming' ", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data[0] = Convert.ToDouble(reader.GetValue(0));
            }
            reader.Close();
            SqlCommand command1 = new SqlCommand(Ask + " and type = 'outgoing' ", connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                data[1] = Convert.ToDouble(reader1.GetValue(0));
            }
            reader1.Close();
            SqlCommand command2 = new SqlCommand(Ask + " and type = 'missed' ", connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                data[2] = Convert.ToDouble(reader2.GetValue(0));
            }
            reader2.Close();
            connection.Close();
            return data;
        }

        //
        public List<Call> GetAllCallLog(string Ask)
        {
            List<Call> call = new List<Call>();
            connection.Open();
            SqlCommand command = new SqlCommand(Ask, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                call.Add(new Call()
                {

                    duration = Convert.ToString(reader.GetValue(0)),
                    dateCall = Convert.ToString(reader.GetValue(1)),
                    type = Convert.ToString(reader.GetValue(2)),
                    fio = Convert.ToString(reader.GetValue(3)),
                    number = Convert.ToString(reader.GetValue(4)),
                    avgDuration = Convert.ToString(reader.GetValue(5)),
                    count = Convert.ToString(reader.GetValue(6)),
                    idContact = Convert.ToString(reader.GetValue(7))
                });
            }
            connection.Close();
            return call;
        }

        public void PrintPlease(string idNotebook)
        {
            List<Contact> cont = new List<Contact>();
            cont = GetContact("select * from Contact where idNotebook = " + idNotebook);
            using (StreamWriter sw = new StreamWriter("forPrint.txt", false, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                sw.WriteLine("СПИСОК КОНТАКТОВ ИЗ ЗАПИСНОЙ КНИГИ\n");
                sw.WriteLine("--------------------------------------------------------------------------------\n");
                foreach (Contact Contact in cont)
                {
                    sw.WriteLine("  ID:" + Contact.id + "  ФИО:" + Contact.name + " " + Contact.surname + " " + Contact.patr + "   Номер:" + Contact.number + "\n");
                    sw.WriteLine("--------------------------------------------------------------------------------\n");
                }
            }
            using (var pd = new PrintDialog())
            {
                pd.ShowDialog();
                var info = new ProcessStartInfo()
                {
                    Verb = "print",
                    CreateNoWindow = true,
                    FileName = @"forPrint.txt",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(info);
            }
        }

        public void PrintPleaseOneMoreTime(string Ask)
        {
            List<Call> call = new List<Call>();
            call = GetAllCallLog(Ask);
            using (StreamWriter sw = new StreamWriter("forPrintTwo.txt", false, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                sw.WriteLine("Журнал звонков\n");
                sw.WriteLine("--------------------------------------------------------------------------------\n");
                foreach (Call Call in call)
                {
                    sw.WriteLine("\n  ФИО:" + Call.fio + "\n  Номер:" + Call.number + "\n  Дата:" + Call.dateCall + "\n  Длительность:"
                        + Call.dateCall + "\n  Тип:" + Call.type + "\n");
                    sw.WriteLine("--------------------------------------------------------------------------------\n");
                }
            }
            using (var pd = new PrintDialog())
            {
                pd.ShowDialog();
                var info = new ProcessStartInfo()
                {
                    Verb = "print",
                    CreateNoWindow = true,
                    FileName = @"forPrintTwo.txt",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(info);
            }
        }

        string idContact;
        //
        public void OutFromAllLogUc(string id)
        {
            idContact = id;
        }

        //
        public string GetFromAllLogUC()
        {
            return idContact;
        }
    }

    class Notebooks
    {
        public string id { get; set; }
        public string nameBook { get; set; }
        public string nameOwner { get; set; }
        public string dateCreate { get; set; }
        public string iconOwner { get; set; }
        public string mailOwner { get; set; }
        public string password { get; set; }
        public string areCheked { get; set; }
    }

    class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patr { get; set; }
        public string icon { get; set; }
        public string number { get; set; }
        public string mail { get; set; }
        public string birthday { get; set; }
        public string dateAdd { get; set; }
        public string nameGroup { get; set; }
        public string comment { get; set; }
    }

    class Group
    {
        public string name { get; set; }
        public string count { get; set; }
    }

    class Call
    {
        public string duration { get; set; }
        public string dateCall { get; set; }
        public string type { get; set; }
        public string fio { get; set; }
        public string number { get; set; }
        public string avgDuration { get; set; }
        public string count { get; set; }
        public string idContact { get; set; }
    }
}
