using Microsoft.AspNetCore.SignalR;
using SignalRTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRTest
{
    public class CountHub:Hub
    {
        private readonly CountService _countService;

        public CountHub(CountService countService)
        {
            _countService = countService;
        }

        public async Task GetLatestCount(string random)
        {
            int count;
            do
            {
                count = _countService.GetLatestCount();
                Thread.Sleep(1000);

                await Clients.All.SendAsync("ReceiveUpdate", count);
            } while (count<10);

            await Clients.All.SendAsync("Finished");

        }

        public override async Task OnConnectedAsync()
        {
            //var clientId=Context.ConnectionId;
            //await Clients.Client(clientId).SendAsync("someFunc", new { });
            //await Clients.AllExcept(clientId).SendAsync("someFunc", new { random = "32323" });

            //await Groups.AddToGroupAsync(clientId, "MyGroup");
            //await Groups.RemoveFromGroupAsync(clientId, "MyGroup");

            //await Clients.Groups("MyGroup").SendAsync("someFunc",new { random="7564"});

            //await base.OnConnectedAsync();
        }
    }
}
