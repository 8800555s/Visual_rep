using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ссылка на Api запрос
            string url = "https://api.icndb.com/jokes/random";
            string r;
            //Отправляем запрос на сервер для получения JSON ответа
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //Получаем ответ от сервера
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                r = streamReader.ReadToEnd();
            }
            //Получение Joke из поля JSON
            ValueJSON valueJSON = JsonConvert.DeserializeObject<ValueJSON>(r);
            Console.WriteLine("Шутка: {0}", valueJSON.Value.Joke);

            Console.ReadLine();

        }
    }
}
