using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class OrdersRecord
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
    }
}
