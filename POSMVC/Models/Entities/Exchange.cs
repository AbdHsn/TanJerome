using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Exchange
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ReturnId { get; set; }
        public long? OrderId { get; set; }
        public string ExchangeNo { get; set; }
        public DateTime? ExchangeDate { get; set; }
        public string Status { get; set; }
        public long? ExchangBy { get; set; }
    }
}
