using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit
    {
        public int HostingUnitKey { get; set; }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        //private bool[,] diary = new bool[12, 31];
        [XmlIgnore]
        public bool[,] Diary { get; set; } 
        [XmlArray("Diary")]
        public bool[] DiaryDto
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12); }
        }
        public Enums.Area Area { get; set; }    //Vacation area
        public Enums.HostingUnitType HostingUnitType { get; set; }  //Type of host unit
        //public int NumOfAdults { get; set; }    //Number of adults
        //public int NumOfKids { get; set; }  //Number of children
        public bool Pool { get; set; } //Option for pool
        public bool Jacuzzi { get; set; }  //Option for jacuzzi
        public bool ChildrenAttractions { get; set; }  //Option for children attrections
        public bool Porch { get; set; }    //Option for porch
        public Enums.Food Food { get; set; }    //Option for food
        public int Beds { get; set; }   //Number of beds
        public override string ToString()
        {
            string Answer = "Hosting Unit Key: " + HostingUnitKey + ",\nOwner: " + Owner.FirstName + " "
                + Owner.LastName + ", \nHosting Unit Name:" + HostingUnitName + ", \nArea: " + Area +
                ", \nPool: " + Pool + ", \nJacuzzi: " + Jacuzzi + ", \nPorch: " + Porch + ", \nAttractions: " + ChildrenAttractions + ", \nFood: " + Food + "\n";
            return Answer;
        }
    }
}
