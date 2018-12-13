using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BasicBot.QnA
{
    public class QnAService
    {
        private string key;
        private string kb;

        public QnAService(string key, string kb)
        {
            this.key = key;
            this.kb = kb;
        }

        public async Task<QnAResult> GetAnswers(string question, int top)
        {
            string service = "/qnamaker";
            string method = "/knowledgebases/" + kb + "/generateAnswer/";
            string host = "https://netcurriculum.azurewebsites.net";
            var uri = host + service + method;
            var body = $"{{'question': '{question}', 'top': {top}}}";

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", "EndpointKey " + key);


                var response = await client.SendAsync(request);
                return JsonConvert.DeserializeObject<QnAResult>(await response.Content.ReadAsStringAsync());
            }
        }
    }

    public class QnAResult
    {

        public AnswerResult[] Answers { get; set; }

        public class AnswerResult
        {
            public string[] Questions { get; set; }
            public string Answer { get; set; }
            public float Score { get; set; }
            public int Id { get; set; }
            public string Source { get; set; }
            public Metadata[] Metadata { get; set; }
        }

        public class Metadata
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

    }
}
