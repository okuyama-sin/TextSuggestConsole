using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace TextSuggestConsoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("文字を入力してください。");

            for (; ; )
            {
                string talk = Console.ReadLine();
                if (talk == "end") break;
                string baseUrl = "https://api.a3rt.recruit-tech.co.jp/text_suggest/v2/predict?apikey=（取得したAPIKey）";

                string url = $"{baseUrl}&previous_description={talk}";
                string json = new HttpClient().GetStringAsync(url).Result;

                JObject jobj = JObject.Parse(json);

                string[] reply = new string[3];

                for (int i = 0; i < 3; i++)
                {
                    reply[i] = (string)jobj["suggestion"][i];
                    Console.WriteLine(reply[i]);
                }

            }
        }
    }
}