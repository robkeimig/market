namespace Market.Service
{
    class ServiceMain
    {
        public static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.StartService();
        }
    }
}
