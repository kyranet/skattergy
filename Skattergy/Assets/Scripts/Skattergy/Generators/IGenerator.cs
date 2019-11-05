using Skattergy.Core;

namespace Skattergy.Generators
{
    public interface IGenerator : IBuildable, ITickable
    {
        Resource Resource { get; }
        ulong ResourceGenerationPerTick { get; }
        Resource? RequiredResource { get; }
        ulong? RequiredResourcePerTick { get; }
    }
}