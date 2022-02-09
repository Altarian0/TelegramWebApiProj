using System;

namespace TelegramWebApiProj.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор заказчика
        /// </summary>
        //public Guid CustomerId { get; private set; }
        /// <summary>
        /// Имя заказчика
        /// </summary>
        //public string CustomerName { get; private set; }
        /// <summary>
        /// Номер телефона заказчика
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Идентификатор партнера
        /// </summary>
        //public Guid PartnerId { get; private set; }
        /// <summary>
        /// Наименование партнера
        /// </summary>
        //public string PartnerName { get; private set; }
        /// <summary>
        /// Идентификатор курьера
        /// </summary>
        //public Guid? CourierId { get; private set; }
        /// <summary>
        /// Стоимость заказа
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Стоимость доставки
        /// </summary>
        //public decimal DeliveryCost { get; private set; }
        /// <summary>
        /// Значение скидки
        /// </summary>
        //public decimal Discount { get; set; }
        /// <summary>
        /// Номер заказа
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        //public string Comment { get; private set; }
        /// <summary>
        /// Дата и время создания заказа
        /// </summary>
        //public DateTime CreateDateTime { get; private set; }
        /// <summary>
        /// Дата и время доставки
        /// </summary>
        //public DateTime? DeliveredDateTime { get; private set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        //public OrderStatuses Status { get; private set; }
        /// <summary>
        /// Категория рынка
        /// </summary>
        //public MarketCategories MarketCategory { get; private set; }
        /// <summary>
        /// Адрес доставки
        /// </summary>
        //public string DeliveryAddress { get; private set; }
        /// <summary>
        /// Идентификатор города доставки
        /// </summary>
        //public Guid DeliveryCityId { get; private set; }
        /// <summary>
        /// Время к которому нужно доставить
        /// </summary>
        //public TimeSpan? DeliverAtTime { get; private set; }
        /// <summary>
        /// Количество столовых приборов
        /// </summary>
        //public int CutleryQuantity { get; private set; }
        /// <summary>
        /// Содержимое заказа сериализованное в json
        /// </summary>
        //public string Content { get; set; }
        /// <summary>
        /// Статус указывающий отправленность нового заказа в телеграм
        /// </summary>
        //public bool IsSend { get; private set; }
        /// <summary>
        /// Наличие у партнера доступа к админ панели
        /// </summary>
        //public bool HasAdminPanel { get; private set; }
        /// <summary>
        /// Способ оплаты
        /// </summary>
        //public OrderPaymentMethods PaymentMethod { get; private set; }
        /// <summary>
        /// Подробный адрес доставки
        /// </summary>
        //public DeliveryLocation DeliveryLocation { get; set; }

        /// <summary>
        /// Конечная стоимость заказа с учетом доставки и скидки
        /// </summary>
        //public decimal TotalAmount => (Amount + DeliveryCost) - Discount;
    }
}
