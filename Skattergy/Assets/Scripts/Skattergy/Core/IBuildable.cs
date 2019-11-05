namespace Skattergy.Core
{
    public interface IBuildable
    {
        ushort Level { get; }
        bool CanBuild { get; }
        bool CanUpgrade { get; }
        WorldPosition Position { get; }
    }
}