using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;

namespace WebApplication111.Controllers.SignalRHub
{
    public class CommentsHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task OnConnectedGroup(string groupId)
        {
            await this.Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            await base.OnConnectedAsync();
        }

        public async Task SendComment(Comment comment, string groupId)
        {
            await this.Clients.OthersInGroup(groupId).SendAsync("ApplyComment", comment);
        }
    }
}
