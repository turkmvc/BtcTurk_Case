FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.14 as builder

WORKDIR /src

COPY ["src/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/EventBusRabbitMQ/"]
COPY ["src/BtcTrader.Domain/BtcTrader.Domain.csproj", "src/BtcTrader.Domain/"]
COPY ["src/BtcTrader.Infrastructure/BtcTrader.Infrastructure.csproj", "src/BtcTrader.Infrastructure/"]
COPY ["src/BtcTrader.Application/BtcTrader.Application.csproj", "src/BtcTrader.Application/"]
COPY ["src/BtcTrader.API/BtcTrader.API.csproj", "src/BtcTrader.API/"]


RUN dotnet restore "src/BtcTrader.API/BtcTrader.API.csproj"
COPY . .
WORKDIR "/src/src/BtcTrader.API"
RUN dotnet build "BtcTrader.API.csproj" -c Release -o /app/build

RUN dotnet publish "BtcTrader.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.14 as baseimage
WORKDIR /app
COPY --from=builder /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://*:5000

CMD [ "dotnet", "BtcTrader.API.dll" ]