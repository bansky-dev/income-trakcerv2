using System.Collections;
using System.Text.Json;
using System.IO;
using System.Data;

namespace income_trackerv2;

// TODO: Troubleshoot folder creations at breakpoints 

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        int count = 1;
        string todaysDate = DateTime.Now.ToString("dd-mm-yyyy");
        string? expensesFolderPath = $"{todaysDate}-Expenses";
        string? incomesFolderPath = $"{todaysDate}-Incomes";


        if(!Directory.Exists(expensesFolderPath))
        {
            Directory.CreateDirectory(expensesFolderPath);
            System.Console.WriteLine($"Created folder {expensesFolderPath}");
        }
        else
        {
            Directory.CreateDirectory("defaultFolderName-Incomes");
            System.Console.WriteLine("Created default folder");
        }
        
        if(!Directory.Exists(incomesFolderPath))
        {
            Directory.CreateDirectory(incomesFolderPath);
            System.Console.WriteLine($"Created folder {incomesFolderPath}");
        }
        else
        {
            Directory.CreateDirectory("defaultFolderName-Incomes");
            System.Console.WriteLine("Created default folder");
        }
        
        

        while(isRunning){

            System.Console.Write("Expense name (leave blank if all expenses are added): ");
            string? expenseName = Console.ReadLine();

            if(expenseName == null){
                break;
            }

            System.Console.Write("Expense ammount: ");
            int expenseAmmount = int.Parse(Console.ReadLine());

            System.Console.Write("Expense short description: ");
            string? expenseDescription = Console.ReadLine();

            Expense expense = new Expense{
                _ExpenseName = expenseName,
                _ExpenseAmmount = expenseAmmount,
                _ExpenseDescription = expenseDescription
            };

            string jsonString = JsonSerializer.Serialize(expense);
            string filePath = @$"{expensesFolderPath}/{expenseName}-Expense{count}.json";
            count++;

            File.WriteAllText(filePath, jsonString);
            
        }

        count = 0;

        while(isRunning){
            System.Console.Write("Income namel (leave blank if all incomes are added): ");
            string? incomeName = Console.ReadLine();

            if(incomeName == null){
                break;
            }

            System.Console.Write("Income ammount: ");
            int incomeAmmount = int.Parse(Console.ReadLine());

            System.Console.Write("Income description: ");
            string? incomeDescription = Console.ReadLine();

            Income income = new Income{
                _IncomeName = incomeName,
                _IncomeAmmount = incomeAmmount,
                _IncomeDescription = incomeDescription
            };

            string jsonString = JsonSerializer.Serialize(income);
            string filePath = @$"{incomesFolderPath}/{incomeName}-Income{count}.json";
            count++;

            File.WriteAllText(filePath, jsonString);
        }

        

    }
}

class Expense{
    public string? _ExpenseName {get; set;}
    public int _ExpenseAmmount {get; set;}
    public string? _ExpenseDescription {get; set;}

}

class Income{
    public string? _IncomeName {get; set;}
    public int _IncomeAmmount {get; set;}
    public string? _IncomeDescription{get; set;}
}

