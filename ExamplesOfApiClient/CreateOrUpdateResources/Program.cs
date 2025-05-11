using k8s;
using k8s.Models;
using System.Net;

namespace CreateOrUpdateResources;

class Program
{
    static async Task Main(string[] args)
    {
        var fromYaml = false;
        if (args.Length > 0 && args[0] == "-y")
        {
            fromYaml = true;
        }

        var config = KubernetesClientConfiguration.BuildDefaultConfig();
        var client = new Kubernetes(config);
        using var deployments = new k8s.GenericClient(client, "apps", "v1", "deployments");

        V1Deployment deployment;
        if (fromYaml)
        {
            var file = "deployment.yaml";
            Console.WriteLine($"Loading from file {file}...");
            deployment = await KubernetesYaml.LoadFromFileAsync<V1Deployment>(file);
        }
        else
        {
            deployment = new V1Deployment()
            {
                Metadata = new V1ObjectMeta()
                {
                    Name = "test-deployment",
                },
                Spec = new V1DeploymentSpec()
                {
                    Replicas = 2,
                    Selector = new V1LabelSelector()
                    {
                        MatchLabels = new Dictionary<string, string>()
                        {
                            { "app", "test-deployment" }
                        }
                    },
                    Template = new V1PodTemplateSpec()
                    {
                        Metadata = new V1ObjectMeta()
                        {
                            Labels = new Dictionary<string, string>()
                            {
                                { "app", "test-deployment" }
                            }
                        },
                        Spec = new V1PodSpec()
                        {
                            Containers = new List<V1Container>()
                            {
                                new V1Container()
                                {
                                    Name = "my-nginx",
                                    Image = "nginx",
                                    Ports = new List<V1ContainerPort>()
                                    {
                                        new V1ContainerPort() { ContainerPort = 80 }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        try
        {
            Console.WriteLine("Creating deployment...");
            await deployments.CreateNamespacedAsync<V1Deployment>(deployment, "default");
        }
        catch (k8s.Autorest.HttpOperationException ex)
        {
            if (ex.Response.StatusCode == HttpStatusCode.Conflict && ex.Message.Contains("\"AlreadyExists\""))
            {
                Console.WriteLine("Patching deployment...");
                var patch = new V1Patch(deployment, V1Patch.PatchType.StrategicMergePatch);
                await deployments.PatchNamespacedAsync<V1Deployment>(patch, "default", deployment.Metadata.Name);
            }
        }
        Console.WriteLine("OK");
    }
}
