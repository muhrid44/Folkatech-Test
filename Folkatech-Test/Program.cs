namespace Folkatech_Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //press CTRL+F5 to start the application 
            Home startProgram = new Home();
            await startProgram.Menu();
        }
    }
}