using CRS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS.Infrastructure.Services.Notifications
{
    public interface INotificationService
    {
        Task<bool> SendByFCM(string token, NotificationDto dto);
    }
}
