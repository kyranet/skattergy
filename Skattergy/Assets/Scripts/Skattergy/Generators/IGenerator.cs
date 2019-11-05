using Skattergy.Core;

namespace Skattergy.Generators
{
    public interface IGenerator : IBuildable, ITickable
    {
        Resource Resource { get; }
        int ResourceGenerationPerTick { get; }
        Resource? RequiredResource { get; }
        int? RequiredResourcePerTick { get; }
    }
}