using System;

namespace Net.Fundamentals.DI.MVC.Application
{
    public class GuidScoped : IGuidScoped
    {
        private readonly Guid _guid;
        public GuidScoped()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
