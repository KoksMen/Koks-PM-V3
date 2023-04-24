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
        changePasswordInfo = 1,
        loginInfo = 2,
        telegramAddUpdateInfo = 3,
        totpAddUpdateInfo = 4,
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
                case messageType.changePasswordInfo:
                    {
                        this.messageText = "Оповещение безопасности, в вашем аккаунте был изменён пароль.";
                        break;
                    }
                case messageType.loginInfo:
                    {
                        this.messageText = "Оповещение безопасности, в ваш аккаунт был произведён вход.";
                        break;
                    }
                case messageType.telegramAddUpdateInfo:
                    {
                        this.messageText = "Информационное оповещение, телеграмм бот успешно связан с аккаунтом.";
                        break;
                    }
                case messageType.totpAddUpdateInfo:
                    {
                        this.messageText = "Оповещение безопасности, на вашем аккаунте была добавлена/изменена двухфакторная авторизация.";
                        break;
                    }
            }
            sendTelegramNotification();
        }

        private async Task sendTelegramNotification()
        {
            CancellationToken cancellationToken = new CancellationToken();

            var botClient = new TelegramBotClient(telegramBotToken);

            Message message = await botClient.SendTextMessageAsync(
                    chatId: chatID,
                    text: messageText,
                    cancellationToken: cancellationToken);
        }
    }

    
}
