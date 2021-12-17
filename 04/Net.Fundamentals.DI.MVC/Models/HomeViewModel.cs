namespace Net.Fundamentals.DI.MVC.Models
{
    public class HomeViewModel
    {
        public string GuidTransientGenerator { get; set; }
        public string GuidTransientController { get; set; }
        public string GuidScopedGenerator { get; set; }
        public string GuidScopedController { get; set; }
        public string GuidSingletonGenerator { get; set; }
        public string GuidSingletonController { get; set; }
    }
}
