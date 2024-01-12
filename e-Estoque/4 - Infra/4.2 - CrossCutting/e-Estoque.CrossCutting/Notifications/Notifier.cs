namespace e_Estoque.CrossCutting.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetAll()
        {
            return _notifications;
        }

        public List<Notification> GetTrace()
        {
            return _notifications.Where(x => x.Type == NotificationType.TRACE).ToList();
        }

        public List<Notification> GetDebug()
        {
            return _notifications.Where(x => x.Type == NotificationType.DEBUG).ToList();
        }

        public List<Notification> GetInfo()
        {
            return _notifications.Where(x => x.Type == NotificationType.INFO).ToList();
        }

        public List<Notification> GetWarning()
        {
            return _notifications.Where(x => x.Type == NotificationType.WARNING).ToList();
        }

        public List<Notification> GetError()
        {
            return _notifications.Where(x => x.Type == NotificationType.ERROR).ToList();
        }

        public List<Notification> GetFatal()
        {
            return _notifications.Where(x => x.Type == NotificationType.FATAL).ToList();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void Handle(string message, NotificationType type)
        {
            _notifications.Add(new Notification(message, type));
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public bool HasTrace()
        {
            return _notifications.Any(x => x.Type == NotificationType.TRACE);
        }

        public bool HasDebug()
        {
            return _notifications.Any(x => x.Type == NotificationType.DEBUG);
        }

        public bool HasInfo()
        {
            return _notifications.Any(x => x.Type == NotificationType.INFO);
        }

        public bool HasWarning()
        {
            return _notifications.Any(x => x.Type == NotificationType.WARNING);
        }

        public bool HasError()
        {
            return _notifications.Any(x => x.Type == NotificationType.ERROR);
        }

        public bool HasFatal()
        {
            return _notifications.Any(x => x.Type == NotificationType.FATAL);
        }
    }
}