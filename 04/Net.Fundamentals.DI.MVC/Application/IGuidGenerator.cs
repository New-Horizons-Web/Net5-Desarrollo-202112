namespace Net.Fundamentals.DI.MVC.Application
{
    public interface IGuidGenerator
    {
        string GetGuidTransient();
        string GetGuidScoped();
        string GetGuidSingleton();
    }
}