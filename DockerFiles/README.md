# Build an image for checking DNS in k8s cluster

The [`busybox`](https://hub.docker.com/_/busybox) is small but not good enough for the work. So a custom image is built for the purpose.

Build image `dnschecker` like

```cmd
docker build -t louirobert/dnschecker:1.0 -f .\DockerFiles\dns-checker .
```

Publish it with

```cmd
docker publish louirobert/dnschecker:1.0
```

NOTE:

* Better use a specific version tag other than "latest" (or default to it) for a container in k8s. See [Image pull policy](https://kubernetes.io/docs/concepts/containers/images/#image-pull-policy).

* See also https://kind.sigs.k8s.io/docs/user/local-registry/ for using a local image registry in Kind.
