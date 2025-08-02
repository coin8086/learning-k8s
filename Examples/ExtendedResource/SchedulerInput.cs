using k8s.Models;
using System.ComponentModel.DataAnnotations;

namespace SchedulerExtender;

public class SchedulerInput
{
    [Required]
    public V1Pod Pod { get; set; } = default!;

    [Required]
    public IList<V1Node> Nodes { get; set; } = default!;
}
