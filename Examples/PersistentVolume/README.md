# Persistent Volume (PV) Examples

## Static PV

[static-pv-example.yaml](./static-pv-example.yaml) demonstrates a static PV and its usage.

NOTE

* A static PV must be created before a PV claim (PVC). Otherwise Pod volume mounting to it may fail silently, while the Pod is still created and running.
* The PV in the example is of type `hostpath`. So it's typically used in a single-node cluster for dev and test purpose. See [`hostpath`'s details and limits](https://kubernetes.io/docs/concepts/storage/volumes/#hostpath).
* The `storageClassName` of both PV and PVC in the example is set to "manual", meaning a static PV in the example.

## Dynamic PV

[dynamic-pv-example.yaml](./dynamic-pv-example.yaml) demonstrates dynamic PV by `StatefulSet`, whose property `volumeClaimTemplates` defines a PVC template for _each Pod_ in the StatefulSet.

Note that there's no `storageClassName` present in a PVC in the example. So the default storage class of a cluster is applied. For a Kind cluster, the default one is like

```yaml
apiVersion: storage.k8s.io/v1
kind: StorageClass
metadata:
  annotations:
    storageclass.kubernetes.io/is-default-class: "true"
  creationTimestamp: "2025-04-01T07:15:00Z"
  name: standard
  resourceVersion: "340"
  uid: 6843a6fc-b9d9-4e0a-b69d-a8e15fff91a0
provisioner: rancher.io/local-path
reclaimPolicy: Delete
volumeBindingMode: WaitForFirstConsumer
```

The storage provisioner [rancher.io/local-path](https://github.com/rancher/local-path-provisioner) creates PV on node dynamically. This can be checked like

```ps1
# Write hostname into each Pod's /usr/share/nginx/html/index.html
0..4 | %{ kubectl.exe exec "dynamic-pv-example-web-$_" -- sh -c 'hostname > /usr/share/nginx/html/index.html' }
# Check the storage for PVs on each node
$containers = @('kind-control-plane', 'kind-worker', 'kind-worker2', 'kind-worker3')
$containers | %{ docker exec -it $_ bash -c 'ls /var/local-path-provisioner' }
```

The path "/var/local-path-provisioner" on each node is the parent directory for PVs. It can be configured, along with other configurable items on the provisioner.

## References

* https://kubernetes.io/docs/concepts/storage/volumes/
* https://kubernetes.io/docs/concepts/storage/persistent-volumes/
* https://github.com/rancher/local-path-provisioner
