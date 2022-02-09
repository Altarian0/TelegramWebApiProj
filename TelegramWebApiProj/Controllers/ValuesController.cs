using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramWebApiProj.Models;

namespace TelegramWebApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        TelegramBotClient botClient = new TelegramBotClient("5289996800:AAEjRMLLvhmA67f-hBUTKUQ1v43qEi7kOFQ");

        private OrderContext db;
        public ValuesController(OrderContext context)
        {
            db = context;
        }
        Message sentMessage = null;

        [HttpPost]
        public async Task CreateDescriptionForTelegram(Order order)
        {
            var deserializeOrder = JsonConvert.DeserializeObject<Order>(order.ToString());
            ExtendedOrder extendedOrder = new ExtendedOrder();
            extendedOrder.Id = deserializeOrder.Id;
            extendedOrder.OrderNumber = deserializeOrder.OrderNumber;
            extendedOrder.Amount = deserializeOrder.Amount;
            extendedOrder.PhoneNumber = deserializeOrder.PhoneNumber;

        //    SendOrderForUserAsync(extendedOrder);
        //    //db.ExtendedOrders.Add(extendedOrder);
        //    //await db.SaveChangesAsync();
        //}

        //public async Task SendOrderForUserAsync(ExtendedOrder extendedOrder)
        //{
            InlineKeyboardMarkup inlineKeyboard = new InlineKeyboardMarkup(
                // first row
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData(text: "Принять", callbackData: $"{extendedOrder.OrderNumber} Принят"),
                    InlineKeyboardButton.WithCallbackData(text: "Отклонить", callbackData: $"{extendedOrder.OrderNumber} Отклонён"),
                });

            string orderText = extendedOrder.OrderNumber + "\n" + extendedOrder.PhoneNumber + "\n" + extendedOrder.Amount;

            if (extendedOrder.IsAccept == null && extendedOrder.MessageId == null)
            {
                sentMessage = await botClient.SendTextMessageAsync(
                        chatId: 541041424,
                        text: orderText,
                        replyMarkup: inlineKeyboard
                        );
                extendedOrder.MessageId = sentMessage.MessageId;
                db.ExtendedOrders.Add(extendedOrder);
                await db.SaveChangesAsync();
            }
        }
    }
}
