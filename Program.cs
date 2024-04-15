using System.Numerics;

Console.WriteLine("Welcome to the Basic Banking App \n");

var user = new User();
user.PrintUser();


public class User
{
    private List<decimal> transactions = new List<decimal>();
    public string Name { get; private set; }
    public int AccountNumber { get; private set; }
    public decimal Amount { get; private set; }


    public User()


    {
        Console.WriteLine("Please Enter Your Name");
        Name = Console.ReadLine();
        Console.WriteLine("Please Enter Your Account Number");
        AccountNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please Enter The  Amount");
        Amount= decimal.Parse(Console.ReadLine());



    }
    public void PrintUser()
    {

        Console.WriteLine($"___________________________\n Name: {Name} \n " +
            $"Account Number: {AccountNumber} \n " +
            $"Amount: {Amount} \n \n Account Setup Successful! \n _____________________________ \n ");

        
        MenueOption();
        PrintTransactions();

    }
    public void MenueOption()
    {
        
        int mainMenueOption = 0;

        do
        {
            Console.WriteLine(" \n Main Menue: \n 1.Deposit \n 2.Withdraw \n 3.View Balance  \n 4.show transactions \n 5. Exit  \n Please Select an option \n"
      );

            var input = Console.ReadLine();
            if (int.TryParse(input, out mainMenueOption))
                switch (mainMenueOption)
                {
                    case 1:
                        Deposit();
                        break;
                    case 2:
                        Withdraw();
                        break;
                    case 3:
                        Console.WriteLine($" \n Current Balance: {Amount}");
                        break;
                    case 4:
                        PrintTransactions();
                        break;
                    case 5:
                        Console.WriteLine("logging out...");
                        break;
                    
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

        } while (mainMenueOption != 5); 

    }

    private void Deposit()
    {
        Console.WriteLine("Enter Deposit amount:");
        decimal amount = decimal.Parse(Console.ReadLine());
        Amount += amount;
        RecordTransaction(amount);
        Console.WriteLine($"Deposited: {amount}. Current balance: {Amount}");
    }

    private void Withdraw()
    {
        Console.WriteLine("Enter withdrawal amount:");
        decimal amount = decimal.Parse(Console.ReadLine());
        if (Amount >= amount)
        {
            Amount -= amount;
            RecordTransaction(-amount);
            Console.WriteLine($"Withdrawn: {amount}. Current balance: {Amount}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    private void RecordTransaction(decimal amount)
    {
        transactions.Add(amount);
    }

    private void PrintTransactions()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{(transaction > 0 ? "Deposit  " : "Withdraw ")} {Math.Abs(transaction)}");
        }
    }




}

