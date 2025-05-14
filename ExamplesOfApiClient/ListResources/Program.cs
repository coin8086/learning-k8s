using k8s;

namespace ListResources;

class Program
{
    static void Main(string[] args)
    {
        var config = KubernetesClientConfiguration.BuildDefaultConfig();
        using var client = new Kubernetes(config);

        Console.WriteLine("Starting Request!");

        var list = client.CoreV1.ListNamespacedPod("default");
        foreach (var item in list.Items)
        {
            Console.WriteLine(item.Metadata.Name);
        }

        if (list.Items.Count == 0)
        {
            Console.WriteLine("Empty!");
        }
    }
}
