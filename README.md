# Решение тестовое задания удаленный C# / ASP.NET разработчик
 
 ## Как запустить проект
Запусть проект можно как локально так и в докере. Для запуска локально необходимо в `appsettings.json` вставить в `ConnectionString` свою строку подключения к СУБД MSSQL.

### DOTNET CLI
Для запуска Api
``` bash
dotnet run --project ./src/Presentation/Cloupard.Api/
```

Для запуска MVC
``` bash
dotnet run --project ./src/Presentation/Cloupard.MVC
```

### DOCKER COMPOSE
Для запуска через `docker-compose.yml`

Для запуска

``` bash
docker-compose up --build -d
```

Для закрытия контейнеров

``` bash
docker-compose down
```
