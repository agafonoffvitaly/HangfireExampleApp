namespace HangfireExapleApp.Services
{
    public class MyJob : IMyJob
    {
        public void Print()
        {
            Console.WriteLine($"Print some text. Time: {DateTime.Now}");
        }
    }
}
