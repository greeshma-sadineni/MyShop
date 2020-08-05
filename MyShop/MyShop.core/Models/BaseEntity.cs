using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.core.Models
{
    public class BaseEntity
    {
        public string Id { set; get; }
        public DateTimeOffset CreatedAt { set; get; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;

        }
    }
}
