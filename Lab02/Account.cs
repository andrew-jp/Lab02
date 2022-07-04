
namespace Lab02
{
    /// <summary>
    /// Bank account class - uses IAccount interface
    /// Instantiate with IAccount [name] = new Account()
    /// </summary>
    public class Account : IAccount
    {
        /// <summary>
        /// Minimum account balance
        /// </summary>
        private const decimal MIN_BAL = 100.00m;

        /// <summary>
        /// Account holder name
        /// </summary>
        private string name = "";

        /// <summary>
        /// Account holder address
        /// </summary>
        private string address = "";

        /// <summary>
        /// Account balance (decimal value)
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Account number
        /// </summary>
        private int account_number;

        /// <summary>
        /// Current account state -
        /// defualt to new_account upon creation
        /// </summary>
        private Enum state = AccountState.new_account;

        /// <summary>
        /// enumerator to hold possible account states
        /// </summary>
        private enum AccountState {
            new_account,
            active,
            under_audit,
            frozen,
            closed
        }

        /// <summary>
        /// Sets account holder name
        /// </summary>
        /// <param name="inName"></param>
        /// <returns>bool</returns>
        public bool SetName(string inName)
        {
            name = inName;
            if (inName == null || inName == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get account holder name
        /// </summary>
        /// <returns>string</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Set account holder address 
        /// </summary>
        /// <param name="inAddress"></param>
        /// <returns>bool</returns>
        public bool SetAddress(string inAddress)
        {
            address = inAddress;
            if (inAddress == null || inAddress == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Return account holder address
        /// </summary>
        /// <returns>string</returns>
        public string GetAddress()
        {
            return address;
        }

        /// <summary>
        /// Add funds to account - must be positive
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>bool</returns>
        public bool PayInFunds(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// Withdraw funds from account - cannot exceed account balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>bool</returns>
        public bool WithdrawFunds(decimal amount)
        {
            if (amount > balance)
            {
                return false;
            }

            balance -= amount;
            return true;
        }

        /// <summary>
        /// Set account balance - must be greater than minimum balance
        /// </summary>
        /// <param name="inBalance"></param>
        /// <returns>bool</returns>
        public bool SetBalance(decimal inBalance)
        {
            if (inBalance < MIN_BAL)
            {
                return false;
            }

            balance = inBalance;
            return true;
        }

        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns>decimal</returns>
        public decimal GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// Set account number
        /// </summary>
        /// <param name="inAccountNum"></param>
        /// <returns>bool</returns>
        public bool SetAccountNumber(int inAccountNum)
        {
            if (inAccountNum == 0 || inAccountNum < 0)
            {
                return false;
            }

            account_number = inAccountNum;
            return true;
        }

        /// <summary>
        /// Get account number
        /// </summary>
        /// <returns>int</returns>
        public int GetAccountNumber()
        {
            return account_number;
        }

        /// <summary>
        /// Set account state
        /// </summary>
        /// <param name="inState"></param>
        /// <returns>bool</returns>
        public bool SetState(string inState)
        {
            switch (inState)
            {
                case "new_account":
                    state = AccountState.new_account;
                    return true;
                case "active":
                    state = AccountState.active;
                    return true;
                case "under_audit":
                    state = AccountState.under_audit;
                    return true;
                case "frozen":
                    state = AccountState.frozen;
                    return true;
                case "closed":
                    state = AccountState.closed;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Get account state
        /// </summary>
        /// <returns>enum</returns>
        public Enum GetState()
        {
            return state;
        }

    }

    /// <summary>
    /// Interface for Account class
    /// used for data separation/protection
    /// </summary>
    public interface IAccount
    {
        bool SetName(string inName);
        string GetName();

        bool SetAddress(string inAddress);
        string GetAddress();

        bool PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);

        bool SetBalance(decimal inBalance);
        decimal GetBalance();

        bool SetAccountNumber(int inAccountNumber);
        int GetAccountNumber();

        bool SetState(string inState);
        Enum GetState();

    }
}

