using MediatR;

using System;

namespace BtcTrader.Application.Queries
{
    public class DeleteOrderQuery : IRequest
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
