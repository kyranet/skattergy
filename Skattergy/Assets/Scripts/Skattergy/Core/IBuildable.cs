namespace Skattergy.Core
{
    public interface IBuildable
    {
        byte Level { get; }
        bool CanBuild { get; }
        bool CanUpgrade { get; }
        WorldPosition Position { get; }
    }
}