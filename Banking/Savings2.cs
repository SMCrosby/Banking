using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace Banking {
    //Example using Composition instead of inheritance        

    class Savings2 {

        public Account Account  { get; private set; } = null;         //An instance of Account that can be referenced (must be referenced when not using inheritance)
        public double InterestRate { get; private set; } = 0.01;        //can only set from savings2 class

        //All allowed the same name because the parameters put in are all different
        public static bool Transfer(double amount, Savings2 FromAccount, Account ToAccount) {
            return Account.Transfer(amount, FromAccount.Account, ToAccount);
        }
        public static bool Transfer(double amount, Account FromAccount, Savings2 ToAccount) {
            return Account.Transfer(amount, FromAccount, ToAccount.Account);
        }
        public static bool Transfer(double amount, Savings2 FromAccount, Savings2 ToAccount) {
            return Account.Transfer(amount, FromAccount.Account, ToAccount.Account);
        }

        public void Print() {
            Console.WriteLine($"IntRate: {InterestRate}, Desc: {Account.Description}, Bal: {Account.Balance}");
        }

        public double Deposit(double amount) {
            return this.Account.Deposit(amount);        //call a method that's in a class and return what that method returns

        }
        public double Withdraw(double amount) {
            return this.Account.Withdraw(amount);

        }
        //public static bool Transfer(double amuont, Account FromAccount, Account ToAccount) {

        //}


        public double PayInterest(int months) {
            var interest = this.CalculateInterest(months);
            Account.Deposit(interest);
            return interest;
        }
            
        public double CalculateInterest(int months) {
            return this.Account.Balance * (this.InterestRate / 12) * months;        
                //Balance is in Account. must use Account property to access it thus Account.Balance
        }


        //Create constructors
        public Savings2(double intRate, string Description) {
            this.Account = new Account(Description);
            this.InterestRate = intRate;
        }
        public Savings2(string Description) {
            this.Account = new Account(Description);
        }


        public Savings2() {
            this.Account = new Account();           //createing account instance and using default constructor?
        }


        

    }
}
