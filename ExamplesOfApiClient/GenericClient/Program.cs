using k8s;
using k8s.Models;

namespace GenericClient;

class Program
{
    static async Task Main(string[] args)
    {
        var watch = false;
        if (args.Length > 0 && args[0] == "-w")
        {
            watch = true;
        }

        var config = KubernetesClientConfiguration.BuildDefaultConfig();
        using var client = new Kubernetes(config);
        using var genericPods = new k8s.GenericClient(client, "", "v1", "pods", false);

        if (watch)
        {
            var pods = genericPods.WatchNamespacedAsync<V1Pod>("default");

            Console.WriteLine("Pods in default namespace:");

            await foreach (var (evt, pod) in pods)
            {
                Console.WriteLine(evt);
                Console.WriteLine(pod.Metadata.Name);
            }
        }
        else
        {
            var pods = await genericPods.ListNamespacedAsync<V1PodList>("default");

            Console.WriteLine("Pods in default namespace:");

            foreach (var pod in pods.Items)
            {
                Console.WriteLine(pod.Metadata.Name);
            }
        }
    }
}
