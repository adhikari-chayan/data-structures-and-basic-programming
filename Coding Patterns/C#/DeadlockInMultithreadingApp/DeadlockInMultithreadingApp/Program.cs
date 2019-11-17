using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadlockInMultithreadingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");
            Account accountA = new Account(101, 5000);
            Account accountB = new Account(102,3000);

            AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            Thread T1 = new Thread(accountManagerA.Transfer);
            T1.Name = "T1";

            AccountManager accountManagerB = new AccountManager(accountB, accountA, 1000);
            Thread T2 = new Thread(accountManagerB.Transfer);
            T2.Name = "T2";


            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();

            Console.WriteLine("Main Completed");
            Console.ReadKey();
        }
    }

    public class Account
    {
        double _balance;
        int _id;

        public Account(int id,double balance)
        {
            _id = id;
            _balance = balance;
        }

        public int ID
        {
            get { return _id; }
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }
    }

    public class AccountManager
    {
        Account _fromAccount;
        Account _toAccount;
        double _amountToTransfer;

        public AccountManager(Account fromAccount,Account toAccount, double amountToTransfer)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amountToTransfer = amountToTransfer;
        }
      
        public void Transfer()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " trying to acquire lock on " + _fromAccount.ID.ToString());
            lock (_fromAccount)
            {
                Console.WriteLine(Thread.CurrentThread.Name
                + " acquired lock on "
                + _fromAccount.ID.ToString());

                Console.WriteLine(Thread.CurrentThread.Name
               + " suspended for 5 seconds");

                //This is the one that casuses the deadlock
                Thread.Sleep(5000);//imititating some operation like validation check etc.

                Console.WriteLine(Thread.CurrentThread.Name +
                " back in action and trying to acquire lock on "
                + _toAccount.ID.ToString());

                lock (_toAccount)
                {
                     Console.WriteLine("This line should not be executed");
                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);
                }

            }
        }
    }
}
