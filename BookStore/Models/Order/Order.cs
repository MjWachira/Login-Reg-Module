using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string BookID { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
    }
}
