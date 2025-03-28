# Load Balancer

To have a load balancer for a [kind](https://kind.sigs.k8s.io/) cluster, use [cloud-provider-kind](https://github.com/kubernetes-sigs/cloud-provider-kind). Open a new shell window and execute

```cmd
./cloud-provider-kind
```

> NOTE
>
> For Windows + Docker Desktop + kind, get the real service port on localhost by checking the ports of container of image `envoyproxy/envoy`, like
>
> ```cmd
> docker container ls
> ```
>
> The result is like
>
> ```
> CONTAINER ID   IMAGE                      COMMAND                  CREATED          STATUS          PORTS                                               NAMES
> 6efca0fd732b   envoyproxy/envoy:v1.30.1   "/docker-entrypoint.…"   14 seconds ago   Up 13 seconds   0.0.0.0:58639->8080/tcp, 0.0.0.0:58640->10000/tcp   kindccm-9ea2e2f2464f
> ```
>
> The port 58639, which maps to 8080, is the real port on localhost for the service in the result.

For more about `cloud-provider-kind`, see

* https://kind.sigs.k8s.io/docs/user/loadbalancer/
* https://github.com/kubernetes-sigs/cloud-provider-kind


For more about the example, see

* https://kubernetes.io/docs/tutorials/stateless-application/expose-external-ip-address/
