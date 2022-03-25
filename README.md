### Düzenli Bitcoin Alım Talimat Uygulaması

API 3 uç hazırlanmıştır. `Orders` ve `NotificationHistories` talimatların kayıtları ve yapılan işlemlerin bildirim geçmişi kaydedilmektedir.

- POST `/api/Orders`
- GET `/api/Orders/{id}`
- DELETE `/api/Orders/{id}`

## Hızlı kurulum için bağımlılıklar
- [Docker](https://www.docker.com/)
- [Git](https://git-scm.com/downloads)

## Hızlı Kurulum
- `git clone https://github.com/fatihgurdal/BtcTurk_Case.git`

-  `cd BtcTurk_Case.git`

- `docker-compose up`

-	http://localhost:12001 adresinde swagger karşılar.


## Kullanılan Teknoloji ve Kütüphaneler
**Framework:** .NET Core 6.0 ile ASPNET Web Api

**Database:** Postgre SQL

**ORM:** [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore "EntityFrameworkCore") & Mapping

**MediatR:** [MediatR](https://www.nuget.org/packages/MediatR)

**Message Queue:** [RabbitMQ](https://www.nuget.org/packages/RabbitMQ.Client/)

**Validation:** [FluentValidation](https://www.nuget.org/packages/FluentValidation.AspNetCore/)

**Dokümantasyon:** [Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger/ "Swagger")

