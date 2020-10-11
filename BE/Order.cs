using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey { get; set; }
        public int GuestRequestKey { get; set; }
        public int OrderKey { get; set; }
        public Enums.OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime OrderDate { get; set; }
        public override string ToString()
        {
            string Answer = "Hosting Unit Key: " + HostingUnitKey + ", \nGuest Request Key: " + GuestRequestKey + ", \nOrder Key: " + OrderKey +
                ", \nStatus: " + Status + ", \nCreate Date: " + CreateDate.ToString("dd/MM/yyyy") + ", \nOrder Date: " + OrderDate.ToString("dd/MM/yyyy") + " \n";
            return Answer;
        }
    }
}
