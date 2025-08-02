using k8s.Models;

namespace SchedulerExtender;

public class SchedulerFilterResult
{
    public IList<V1Node> Nodes { get; set; } = default!;
}
