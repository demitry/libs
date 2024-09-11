# Source

https://github.com/MassTransit/Sample-GettingStarted?tab=readme-ov-file#install-rabbitmq

```
mkdir GettingStarted
dotnet new worker -n GettingStarted
```

```
cd GettingStarted
dotnet add package MassTransit.AspNetCore
```

dotnet run

dotnet add package MassTransit.RabbitMQ

docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq