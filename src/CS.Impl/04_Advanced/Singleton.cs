using System;

namespace CS.Impl._04_Advanced
{
    public class Singleton
    {
        private static Singleton instance = null;
        private Singleton()
        {
            instance = this;
        }
        public static Singleton Instance => instance ?? new Singleton();
    }

    public interface IMySingleton { }
    public class MySingleton : IMySingleton { }
}