using Grpc.Core;
using Microsoft.Extensions.Options;
using Permission.RPC.API;
using Permission.Service.rpc.Entity;
using Permission.Service.rpc.impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Service.rpc
{
    public class RpcConfig : IRpcConfig
    {
        private static Server _server;
        private static IOptions<GrpcService> _grpcSettings;

        public RpcConfig(IOptions<GrpcService> grpcSettings)
        {
            _grpcSettings = grpcSettings;
        }
        public void Start()
        {
            _server = new Server
            {
                Services = { MsgService.BindService(new MsgServiceImpl()) },
                Ports = { new ServerPort(_grpcSettings.Value.IP, _grpcSettings.Value.Port, ServerCredentials.Insecure) }
            };
            _server.Start();

            Console.WriteLine($"Grpc ServerListening On Port {_grpcSettings.Value.Port}");
        }
    }
}