using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class LineOfCreditAccount : BankAccount
    {
        //If credit cart limit is 1000$ you can make your account balance negative up to 1000$ -->: base(name, initialBalance, "-creditLimit")
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        //For charge a fee when the withdrawal limit is exceeded
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
        isOverdrawn ? new Transaction(-20, DateTime.Now, "Apply overdraft fee") : default; 
        //اگر میزان پول منهای میزان برداشت از بالانس کرید کارت کوچکتر بود (یعنی حساب از لیمیتش منفی تر شده بود)
        //بیا برای هر برداشت 20$ هزینه اور درفت بگیر
    }
}
