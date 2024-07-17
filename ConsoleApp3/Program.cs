abstract class Employee
{
    public Guid GUID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public DateOnly startTime { get; set; }
    public DateOnly endTime { get; set; }

    public override string ToString()
    => $"GUID: {GUID}\nName: {Name}\nSurname: {Surname}\nAge: {Age}\nPosition: {Position}\nSalary: {Salary}\nStartTime: {startTime}\nEndTime{endTime}";
}

interface IWorker
{
    bool IsWorking { get; set; }
    void Operations();
    void addOperations();
}
interface IManager
{
    bool IsWorking { get; set; }
    void Organize();
    void CalculateSalaries();
}

interface ICio
{
    bool IsWorking { get; set; }

    void Control();
    void MakeMeeting();
    void decreasePercentage(string percent);
}

class Worker : Employee, IWorker
{
    public bool IsWorking { get; set; }
    public void Operations()
    {
        Console.WriteLine("Worker work");
    }
    public void addOperations()
    {
        Console.WriteLine("Worker add operations");
    }
}

class Manager : Employee, IWorker, IManager
{
    public bool IsWorking { get; set; }
    public void Organize()
    {
        Console.WriteLine("Manager Organized");
    }
    public void CalculateSalaries()
    {
        Console.WriteLine("Manager Calculate salary");
    }
    public void Operations()
    {
        Console.WriteLine("Manager work");
    }
    public void addOperations()
    {
        Console.WriteLine("Manager add operations");
    }
}

class CEO : Employee, IWorker, IManager, ICio
{
    public bool IsWorking { get; set; }
    public void Control()
    {
        Console.WriteLine("Cio Control");
    }
    public void MakeMeeting()
    {
        Console.WriteLine("Cio Make meeting!");
    }
    public void decreasePercentage(string percent)
    {
        Console.WriteLine($"Cio Decrease Percentage %{percent}");
    }
    public void Organize()
    {
        Console.WriteLine("Cio Organized");
    }
    public void CalculateSalaries()
    {
        Console.WriteLine("Cio Calculate salary");
    }
    public void Operations()
    {
        Console.WriteLine("Cio work");
    }
    public void addOperations()
    {
        Console.WriteLine("Cio add operations");
    }
}

class Client
{
    public Guid GUID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string live_adress { get; set; }
    public string work_adress { get; set; }
    public string salary { get; set; }
}

class Credit
{
    public Guid GUID { get; set; }
    public Client Client { get; set; }
    public int Amount { get; set; }
    public double Percent { get; set; }
    public int Months { get; set; }
    public int Payment { get; set; }
}


class Operation
{
    public Guid GUID { get; set; }
    public DateTime DateTime { get; set; }

    public void CreditPayment(Credit credit)
    {
        Console.WriteLine($"Performing credit payment for client {credit.Client.Name} {credit.Client.Surname}");

        Console.WriteLine($"Amount: {credit.Amount} | Monthly Payment: {credit.Payment}");
    }
}

class Bank
{
    public string Name { get; set; }
    public double Budget { get; set; }
    public double Profit { get; set; }

    private List<Credit> bankCredits = new List<Credit>();

    public Bank(string name, double budget)
    {
        Name = name;
        Budget = budget;
        Profit = 0;
    }

    public void Calculate_Profit()
    {
        Profit = Budget * 0.1;
    }

    public void ShowAllCredit()
    {
        Console.WriteLine("All Credits:");
        foreach (var credit in bankCredits)
        {
            Console.WriteLine($"Client: {credit.Client.Name} {credit.Client.Surname}, Amount: {credit.Amount}, Percent: {credit.Percent}, Months: {credit.Months}, Payment: {credit.Payment}");
        }
    }

    public void AddCredit(Credit credit)
    {
        bankCredits.Add(credit);
    }

    public void PayCredit(Client client, int money)
    {
        foreach (var credit in bankCredits)
        {
            if (credit.Client == client)
            {
                Budget -= money;
                credit.Amount -= money;

                Calculate_Profit();

                Console.WriteLine($"Payment of {money} made for client {client.Name} {client.Surname}");
                return;
            }
        }
        Console.WriteLine($"Credit not found for client {client.Name} {client.Surname}");
    }

    public void ShowClientCredit(string fullName)
    {
        Console.WriteLine($"Credits for client {fullName}:");
        foreach (var credit in bankCredits)
        {
            if (credit.Client.Name + " " + credit.Client.Surname == fullName)
            {
                Console.WriteLine($"Credit Amount: {credit.Amount}, Percent: {credit.Percent}, Months: {credit.Months}, Payment: {credit.Payment}");
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank("MyBank", 1000000);

        CEO ceo = new CEO
        {
            GUID = Guid.NewGuid(),
            Name = "Mehemmed",
            Surname = "Humbetli",
            Age = 45,
            Position = "CEO",
            Salary = 10000m,
            startTime = new DateOnly(2020, 1, 1),
            endTime = new DateOnly(2025, 12, 31)
        };

        Manager manager = new Manager
        {
            GUID = Guid.NewGuid(),
            Name = "BagdaGul",
            Surname = "Hesenova",
            Age = 35,
            Position = "Manager",
            Salary = 7000m,
            startTime = new DateOnly(2021, 6, 1),
            endTime = new DateOnly(2024, 12, 31)
        };

        Worker worker = new Worker
        {
            GUID = Guid.NewGuid(),
            Name = "Tural",
            Surname = "Huseyinli",
            Age = 28,
            Position = "Worker",
            Salary = 4000m,
            startTime = new DateOnly(2023, 2, 15),
            endTime = new DateOnly(2024, 12, 31)
        };

        Client client1 = new Client
        {
            GUID = Guid.NewGuid(),
            Name = "Ali",
            Surname = "Alili",
            Age = 30,
            live_adress = "Sumqyit Corat",
            work_adress = "Baki N.Nerimanov",
            salary = "5000"
        };

        Client client2 = new Client
        {
            GUID = Guid.NewGuid(),
            Name = "Bob",
            Surname = "Abbasov",
            Age = 42,
            live_adress = "Baki Q.Qarayev",
            work_adress = "Baku N.Nerimanov",
            salary = "7000"
        };

        Credit credit1 = new Credit
        {
            GUID = Guid.NewGuid(),
            Client = client1,
            Amount = 10000,
            Percent = 0.05,
            Months = 12,
            Payment = 900
        };

        Credit credit2 = new Credit
        {
            GUID = Guid.NewGuid(),
            Client = client2,
            Amount = 20000,
            Percent = 0.04,
            Months = 24,
            Payment = 1000
        };

        bank.AddCredit(credit1);
        bank.AddCredit(credit2);

        bank.Calculate_Profit();
        bank.ShowAllCredit();

        Operation operation = new Operation();
        operation.CreditPayment(credit1);

        Console.WriteLine("\nCEO Information:");
        Console.WriteLine(ceo.ToString());
    }
}