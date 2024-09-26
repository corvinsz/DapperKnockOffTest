using DapperKnockOffTest;

internal class Program
{
    private static void Main(string[] args)
    {
        var idk = DatabaseHandler.GetPersons();

        int cnt = idk.Count();

        Console.WriteLine("Completed");
    }
}