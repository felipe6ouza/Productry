using Flunt.Notifications;

namespace Productry.Bussiness.Models
{
    public abstract class Entity :  Notifiable<Notification>
    {
        public int Id { get; private set; }
    }
}