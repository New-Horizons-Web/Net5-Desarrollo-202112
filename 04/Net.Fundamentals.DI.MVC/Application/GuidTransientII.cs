using System;

namespace Net.Fundamentals.DI.MVC.Application
{
    public class GuidTransientII : IGuidTransient
    {
        private readonly Guid _guid;
        public GuidTransientII()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
