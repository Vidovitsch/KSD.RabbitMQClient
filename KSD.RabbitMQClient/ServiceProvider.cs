using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KSD.RabbitMQClient {

    public class ServiceProvider {

        private static HttpClient consumerClient = new HttpClient();
        private static HttpClient producerClient = new HttpClient();

        public Producer GetProducer() {

        }

        public Consumer GetConsumer() {

        }
    }
}
