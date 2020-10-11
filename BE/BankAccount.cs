using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankAccount
    {
        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }
        public int BankAccountNumber { get; set; }

        public BankAccount(int bankNumber, string bankName, int branchNumber, string branchAddress, string branchCity, int bankAccountNumber)
        {
            BankNumber = bankNumber;
            BankName = bankName;
            BranchNumber = branchNumber;
            BranchAddress = branchAddress;
            BranchCity = branchCity;
            BankAccountNumber = bankAccountNumber;
        }
        public override string ToString()
        {
            string Answer = "Bank Number: " + BankNumber + ", Bank Name: " + BankName + ", Branch Number: " + BranchNumber + ", Branch Address: " +
                BranchAddress + ", Branch City: " + BranchCity + ", Bank Account Number: " + BankAccountNumber;
            return Answer;
        }
    }
}
