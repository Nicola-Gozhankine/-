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
      public  string имя;
      public  string фамилия;
         public string отчество;
             public string полное_имя;
             public string полный_список_заказа;
             


    }

    public class Status
    {

        public string tecstat;
        public DateTime vremz_ystanovki;
        public int num;
        public enum status
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
      public    Status Status_order { get; set; }
        public Заказчик заказчик { get; set; }
         


    }
}
