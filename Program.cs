// See https://aka.ms/new-console-template for more information
Menu();

static void Menu()
{
Console.Clear();
    Console.WriteLine("S = Segundo");
    Console.WriteLine("M = Minuto");
    Console.WriteLine("0 = Sair");
    Console.WriteLine("Quanto tempo deseja contar?");

    string? data = Console.ReadLine()?.ToLower();

    if (string.IsNullOrWhiteSpace(data))
    {
        Console.WriteLine("Entrada inválida. Por favor, insira um valor.");
        Thread.Sleep(2000);
        Menu();
        return;
    }

    char type = data[^1];
    if (!char.IsLetter(type))
    {
        Console.WriteLine("Tipo inválido. Por favor, insira 'S' para segundos ou 'M' para minutos.");
        Thread.Sleep(2000);
        Menu();
        return;
    }

    string timeString = data.Substring(0, data.Length - 1);

    if (!int.TryParse(timeString, out int time) || time <= 0)
    {
        Console.WriteLine("Tempo inválido. Por favor, insira um valor de tempo positivo.");
        Thread.Sleep(2000);
        Menu();
    }

    int multiplier = (type == 'm') ? 60 : 1;

    if (time == 0)
    {
        Environment.Exit(0);
    }

    PreStart(time * multiplier);
}

static void PreStart(int time){
    Console.Clear();
    Console.WriteLine("Ready...");
    Thread.Sleep(1000);
    Console.WriteLine("Set...");
    Thread.Sleep(1000);
    Console.WriteLine("Go...");
    Thread.Sleep(2500);

    Start(time);
}

static void Start(int time)
{

    int currentTime = 0;

    while (currentTime != time)
    {
        Console.Clear();
        currentTime++;
        Console.WriteLine($"Time count: {currentTime} seconds");
        Thread.Sleep(1000);
    }

    Console.Clear();
    Console.WriteLine("Time's up!");
    Thread.Sleep(2500);
    Menu();
}