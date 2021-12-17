using System;

namespace Net.Fundamentals.DI.MVC.Application
{
    public class GuidTransient : IGuidTransient
    {
        private readonly Guid _guid;
        public GuidTransient()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
