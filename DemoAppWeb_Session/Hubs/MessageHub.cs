﻿using DemoAppWeb_Session.Attributes;
using DemoAppWeb_Session.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DemoAppWeb_Session.Hubs
{
    public class MessageHub : Hub
    {
        public void NewMessage(string message)
        {
            Clients.All.SendAsync("Message", message);
        }

        // qd qqun se connecte 
        public override Task OnConnectedAsync()
        {
            // on déclenche un événement appelé NouvelleConnexion qui fournira l'id de connection de la personne qui vient de se connecter
            Clients.All.SendAsync("NouvelleConnexion", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
