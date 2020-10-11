using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey { get; set; }    //Unique ID for hosting request
        public string FirstName { get; set; }  //Guest private name
        public string LastName { get; set; }  //Guest family name
        public string Email { get; set; }   //Guest mail address
        public Enums.RequirementStatus RequirementStatus { get; set; }  //Hosting Request Status
        public DateTime RegistrationDate { get; set; }  //System registration date
        public DateTime EntryDate { get; set; }    //Entry date
        public DateTime ReleaseDate { get; set; }   //Release Date
        public Enums.Area Area { get; set; }    //Vacation area
        public Enums.HostingUnitType HostingUnitType { get; set; }  //Type of host unit
        public int NumOfAdults { get; set; }    //Number of adults
        public int NumOfKids { get; set; }  //Number of children
        public Enums.Options Pool { get; set; } //Option for pool
        public Enums.Options Jacuzzi { get; set; }  //Option for jacuzzi
        public Enums.Options ChildrenAttractions { get; set; }  //Option for children attrections
        public Enums.Options Porch { get; set; }    //Option for porch
        public Enums.Food Food { get; set; }    //Option for food
        public int NumOfTotalPeople { get; set; }
        public override string ToString()
        {
            string Answer = "Last Name: " + LastName + ", \nFirst Name: " + FirstName + ", \nEmail Address: " + Email + ", \nOrder Number: " + GuestRequestKey + ", \nRegistration Date: " + RegistrationDate.ToString("dd/MM/yyyy") + ", \nEntry Date: " + EntryDate.ToString("dd/MM/yyyy") + ", \nRelease Date: " + ReleaseDate.ToString("dd/MM/yyyy") +
                ", \nHosting Unit Type: " + HostingUnitType + ", \nArea: " + Area + ", \nClient Requirement Status: " + RequirementStatus + ",\nNum Of Adults: " + NumOfAdults + ", \nNum Of Kids: " + NumOfKids +
                ", \nPool: " + Pool + ", \nJacuzzi: " + Jacuzzi + ", \nPorch: " + Porch + ", \nAttractions: " + ChildrenAttractions + ", \nFood: " + Food + "\n";
            return Answer;
        }
    }
}
