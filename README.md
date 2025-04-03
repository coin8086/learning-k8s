# Learning Kubernetes(k8s) by Simple Examples

## Learning environment

Windows + Docker Desktop + [Kind](https://kind.sigs.k8s.io/)

Linux should be OK too, as long as docker, kubectl and kind are installed.

A local dev machine is enough for all the examples.

## Overall

* Learn the 3 different ways to manipulate objects in a k8s cluster:

  https://kubernetes.io/docs/concepts/overview/working-with-objects/object-management/

* K8s API:

  https://kubernetes.io/docs/reference/generated/kubernetes-api/v1.32/

## Tips

* To check DNS inside a k8s cluster, run a container inside the cluster, like

  ```cmd
  kubectl run -it --rm --image busybox:1.28 dns-test --restart=Never
  ```

  Or use a more powerful (and also bigger in size) image

  ```cmd
  kubectl run -it --rm --image louirobert/dnschecker:1.1 dnschecker --restart=Never
  ```

* To access a port in a k8s cluster from local dev machine, use `kubectl port-forward`, like

  ```cmd
  kubectl port-forward services/frontend 8080:80
  ```
