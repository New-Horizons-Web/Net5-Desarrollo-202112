using System;

namespace Net.Fundamentals.DI.MVC.Application
{
    public class GuidSingleton : IGuidSingleton
    {
        private readonly Guid _guid;
        public GuidSingleton()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
