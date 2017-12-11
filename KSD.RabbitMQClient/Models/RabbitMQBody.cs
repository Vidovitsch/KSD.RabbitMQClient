using System;
using System.Collections.Generic;
using System.Text;

namespace KSD.RabbitMQClient.Models {

    public class RabbitMQBody {

        public object properties { get; set; }

        public string routing_key { get; set; }
        
        public object payload { get; set; }

        public string payload_encoding { get; set; }
    }
}
