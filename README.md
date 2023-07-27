# Koks-PM-V3
> ### Планируемый функционал приложения:
- [x] 1. Создание аккаунта
- [x] 2. Создание заметок
- [x] 3. Создание заметок-карточек
- [x] 4. Создание категорий
- [x] 5. Редактирование аккаунта
- [x] 6. Редактирование заметок
- [x] 7. Редактирование заметок-карточек
- [x] 8. Редактирование категорий
- [ ] 9. Удаление аккаунта
- [x] 10. Удаление заметок
- [x] 11. Удаление заметок-карточек
- [x] 12. Удаление категорий
- [x] 13. AES шифрование заметок, карточек-заметок, категорий
- [x] 14. Поиск и фильтрация заметок
- [x] 15. Хэширование
- [x] 16. Сохранение в БД
- [x] 17. Сохранение TOTP
- [x] 18. Использование Telegram API для оповещений
- [x] 19. Генерация паролей
- [x] 20. Логгирование
- [x] 21. Резервные копии заметок
- [ ] 22. Сохранение авторизации при выходе из приложения

(список будет пополняться или убавляться в зависимости от планов разработки)

> ### Принипы, фреймворки, библиотеки используемые в проекте:

| Номер | Библиотека/Приницп |
|--------:|-|
|1.| MVVM |
|2.| EntityFramework |
|3.| LINQ |
|4.| Async/Await |
|5.| Task/Thread |
|6.| Dependency Injection |
|7.| Depemdency Injection Containers |
|8.| SOLID |
|9.| xUnit |
|10.| Moq |
|11.| Extension methods |
|12.| log4net/SeriLog/или другой |
|13.| DevExpressMVVM |
|14.| SymmetricEncryptor |
|15.| KoksTotp2FA |
|16.| KoksTelegramBot |
|17.| LenghtTruncateConverter |
|18.| HashingModule |
|19.| WPF |
|20.| SimpleModal WPF |
|21.| MahApps Metro Icon Pack |


> ### Обозначение тегов коммитов:
* #### `[Feature]` -  это реализованная новая функциональность из технического задания.
* #### `[UI]` - добавил новый элемент интерфейса или изменил старый элемент интерфейса.
* #### `[Fix]` - исправил ошибку в ранее реализованной функциональности.
* #### `[Refactor]` - полностью переработал метод, класс, оставив основную суть, но разбив на разные методы и тд.
* #### `[Test]` - написал новый Unit тест или изменил существующий Unit тест.

