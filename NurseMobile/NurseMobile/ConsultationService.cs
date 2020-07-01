using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NurseMobile
{
    public class ConsultationService
    {
        const string Url = "http://nurse-mobile-app.superms.ru/api/web/constultations";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем все консультации
        public async Task<IEnumerable<Consultation>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Consultation>>(result);
        }

        public async Task<Consultation> Update(Consultation consultation)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + consultation.Id, new StringContent(JsonConvert.SerializeObject(consultation), Encoding.UTF8, "application/json"));
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Consultation>(await response.Content.ReadAsStringAsync());

        }

    }
}
