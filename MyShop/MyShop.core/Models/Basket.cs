using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.core.Models
{
    public class Basket : BaseEntity
    {
        public virtual ICollection<BasketItem> BasketItems { set; get; }

        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
