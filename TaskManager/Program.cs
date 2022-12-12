using TaskManagerCommandsLib;
namespace Program;
class Program
{
    public static bool running = true;
    static void Main()
    {
        Manager manager = new Manager();


        while (running)
        {



            string command = Console.ReadLine();
            ConsoleCommandExecute(command);
            Console.WriteLine(manager.ExecuteCommand(command));



        }
    }
    static void ConsoleCommandExecute(string comandName)
    {

        switch (comandName)
        {
            case "!exit":
                running = false;
                break;
            case "!clear":
                Console.Clear();
                break;


        }
        //какие-то вспомогательные команды:
        //сlear()
        //exit()
        //
    }
}