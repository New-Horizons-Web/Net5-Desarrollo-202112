using System;

namespace Net.Fundamentals.DI.MVC.Application
{
    public class GuidGenerator : IGuidGenerator
    {
        private readonly IGuidTransient _guidTransient;
        private readonly IGuidScoped _guidScoped;
        private readonly IGuidSingleton _guidSingleton;
        public GuidGenerator(
            IGuidTransient guidTransient,
            IGuidScoped guidScoped,
            IGuidSingleton guidSingleton
        )
        {
            _guidTransient = guidTransient;
            _guidScoped = guidScoped;
            _guidSingleton = guidSingleton;
        }

        public string GetGuidTransient()
        {
            return _guidTransient.GetGuid();
        }
        public string GetGuidScoped()
        {
            return _guidScoped.GetGuid();
        }
        public string GetGuidSingleton()
        {
            return _guidSingleton.GetGuid();
        }
    }
}
