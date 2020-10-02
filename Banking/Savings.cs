using System;
using System.Collections.Generic;
using System.Text;

namespace Banking {
    //Using inheritance

    class Savings : Account 
    {
        public double InterestRate { get; protected set; } = 0.01;  //default sets to 1% if not declared otherwise

        public double PayInterest(int months) {
            var interest = this.CalculateInterest(months);
            Deposit(interest);
            return (interest);
        }

        public double CalculateInterest(int months) {
            return this.Balance * (this.InterestRate / 12) * months;
        }   //Balance is inherited from account so can be accesed with this.
               

        public Savings(double intRate, string description) : base(description) {
            this.InterestRate = intRate;

        }
        public Savings(string description) : base(description) {                                              //base points to inherited class

        }
        public Savings() : base() { }           //calls upon default constructor of Account

    }
}
