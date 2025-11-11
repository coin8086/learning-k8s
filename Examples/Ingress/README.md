# Ingress Examples

The examples show [Ingress-Nginx](https://kubernetes.github.io/ingress-nginx/) usages.

For installation of ingress-nginx, see https://kubernetes.github.io/ingress-nginx/deploy/.

It can be installed simply by helm

```ps1
helm upgrade --install ingress-nginx ingress-nginx --repo https://kubernetes.github.io/ngress-nginx --namespace ingress-nginx --create-namespace
```

## Basic Example

Create a name space and apply [basic.yaml](./basic.yaml) in it

```ps1
kubectl create namespace basic
kubectl apply -f .\basic.yaml -n basic
```

To test it on localhost, use port forward like

```ps1
kubectl port-forward --namespace=ingress-nginx service/ingress-nginx-controller 8081:80
```

Then try

```ps1
curl --resolve basic:8081:127.0.0.1 http://basic:8081/svc/1
curl --resolve basic:8081:127.0.0.1 http://basic:8081/svc/2
```

and

```ps1
curl --resolve basic:8081:127.0.0.1 http://basic:8081/svc/1/abc
curl --resolve basic:8081:127.0.0.1 http://basic:8081/svc/3
```

Note the usage of `nginx.ingress.kubernetes.io/rewrite-target` in the example. See also [the official document about Rewrite](https://kubernetes.github.io/ingress-nginx/examples/rewrite/).