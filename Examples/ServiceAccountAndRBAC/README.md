# Service Account And RBAC

Refer to

* https://kubernetes.io/docs/concepts/security/service-accounts/
* https://kubernetes.io/docs/reference/access-authn-authz/rbac/

The the entry point of image `louirobert/k8s-example-pod-reader` is the [GenericClient](../../ExamplesOfApiClient/GenericClient/). The image is published with

```ps1
dotnet publish --os linux --arch x64 /t:PublishContainer /p:ContainerRegistry=docker.io /p:ContainerRepository=louirobert/k8s-example-pod-reader /p:EnableSdkContainerSupport=true
```
