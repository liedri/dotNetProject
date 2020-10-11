using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        public int HostKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public BankBranch BankBranchDetails{ get; set; }
        public int BankAccountNumber { get; set; }
        public bool CollectionClearance { get; set; }
        public int NumOfHostingUnits { get; set; }
        public int HostPassword { get; set; }
        public override string ToString()
        {
            string Answer = "Host Key: " + HostKey + ", \nFirst Name: " + FirstName + ", \nLast Name: " + LastName + ", \nPhone Number: " + PhoneNumber +
                ", \nEmail Address: " + Email + /*BankBranchDetails.ToString() + */", \nBank Account Number: " + BankAccountNumber + ", \nCollection Clearance: " + CollectionClearance;
            return Answer;
        }
    }
}
