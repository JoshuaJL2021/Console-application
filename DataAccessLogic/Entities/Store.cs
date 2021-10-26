using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLogic.Entities
{
    public partial class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Location { get; set; }
    }
}
