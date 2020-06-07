using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NurseMobile
{
    class NursesService
    {
        const string Url = "http://nurse-mobile-app.superms.ru/api/web/nurse-employees";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        // получаем всех медсестер
        public async Task<IEnumerable<Nurse>> Get()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Nurse>>(result);
        }

        // добавляем одного друга
        public async Task<Nurse> Add(Nurse nurse)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(nurse),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Nurse>(
                await response.Content.ReadAsStringAsync());
        }
        // обновляем друга
        public async Task<Nurse> Update(Nurse nurse)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + nurse.Id,
                new StringContent(
                    JsonConvert.SerializeObject(nurse),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Nurse>(
                await response.Content.ReadAsStringAsync());
        }
        // удаляем друга
        public async Task<Nurse> Delete(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Nurse>(
               await response.Content.ReadAsStringAsync());
        }

    }
}
