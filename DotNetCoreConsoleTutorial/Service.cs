namespace DotNetCoreConsoleTutorial
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public void DoWork()
        {
            _repository.DoWork();
        }
    }
}