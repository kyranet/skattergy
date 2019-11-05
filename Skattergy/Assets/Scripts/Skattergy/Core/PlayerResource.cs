namespace Skattergy.Core
{
    public class PlayerResource
    {
        public Resource Resource { get; }
        public ulong Amount { get; set; }

        public PlayerResource(Resource resource, ulong amount)
        {
            Resource = resource;
            Amount = amount;
        }

        public void Add(ulong amount)
        {
            Amount += amount;
        }

        public bool Remove(ulong amount)
        {
            if (amount > Amount) return false;
            Amount -= amount;
            return true;
        }
    }
}