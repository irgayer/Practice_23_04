using DL.DataAccess;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Console
{
    public class MyMail
    {
        private List<Receiver> receivers;

        public void Run()
        {
            receivers = new List<Receiver>();

            using(var repository = new ReceiversRepository())
            {
                receivers = (List<Receiver>)repository.GetAll();
            }
            MainMenu();
        }

        private void MainMenu()
        {
            string mailTheme, mailText, receiverMail;
            System.Console.WriteLine("Приложение для отправки письма.");
            System.Console.WriteLine("version 1.0.0\n");
            while (true)
            {
                System.Console.WriteLine("Введите тему : ");
                mailTheme = System.Console.ReadLine();
                System.Console.WriteLine("Введите текст : ");
                mailText = System.Console.ReadLine();
                foreach(var receiver in receivers)
                {
                    receiver.Print();
                    System.Console.WriteLine();
                }
                System.Console.WriteLine("Введите адресс получателя :");
                receiverMail = System.Console.ReadLine();

                if(receivers.Where(r => r.Id.ToString() == receiverMail) != null)
                {
                    using(var repository = new MailRepository())
                    {
                        repository.Add(new Mail
                        {
                            Theme = mailTheme,
                            Text = mailText,
                            ReceiverId = Guid.Parse(receiverMail)
                        });
                        System.Console.WriteLine("Письмо отправлено!");
                    }
                }
                else
                {
                    System.Console.WriteLine("Такого получателя нет!");
                }
            }
        }
    }
}
