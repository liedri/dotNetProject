using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Enums
    {
        public enum HostingUnitType { All, Zimmer, Apartment, Hotel, Camp}; //Type of host unit
        public enum Area { All, North, South, Center, Jerusalem};   //Vacation area
        public enum OrderStatus { NotYetAddressed, EmailSent, ClientDidntRespond, CloseByClient };  //Order status
        public enum RequirementStatus { Open, DealMade, DealExpires};   //Hosting Request Status
        public enum Options { Necessary, Optional, NotInterested }; //Option
        public enum Food { All, Breakfast, Lunch, Dinner };  //Option for food
    }
}
