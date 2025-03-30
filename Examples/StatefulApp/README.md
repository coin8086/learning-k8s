# Stateful Application Example

See

* https://kubernetes.io/docs/tutorials/stateful-application/basic-stateful-set/ for the example
* https://kubernetes.io/docs/concepts/storage/volumes/#local for local PV
* https://kubernetes.io/docs/concepts/storage/storage-classes/#local for storage class for local PV

Note

The PVs in pv-local.yaml are all of type local, and thus the local path `/mnt/vol*` must exist on node before a PVC binding and provisioning.

On a Windows dev machine for a Kind cluster, this can be achieved by PowerShell commands like

```ps1
$containers = @('kind-worker', 'kind-worker2', 'kind-worker3')
$containers | %{ docker exec -it $_ bash -c 'for i in {1..10}; do mkdir -p /mnt/vol$i; done' }
```

Note for the commands

* Node `kind-control-plane` is not involved since it's excluded in the pv-local.yaml by PV's `nodeAffinity`.
* 10 directories (`/mnt/vol1` ... `/mnt/vol10`) are created on each node, so that a PV can be provisioned on any node without confliction.
