namespace Skattergy.Core
{
    public interface IBuildable
    {
        bool CanBuild { get; }
        WorldPosition Position { get; }
    }
}