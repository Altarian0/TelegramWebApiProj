using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramWebApiProj.Models;
using Telegram.Bot;
using Newtonsoft.Json;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using TelegramWebApiProj.Models;
using System.Linq;
using System.Collections.Generic;

namespace TelegramWebApiProj.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        //private readonly TelegramBotClient _telegramBotClient;
        //public MessageController(TelegramBot telegramBot)
        //{
        //    //_telegramBotClient = telegramBot.GetTelegramBot().Result;
        //    telegramBot.GetTelegramBot().Wait();
        //}

        private OrderContext db;
        public MessageController(OrderContext context)
        {
            db = context;
        }
        //List<ExtendedOrder> extendedOrders = db.ExtendedOrders.ToList();
        Models.User user = new Models.User();

        TelegramBotClient botClient = new TelegramBotClient("5289996800:AAEjRMLLvhmA67f-hBUTKUQ1v43qEi7kOFQ");
        Message sentMessage = null;
        long chatId = 0;

        [HttpPost]
        public async Task Update([FromBody] object obj)
        {
            // /start => register user

            Update update = JsonConvert.DeserializeObject<Update>(obj.ToString());

            if (update.Message != null)
            {
                chatId = update.Message.Chat.Id;
                user.ChatId = (int)chatId;
                db.Users.Add(user);
                db.SaveChanges();
            }
            if (update.CallbackQuery != null)
            {
                //        SendOrderForServerAsync(update);
                //    }
                //    return Ok();
                //}

                //public async Task SendOrderForServerAsync(Update update)
                //{
                List<Models.User> users = db.Users.ToList();
                List<ExtendedOrder> extendedOrders = db.ExtendedOrders.ToList();
                foreach (var user in users)
                {
                    foreach (var item in extendedOrders)
                    {
                        if (item.IsAccept == null)
                        {
                            if (update.CallbackQuery.Data == $"{item.OrderNumber} Принят")
                            {
                                //user.IsAccept = true;
                                await botClient.SendTextMessageAsync(
                                chatId: user.ChatId,
                                text: $"Заказ номер {item.OrderNumber} принят на обработку"
                                );

                                await botClient.EditMessageReplyMarkupAsync(
                                    chatId: user.ChatId,
                                    messageId: (int)item.MessageId
                                    );
                            }
                            if (update.CallbackQuery.Data == $"{item.OrderNumber} Отклонён")
                            {

                                item.IsAccept = false;
                                await botClient.SendTextMessageAsync(
                                chatId: user.ChatId,
                                text: $"Заказ номер {item.OrderNumber} отклонён"
                                );
                                await botClient.EditMessageReplyMarkupAsync(
                                    chatId: user.ChatId,
                                    messageId: (int)item.MessageId
                                );
                            }
                        }
                    }
                }
            }
        }
    }
}