namespace Code.ECS.Common.Services
{
    public class IdentifierService : IIdentifierService
    {
        private int _lastId;
        
        public int Next() => ++_lastId;
    }
}