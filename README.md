Программа CRUD Web API для работы с мероприятиями
========================
Функционал:
-------------------------
1. Получение списка всех событий
    "GET" https://localhost:7221/api/Activities
-------------------------
2. Получение списка событий на ближайшую неделю от указанной даты

    Request Headers: "datetime" = "2022-04-30" (указать необходимую дату)

    "GET" https://localhost:7221/api/Activities

-------------------------
3. Получение списка событий по определенному организатору

    Request Headers: "organizer" = "Me" (указать организатора)

    "GET" https://localhost:7221/api/Activities

-------------------------

4. Получение определенного события по его id

    "GET" https://localhost:7221/api/Activities/id (указать id)
    
-------------------------
5. Регистрация нового события

   body:  "name": "take a walk",
   
          "Description": "I like walk",
          
          "Organizer": "Me",
          
          "EventTime": "2022-04-27T13:00",
          
          "EventVenue": "Mogilev"
          
          "POST" https://localhost:7221/api/Activities

-------------------------
6. Изменение информации о существующем событии
   body:  "id": 1,
   
          "name": "Bike",
          
          "Description": "Buy a bike",
          
          "Organizer": "Me",
          
          "EventTime": "2022-04-28T17:00",
          
          "EventVenue": "Mogilev"
          
          "PUT" https://localhost:7221/api/Activities/1 (id в теле и в url должны быть одинаковые)
          
-------------------------
7. Удаление события

      "DELETE" https://localhost:7221/api/Activities/id
  
-------------------------

Информация о событии:
-------------------------
1. Id
2. Название/Тема
3. Организатор
4. Время проведения
5. Место проведения

-------------------------

Для старта программы нужно предварительно настроить appsettings.json:
 
 "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=eventsdb;Username=postgres;Password=12345"
  }

Port - Порт базы данных Postgresql.

Username - Указать имя пользователя базы данных.

Password - указать пароль к базе данных если он есть.

Во время работы программы создастся новая база данных с именем "eventsdb"
