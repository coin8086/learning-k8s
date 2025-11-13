# Ingress Examples

The examples show [Ingress-Nginx](https://kubernetes.github.io/ingress-nginx/) usages.

For installation of ingress-nginx, see https://kubernetes.github.io/ingress-nginx/deploy/.

It can be installed simply by helm

```ps1
helm upgrade --install ingress-nginx ingress-nginx --repo https://kubernetes.github.io/ngress-nginx --namespace ingress-nginx --create-namespace
```

## Test Locally

The examples are assumed to run on a local k8s cluster, for example one created by Kind.

To test them locally, use port forward like

```ps1
kubectl port-forward --namespace=ingress-nginx service/ingress-nginx-controller 8081:80
```

Then HTTP request to localhost:8081 will go to the local cluster on port 80.

Similarly,

```ps1
kubectl port-forward --namespace=ingress-nginx service/ingress-nginx-controller 8082:443
```

This maps localhost:8081 to local cluster on port 443.

## Basic Example

Create a name space and apply [basic.yaml](./basic.yaml) in it

```ps1
kubectl create namespace basic
kubectl apply -f .\basic.yaml -n basic
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

> Note the usage of `nginx.ingress.kubernetes.io/rewrite-target` in the example.

See more about the basics at

* https://kubernetes.github.io/ingress-nginx/user-guide/basic-usage/
* https://kubernetes.github.io/ingress-nginx/examples/rewrite/

## TLS Example

Create a name space and apply [tls.yaml](./tls.yaml) in it

```ps1
kubectl create namespace tls
kubectl apply -f .\tls.yaml -n tls
```

Then try

```ps1
curl --resolve test.local:8082:127.0.0.1 https://test.local:8082 -k
```

and

```ps1
curl --resolve test.local:8081:127.0.0.1 http://test.local:8081
```

> Note [tls.yaml](./tls.yaml) contains TLS secrets. This is only for demo purpose.

See more on TLS at

* https://kubernetes.github.io/ingress-nginx/user-guide/tls/
* https://kubernetes.github.io/ingress-nginx/examples/tls-termination/

## Basic Authentication Example

Create a name space and apply [bacic-auth.yaml](./basic-auth.yaml) in it

```ps1
kubectl create namespace basic-auth
kubectl apply -f .\basic-auth.yaml -n basic-auth
```

Then try

```ps1
curl --resolve test.local:8082:127.0.0.1 https://test.local:8082 -kv -u foo:bar
```

and

```ps1
curl --resolve test.local:8082:127.0.0.1 https://test.local:8082 -kv
```

> Note TLS is optional for this example (That is, the `spec.tls` of the Ingress resource is optional). But in production, TLS is required for HTTP Basic Authentication.

See more on Basic Authentication at https://kubernetes.github.io/ingress-nginx/examples/auth/basic/.
