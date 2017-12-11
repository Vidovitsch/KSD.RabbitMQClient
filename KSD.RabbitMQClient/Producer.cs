using KSD.RabbitMQClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KSD.RabbitMQClient {

    public class Producer {

        private HttpClient http;
        private string routingKey;
        private object payload;

        public Producer(HttpClient http) {
            this.http = http;
        }

        public async Task<string> ProduceAsync(string username, string password, string routingKey, object payload) {
            // Create JSON-object from payload
            string jsonPayload = JsonConvert.SerializeObject(payload);
            RabbitMQBody rabbitMQBody = CreateBody(routingKey, jsonPayload);

            // Create JSON-object from RabbitMQBody instance and stringify
            string jsonBody = JsonConvert.SerializeObject(rabbitMQBody);
            StringContent stringContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(username, password);
            HttpResponseMessage response = await http.PostAsync("", stringContent);

            return await response.Content.ReadAsStringAsync();
        }

        private RabbitMQBody CreateBody(string routingKey, object payload) {
            return new RabbitMQBody() {
                properties = new Dictionary<string, object>(),
                routing_key = routingKey,
                payload = payload,
                payload_encoding = "string"
            };
        }
    }
}
