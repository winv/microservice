﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permission.GrpcService.Hosting.Consul.Entity
{
    public class HealthService
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }

    }
}
