using System;

namespace Account_State
{
	internal class Account
	{
		// ReSharper disable once NotAccessedField.Local
		private readonly string _owner;
		public Account(string owner)
		{
			_owner = owner;
			State = new SilverState(0.0, this);
		}

		public State State { get; set; }

		public double Balance { get; set; }

		public void Deposit(double amount)
		{
			State.Deposit(amount);
			Console.WriteLine("Deposited {0:C} --- ", amount);
			Console.WriteLine(" Balance = {0:C}", Balance);
			Console.WriteLine(" Status = {0}",
				State.GetType().Name);
			Console.WriteLine("");
		}

		public void Withdraw(double amount)
		{
			State.Withdraw(amount);
			Console.WriteLine("Withdrew {0:C} --- ", amount);
			Console.WriteLine(" Balance = {0:C}", Balance);
			Console.WriteLine(" Status = {0}\n",
				State.GetType().Name);
		}

		public void PayInterest()
		{
			State.PayInterest();
			Console.WriteLine("Interest Paid --- ");
			Console.WriteLine(" Balance = {0:C}", Balance);
			Console.WriteLine(" Status = {0}\n",
				State.GetType().Name);
		}

	}

	internal abstract class State
	{
		protected double Interest { get; set; }
		protected double LowerLimit;
		protected double UpperLimit;


		public Account Account { get; set; }

		public double Balance { get; set; }

		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public abstract void PayInterest();
	}

	internal class RedState : State
	{
		//private double _serviceFee;
		public RedState(State state)
		{
			Balance = state.Balance;
			Account = state.Account;
			Initialize();
		}

		private void Initialize()
		{
			Interest = 0.0;
			LowerLimit = -100.0;
			UpperLimit = 0.0;
			//_serviceFee = 15.00;
		}

		public override void Deposit(double amount)
		{
			Balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			Console.WriteLine("No funds available for withdrawal!");
		}

		public override void PayInterest()
		{
			// No interest is paid
		}

		private void StateChangeCheck()
		{
			if (Balance > UpperLimit)
			{
				Account.State = new SilverState(this);
			}
		}
	}

	internal class GoldState : State
	{
		public GoldState(State state) :
			this(state.Balance, state.Account)
		{
		}

		public GoldState(double balance, Account account)
		{
			Balance = balance;
			Account = account;
			Initialize();
		}

		private void Initialize()
		{
			// Should come from a database

			Interest = 0.05;
			LowerLimit = 1000.0;
			UpperLimit = 10000000.0;
		}

		public override void Deposit(double amount)
		{
			Balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			Balance -= amount;
			StateChangeCheck();
		}

		public override void PayInterest()
		{
			Balance += Interest * Balance;
			StateChangeCheck();
		}

		private void StateChangeCheck()
		{
			if (Balance < 0.0)
			{
				Account.State = new RedState(this);
			}
			else if (Balance < LowerLimit)
			{
				Account.State = new SilverState(this);
			}
		}
	}

	internal class SilverState : State
	{
		public SilverState(State state) :
			this(state.Balance, state.Account)
		{
		}

		public SilverState(double balance, Account account)
		{
			Balance = balance;
			Account = account;
			Initialize();
		}

		private void Initialize()
		{
			//Should come from a datasource
			Interest = 0.0;
			LowerLimit = 0.0;
			UpperLimit = 1000.0;
		}

		public override void Deposit(double amount)
		{
			Balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount)
		{
			Balance -= amount;
			StateChangeCheck();
		}

		public override void PayInterest()
		{
			Balance += Interest * Balance;
			StateChangeCheck();
		}

		private void StateChangeCheck()
		{
			if (Balance < LowerLimit)
			{
				Account.State = new RedState(this);
			}
			else if (Balance > UpperLimit)
			{
				Account.State = new GoldState(this);
			}
		}
	}


	internal class Program
	{
		private static void Main()
		{
			var account = new Account("Stefan");
			account.Deposit(500.0);
			account.Deposit(300.0);
			account.Deposit(550.0);
			account.PayInterest();
			account.Withdraw(2000.00);
			account.Withdraw(1100.00);

			// Wait for user

			Console.ReadKey();

		}
	}
}
