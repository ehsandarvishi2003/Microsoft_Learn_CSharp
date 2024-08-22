using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

public class BankAccount
{
    private static int s_accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
        set
        {
            value=Balance;
        }
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    private readonly decimal _minimumBalance;

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);//پولی که داری منهای پولی که برمیداری کوچیکتر از مینیمون بالانس حسابته ؟
        Transaction? withdrawal = new(-amount, date, note);
        _allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
            _allTransactions.Add(overdraftTransaction);
    }

    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)//چک کردن مجاز بودن برداشت یک مقدار پول
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        else
        {
            return default;//چون متدی که توش هستیم از نوع ترنزاکشن ناایبل هستش مفهوم ریتورن دیفالت مقدار نال هستش null
        }
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }

    public virtual void PerformMonthEndTransactions() { }

    public BankAccount(string name, decimal initialBalance): this(name, initialBalance, 0)
    {
        Owner = name;

        //When you create a bank account object using the constructor, you will see a name input and a money amount input. 
        //This method in the constructor causes this money to be added to your account balance.
        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");//--> Balance = initialBalance;

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        _minimumBalance = minimumBalance;
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");

        Owner = name;

        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

}
