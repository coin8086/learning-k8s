# Persistent Volume Example

See

* https://kubernetes.io/docs/tasks/configure-pod-container/configure-persistent-volume-storage/
* https://kubernetes.io/docs/concepts/storage/persistent-volumes/
* https://kubernetes.io/docs/concepts/storage/volumes/

NOTE:

* A single node cluster is required for this example, since it uses `hostpath` volume. Such a cluster can be created simply by

  ```cmd
  kind create cluster
  ```

* `kubectl port-forward` can be used to access the port 80 on a pod from your dev machine, like

  ```cmd
  kubectl port-forward pods/task-pv-pod 8080:80
  ```

* Change `accessModes` of the PV and PVC to `ReadWriteOncePod` from `ReadWriteOnce`, and try the example again. Then a second pod cannot be started since the PV can be mounted on only one pod.
