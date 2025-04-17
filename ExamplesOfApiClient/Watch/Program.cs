using k8s.Models;
using k8s;

namespace Watch;

class Program
{
    static async Task Main(string[] args)
    {
        var config = KubernetesClientConfiguration.BuildDefaultConfig();
        var client = new Kubernetes(config);
        var podlistResp = client.CoreV1.ListNamespacedPodWithHttpMessagesAsync("default", watch: true);

        await foreach (var (type, item) in podlistResp.WatchAsync<V1Pod, V1PodList>())
        {
            Console.WriteLine("\n==on watch event==");
            Console.WriteLine(type);
            Console.WriteLine(item.Metadata.Name);
            Console.WriteLine(item.Status.Phase);
        }
    }
}
