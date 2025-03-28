# Stateless Application Example

See https://kubernetes.io/docs/tutorials/stateless-application/guestbook/

Run it by

```cmd
kubectl apply -f .
```

Then setup a local port forward by

```cmd
kubectl port-forward services/frontend 8080:80
```

Then access "http://localhost:8080" in a browser.
