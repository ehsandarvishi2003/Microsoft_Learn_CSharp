using Classes;
namespace Introduction_to_classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Banck Account

            var account = new BankAccount("Ehsan", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");//Toke 500$
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");//Add 100$
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());

            #endregion

            #region Other accounts

            var giftCard = new GiftCardAccount("gift card", 100, 50);//It's called a gift card, now there is $100 in it, and $50 is going to be added every month
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");//برداشت
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");//برداشت
            giftCard.PerformMonthEndTransactions();//Add monthly deposit
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);//ایجاد حساب سرمایه گذاری یا پس انداز
            savings.MakeDeposit(750, DateTime.Now, "save some money");//add
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");//add
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");//برداشت
            savings.PerformMonthEndTransactions();//اگر حسابش بالای 500$ داشته باشه سود 2% بهش تعلق میگیره
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0,0);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");//برداشت
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");//پرداخت
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");//برداشت
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");//پرداخت
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());

            #endregion
        }
    }
}
