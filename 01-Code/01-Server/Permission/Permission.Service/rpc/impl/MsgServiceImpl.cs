using Grpc.Core;
using Permission.rpc.api;
using Permission.RPC.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Service.rpc.impl
{
    public class MsgServiceImpl : MsgService.MsgServiceBase
    {
        public override Task<GetMsgSumReply> GetSum(GetMsgNumRequest request, ServerCallContext context)
        {
            var result = new GetMsgSumReply();

            result.Sum = request.Num1 + request.Num2;

            Console.WriteLine(request.Num1 + "+" + request.Num2 + "=" + result.Sum);

            return Task.FromResult(result);
        }
    }
}