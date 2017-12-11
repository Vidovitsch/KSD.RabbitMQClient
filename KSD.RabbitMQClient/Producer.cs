using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public Producer(string routingKey, object payload) {
            this.routingKey = routingKey;
            this.payload = payload;
        }

        public async Task<string> ProduceAsync(string routingKey, object payload) {

        }
    }
}
