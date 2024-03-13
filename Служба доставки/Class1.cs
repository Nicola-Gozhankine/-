using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS;

namespace VS
{

   
    public class DarkYellow
        {

        public Color darkYellow = Color.FromArgb(255, 204, 0);
    }
    public class Роль
    {
        public bool Повар  ;
            public bool Администратор  ;// специальная роль для Арсентия 
            public bool Менеджер  ;
            public bool Упаковшик  ;
    }
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
           передан_на_кухню,
           принят_кухней, 
           приготовить,
           готовиться,
           приготовленный,
           передан_на_упаковку,
           упаковывается,
           упакован,
           готов_к_выдаче,
           отдан_курьеру,
           выполнен,
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
         public Блюда блюда { get; set; }
        public List<Блюда> CollectionБлюдаZ { get; set; } 
        // public List<Блюда> CollectionБлюда1 = VS.Блюда.C;


    }
}
