// Simple Parking System

double minutes = 0;
double hours = 0;
double money = 0;
string input;

Console.Clear();
PrintWelcomeMessage();
do
{
    PrintParkingTime();
    EnterCoins();
    AddParkingTime();
    if (input == "d" && minutes + hours * 60 < 30)
    {
        System.Console.WriteLine("You need to park at least 30 minutes!");
        System.Console.WriteLine();
        input = "Invalid";
    }
}
while (input != "d" && minutes + hours * 60 < 90);
PrintEndParkingTime();
PrintDonation();



void PrintWelcomeMessage()
{
    System.Console.WriteLine("You can park here form 30 to 90 minutes");
    System.Console.WriteLine("Allowed coins: 5 (Cents), 10 (Cents), 20 (Cents), 50 (Cents), 1 (Euro), 2 (Euro)");
    System.Console.WriteLine("Enter d or D to print your paring ticket!");
    System.Console.WriteLine("Costs: 1 Euro per hour");
    System.Console.WriteLine("No return money!");
    System.Console.WriteLine();
}

void EnterCoins()
{
    do
    {
        System.Console.Write("Please enter your input: ");
        input = System.Console.ReadLine()!;
    }
    while (!(input is "1" or "2" or "5" or "10" or "20" or "50" or "d" or "D"));
    money = 0;
    switch (input)
    {
        case "5":
            money += 5;
            break;
        case "10":
            money += 10;
            break;
        case "20":
            money += 20;
            break;
        case "50":
            money += 50;
            break;
        case "1":
            money += 100;
            break;
        case "2":
            money += 200;
            break;
        case "d":
        case "D":
            input = input.ToLower();
            break;
    }
}

void AddParkingTime()
{
    minutes += money / 100 * 60;
    while (minutes >= 60)
    {
        minutes -= 60;
        hours += 1;
    }
}

void PrintParkingTime()
{
    System.Console.WriteLine($"Your Parking Time: {hours:00}:{minutes:00}");
}

void PrintEndParkingTime()
{
    if (minutes + hours * 60 > 90)
    {
        System.Console.WriteLine("You can park here for 01:30 hours!");
    }
    else
    {
        System.Console.WriteLine($"You can park here for {hours:00}:{minutes:00} hours!");
    }
}

void PrintDonation()
{
    if (minutes + hours * 60 > 90)
    {
        minutes += hours * 60;
        money = minutes / 60 * 100;
        System.Console.WriteLine($"Thanks for your donation of {money} Cents!");
    }
}