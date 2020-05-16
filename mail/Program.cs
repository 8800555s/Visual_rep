using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace mail
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите свою почту");
            string p = Console.ReadLine();
            Console.WriteLine("Ваше имя");
            string n = Console.ReadLine();
            MailAddress from = new MailAddress(p,n);

            Console.WriteLine("Введите почту получателя");
            string m = Console.ReadLine();
            MailAddress to = new MailAddress(m);


            using (MailMessage k = new MailMessage(from, to))
            using (SmtpClient smtp = new SmtpClient())
            {
                Console.WriteLine("Введите тему сообщения");
                k.Subject = Console.ReadLine();
                Console.WriteLine("Введите текст сообщения");
                k.Body = Console.ReadLine();
                k.IsBodyHtml = true;

                smtp.Host = "smtp.yandex.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                Console.WriteLine("Пароль от вашей почты");
                string b = Console.ReadLine();
                smtp.Credentials = new NetworkCredential(p, b);
                smtp.Send(k);
            }
            Console.Read();
        }
    }
}
