using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS;

namespace VS
{
    public class  Заказчик
    {
        string имя;
        string фамилия;
         string отчество;
             string полное_имя;
             string полный_список_заказа;
             


    }

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
        public void  ZacasNS() 
        {

         courier courierL = new courier();
            Заказчик заказчик = new Заказчик();
            
        }
        int a;
       public int Number { get; set; }
        public DateTime Date_courier { get; set; }
        public DateTime Time_Statys { get; set; }
        public DateTime Time_Priem { get; set; }
        public DateTime Время_брибытия_Курьера  { get; set; }
        public           courier courierL { get; set; }
      public    status Status_order { get; set; }
        public Заказчик заказчик { get; set; }
         


    }
}
