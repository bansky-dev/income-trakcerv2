namespace income_trackerv2;

// TODO: Make class expense create new JSON file whenever an object is created

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;

        while(isRunning){
            System.Console.WriteLine("Expense name: ");
            string expenseName = Console.ReadLine();

            System.Console.WriteLine("Expense ammount: ");
            int expenseAmmount = int.Parse(Console.ReadLine());

            Expense expense = new Expense{
                _ExpenseName = expenseName,
                _ExpenseAmmount = expenseAmmount
            };
            
        }

        

    }
}

class Expense{
    public string _ExpenseName {get; set;}
    public int _ExpenseAmmount {get; set;}

}
