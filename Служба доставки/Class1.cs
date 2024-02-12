using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Служба_доставки
{
    enum status
    {
        получен,
        приготовить,
        готовиться,
        приготовленный,
        упаковывается,
        упакован,
        готов_к_выдачче,
        отдан_курьеру,
        передан_на_списание,
        списан,
        аннулирован
    }
    internal class Order
    {
        public int Number { get; set; }
        public DateTime Date_courier { get; set; }
        public courier Courier { get; set; }
        public status Status_order { get; set; }
    }
}
