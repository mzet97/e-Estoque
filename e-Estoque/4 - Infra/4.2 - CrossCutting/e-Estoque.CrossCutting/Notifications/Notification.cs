using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.CrossCutting.Notifications
{
    public class Notification
    {
        public string message { get; }
        public NotificationType Type { get; }

        public Notification(string message, NotificationType type)
        {
            this.message = message;
            Type = type;
        }

    }
}
