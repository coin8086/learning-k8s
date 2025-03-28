# Headless Service

See https://kubernetes.io/docs/concepts/services-networking/dns-pod-service/. Note the "headless service" and "SRV records".

To check the DNS for the service and pods, start a container of busybox, like

```cmd
kubectl run -it --rm --image busybox:1.28 dns-test --restart=Never
```

Then execute in the container

```bash
nslookup busybox-subdomain
```

The result is like

```
Server:    10.96.0.10
Address 1: 10.96.0.10 kube-dns.kube-system.svc.cluster.local

Name:      busybox-subdomain
Address 1: 10.244.1.5 busybox-2.busybox-subdomain.default.svc.cluster.local
Address 2: 10.244.3.5 busybox-1.busybox-subdomain.default.svc.cluster.local
```
