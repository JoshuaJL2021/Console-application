using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            OrderHistories = new HashSet<OrderHistory>();
            Stocks = new HashSet<Stock>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
