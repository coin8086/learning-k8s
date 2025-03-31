# Service Example

This demonstrates a NodePort service in a Kind cluster.

## Run the example code

Start the service and related pods. Then write some different content to the pods, like

```ps1
$pods = @('my-nginx-77b9c67898-fbfpp', 'my-nginx-77b9c67898-l7fjj')
$pods | %{ kubectl.exe exec $_ -- sh -c 'hostname > /usr/share/nginx/html/index.html' }
```

## Access the service from pod

```cmd
kubectl run -it --rm --image louirobert/dnschecker:1.1 dnschecker --restart=Never
```

Then access the service by name

```bash
curl http://my-nginx
```

## Access the service from node

As a NortPort service, the service can also be accessed from a node (a docker container in Kind)

```cmd
docker exec -it kind-control-plane /bin/bash -l
```

Then access the service on localhost like

```bash
curl http://localhost:31316
```

The port number 31316 on node is allocated by k8s.

## References

* https://kubernetes.io/docs/concepts/services-networking/ and https://kubernetes.io/docs/concepts/cluster-administration/networking/ for overall of k8s network model
* https://kubernetes.io/docs/concepts/services-networking/service/#publishing-services-service-types for different service types, especially `ClusterIP` and `NodePort`
* https://kubernetes.io/docs/tutorials/services/connect-applications-service/ for the example app
