// Project Prolog
// Name: Andrew Pritchett
// CS3260 Section X01
// Project: Lab_02
// Date: 07/03/2022
// Purpose: Create a bank account class and an IAccount interface
// to access it (practicing data hiding/loose coupling). Test all
// functionality.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------


namespace Lab02
{
    /// <summary>
    /// Main driver for the project.
    /// </summary>
    public class Lab02
    {
        /// <summary>
        /// Main testing function - instantiate Account through
        /// IAccount interface and test all functionality.
        /// </summary>
        public static void Main()
        {
            // Instantiate account through interface
            IAccount account = new Account();

            // test base state
            Console.WriteLine("Test base state \"new_account\": ");
            Console.WriteLine("Account State = " + account.GetState());

            // set basic account details
            Console.WriteLine("Setting account number...");
            Console.WriteLine(account.SetAccountNumber(1001));
            Console.WriteLine("Setting name...");
            Console.WriteLine(account.SetName("Andrew Pritchett"));
            Console.WriteLine("Setting address...");
            Console.WriteLine(account.SetAddress("10412 N. 6300 W. Highland, UT 84003"));
            Console.WriteLine("Setting balance....");
            Console.WriteLine(account.SetBalance(100.00m));

            // print the basic account details
            Console.WriteLine("Account Number = " + account.GetAccountNumber());
            Console.WriteLine("Name = " + account.GetName());
            Console.WriteLine("Address = " + account.GetAddress());
            Console.WriteLine("Balance = " + account.GetBalance());

            // test bad name input
            Console.WriteLine("Test bad name set:");
            Console.WriteLine(account.SetName(""));

            // test bad address input
            Console.WriteLine("Test bad address set:");
            Console.WriteLine(account.SetAddress(""));

            // hold the good states + 1 bad state for testing
            string[] states = { "new_account", "active", "under_audit", "frozen", "closed", "bad_state" };

            // saved some code by iterating through each state
            foreach (string st in states)
            {
                Console.WriteLine($"Test state \"{st}\": "); // state to test
                Console.WriteLine(account.SetState(st)); // set state, print true or false
                Console.WriteLine("Account State = " + account.GetState()); // output current state
            }

            // test bad balance set
            Console.WriteLine("Setting balance at < minimum @ $90.00:");
            Console.WriteLine(account.SetBalance(90.00m));

            // test good balance set
            Console.WriteLine("Setting balance at > minimum @ $200.00:");
            Console.WriteLine(account.SetBalance(200.00m));
            Console.WriteLine("Balance = " + account.GetBalance());

            // test good deposit
            Console.WriteLine("Deposit $1000");
            Console.WriteLine(account.PayInFunds(1000m));
            Console.WriteLine("Balance = " + account.GetBalance());

            // test bad deposit
            Console.WriteLine("Deposit -$10");
            Console.WriteLine(account.PayInFunds(-10m));
            Console.WriteLine("Balance = " + account.GetBalance());

            // test good withdraw
            Console.WriteLine("Withdraw $75");
            account.WithdrawFunds(75m);
            Console.WriteLine("Balance = " + account.GetBalance());

            // test bad withdraw
            Console.WriteLine("Attempt overdraft: ");
            Console.WriteLine(account.WithdrawFunds(10000m));
            Console.WriteLine("Balance = " + account.GetBalance());

            // test withdraw to empty
            Console.WriteLine("Withdraw to 0: ");
            Console.WriteLine(account.WithdrawFunds(account.GetBalance()));
            Console.WriteLine("Balance = " + account.GetBalance());

        }
    }
}