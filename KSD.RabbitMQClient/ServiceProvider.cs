using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace KSD.RabbitMQClient {

    public class ServiceProvider {

        private static HttpClient producerClient = null;
        private static HttpClient consumerClient = null;

        private string username;
        private string password;
        public ServiceProvider(string username, string password) {

        }

        public Producer GetProducer(string vhost, string exchange, string host, string port = "15672") {
            Uri url = new Uri(new StringBuilder().AppendFormat("http://{0}:{1}/api/exchanges/{2}/{3}/publish", host, port, vhost, exchange).ToString());
            if (producerClient == null || producerClient.BaseAddress.ToString().Equals(url.ToString())) {
                producerClient.BaseAddress = url;
            }
            return new Producer(producerClient);
        }

        public Consumer GetConsumer() {
            // To Do
            return null;
        }
    }
}
