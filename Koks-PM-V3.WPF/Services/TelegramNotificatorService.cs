using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Koks_PM_V3.WPF.Services
{
    public enum messageType
    {
        editPasswordInfo = 1,
        loginInfo = 2,
        telegramAddInfo = 3,
        telegramEditDeleteInfo = 4,
        totpAddInfo = 5,
        totpEditDeleteInfo = 6,
    }

    public class TelegramNotificatorService
    {
        private readonly string chatID;
        private readonly string telegramBotToken;
        private readonly string messageText;

        public TelegramNotificatorService(string chatID, string telegramBotToken, messageType messageType)
        {
            this.chatID = chatID;
            this.telegramBotToken = telegramBotToken;
            switch (messageType)
            {
                case messageType.editPasswordInfo:
                    {
                        this.messageText = "Оповещение безопасности, в вашем аккаунте был изменён пароль.";
                        break;
                    }
                case messageType.loginInfo:
                    {
                        this.messageText = "Оповещение безопасности, в ваш аккаунт был произведён вход.";
                        break;
                    }
                case messageType.telegramAddInfo:
                    {
                        this.messageText = "Оповещение безопасности, на вашем аккаунте была добавлена привязка Telegram.";
                        break;
                    }
                case messageType.telegramEditDeleteInfo:
                    {
                        this.messageText = "Оповещение безопасности, на вашем аккаунте была изменена/удалена привязка Telegram.";
                        break;
                    }
                case messageType.totpAddInfo:
                    {
                        this.messageText = "Оповещение безопасности, на вашем аккаунте была добавлена двухфакторная авторизация.";
                        break;
                    }
                case messageType.totpEditDeleteInfo:
                    {
                        this.messageText = "Оповещение безопасности, на вашем аккаунте была добавлена двухфакторная авторизация.";
                        break;
                    }
                
            }
        }

        public async Task sendTelegramNotification()
        {
            CancellationToken cancellationToken = new CancellationToken();

            var botClient = new TelegramBotClient(telegramBotToken);

            Message message = await botClient.SendTextMessageAsync(
                    chatId: chatID,
                    text: messageText,
                    cancellationToken: cancellationToken);

            if (message == null)
            {
                throw new ArgumentException("ChatID or BotApi is wrong");
            }
        }

    }

    
}
