using System;
using System.Text.RegularExpressions;

namespace BootTelegram.Domain.Entities
{
    public class Reading: Entity
    {
        public Reading() { }

        public Reading(Guid grupoid, DateTime dateTimeMessage, string message, string messageId, string shippingType)
        {
            GroupId = grupoid;
            DateTimeMessage = dateTimeMessage;
            Message = message;
            MessageId = messageId;
            ShippingType = shippingType;
        }
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public DateTime DateTimeMessage { get; set; }
        public string Message { get; set; }
        public string MessageId { get; set; }
        public string ShippingType { get; set; }
    }
}