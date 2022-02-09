namespace TelegramWebApiProj.Models
{
    public class ExtendedOrder : Order
    {
        public bool? IsAccept { get; set; }
        public int? MessageId { get; set; }
    }
}
