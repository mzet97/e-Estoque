using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Estoque.CrossCutting.Notifications
{
    public interface INotifier
    {
        void Handle(Notification notification);
        void Handle(string message, NotificationType type);

        bool HasNotification();
        bool HasTrace();
        bool HasDebug();
        bool HasInfo();
        bool HasWarning();
        bool HasError();
        bool HasFatal();

        List<Notification> GetAll();
        List<Notification> GetTrace();
        List<Notification> GetDebug();
        List<Notification> GetInfo();
        List<Notification> GetWarning();
        List<Notification> GetError();
        List<Notification> GetFatal();

    }
}
