using k8s;
using k8s.Models;

namespace GenericClient;

class Program
{
    static async Task Main(string[] args)
    {
        var config = KubernetesClientConfiguration.BuildDefaultConfig();
        var client = new Kubernetes(config);
        var genericPods = new k8s.GenericClient(client, "", "v1", "pods");
        var pods = await genericPods.ListNamespacedAsync<V1PodList>("default");

        Console.WriteLine("Pods in default namespace:");
        foreach (var pod in pods.Items)
        {
            Console.WriteLine(pod.Metadata.Name);
        }

        var genericNodes = new k8s.GenericClient(client, "", "v1", "nodes");
        var nodes = await genericNodes.ListAsync<V1NodeList>();
        Console.WriteLine("\nCluster nodes:");
        foreach (var node in nodes.Items)
        {
            Console.WriteLine(node.Metadata.Name);
        }
    }
}
