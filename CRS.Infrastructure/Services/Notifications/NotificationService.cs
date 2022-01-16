using CRS.Core.Dtos;
using CRS.Infrastructure.Services.Notifications;
using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        public async Task<bool> SendByFCM(string token,NotificationDto dto)
        {
            try
            {
                var notification = new Message()
                {
                    Data = new Dictionary<string, string>()
                {
                    { "Title", dto.Title },
                    { "Body", dto.Body },
                    { "Action", dto.Action.ToString() },
                    { "ActionId", dto.ActionId },
                },
                    Token = token
                };

                 await FirebaseMessaging.DefaultInstance.SendAsync(notification);

                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

    }
}
