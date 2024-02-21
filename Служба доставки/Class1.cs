using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS
{

  public  enum status
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
  public     class Zacas 
    {
        int a;
       public int Number { get; set; }
        public DateTime Date_courier { get; set; }
        public DateTime Time_Statys { get; set; }
        public DateTime Time_Priem { get; set; }
     public           courier Courier { get; set; }
      public    status Status_order { get; set; }
         


    }
}
