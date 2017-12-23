using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProcTask
{
    class Program
    {
        static void Main(string[] args)
        {
            char id = Console.ReadKey().KeyChar;
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(string.Format("http://kodaday.intita.com/api/task/{0}", id));
            request.Headers.Add("X-API-KEY: S95Xczjx");

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            Data data = new Data();
            data = JsonConvert.DeserializeObject<Data>(responseFromServer);

            ProcessorsList processorsList = new ProcessorsList();
            
            ProcessorsHelper.InitProcessors(data.processors, processorsList);

            int[] outArray = new int[data.tasks.Length];
            ProcessorsHelper.AddTasks(data.tasks, processorsList, ref outArray);

            


            HttpWebRequest request2 =
                (HttpWebRequest)WebRequest.Create(string.Format("http://kodaday.intita.com/api/task/{0}", id));
            request2.Headers.Add("X-API-KEY: S95Xczjx");
            request2.Method = "POST";
            var stream = request2.GetRequestStream();
            var writer = new StreamWriter(stream);
            writer.Write(JsonConvert.SerializeObject(outArray));
            writer.Flush();
            writer.Close();
            stream.Close();
            WebResponse response2 = request2.GetResponse();


            Console.WriteLine(response2);
            
        }

        
    }
}
