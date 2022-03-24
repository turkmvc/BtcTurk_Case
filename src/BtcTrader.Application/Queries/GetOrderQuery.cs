using BtcTrader.Application.Responses;

using MediatR;

using System;

namespace BtcTrader.Application.Queries
{
    public class GetOrderQuery : IRequest<OrderDetailResponse>
    {
        /// <summary>
        /// Silinecek talimat numarası
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Talimatın sahibi
        /// </summary>
        public long UserId { get; set; }
    }
}
