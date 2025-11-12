# Helm Chart Hooks

The example shows various hooks.

```
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v1 [main]> helm install hooks . -n n3 --create-namespace
NAME: hooks
LAST DEPLOYED: Wed Jul 16 08:40:05 2025
NAMESPACE: n3
STATUS: deployed
REVISION: 1
TEST SUITE: None
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v1 [main]> helm list -A
NAME    NAMESPACE       REVISION        UPDATED                                 STATUS          CHART           APP VERSION
hooks   n3              1               2025-07-16 08:40:05.9476901 +0800 CST   deployed        hooks-0.1.0     1.0.0
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v1 [main]> kubectl.exe get all -n n3
NAME                                  READY   STATUS      RESTARTS   AGE
pod/hello-hooks-1-7cd697b954-7fpfj    1/1     Running     0          12s
pod/post-install-hook-hooks-1-smhvb   0/1     Completed   0          12s
pod/pre-install-hook-hooks-1-vmz2d    0/1     Completed   0          15s

NAME                            READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/hello-hooks-1   1/1     1            1           12s

NAME                                       DESIRED   CURRENT   READY   AGE
replicaset.apps/hello-hooks-1-7cd697b954   1         1         1       12s

NAME                                  STATUS     COMPLETIONS   DURATION   AGE
job.batch/post-install-hook-hooks-1   Complete   1/1           3s         12s
job.batch/pre-install-hook-hooks-1    Complete   1/1           2s         15s
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v1 [main]> cd ..\hooks-v2\
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v2 [main]> helm upgrade hooks . -n n3
Release "hooks" has been upgraded. Happy Helming!
NAME: hooks
LAST DEPLOYED: Wed Jul 16 08:41:55 2025
NAMESPACE: n3
STATUS: deployed
REVISION: 2
TEST SUITE: None
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v2 [main]> helm list -A
NAME    NAMESPACE       REVISION        UPDATED                                 STATUS          CHART           APP VERSION
hooks   n3              2               2025-07-16 08:41:55.0937919 +0800 CST   deployed        hooks-0.2.0     1.0.0
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v2 [main]> kubectl.exe get all -n n3
NAME                                     READY   STATUS      RESTARTS   AGE
pod/post-install-hook-hooks-1-smhvb      0/1     Completed   0          2m20s
pod/pre-install-hook-hooks-1-vmz2d       0/1     Completed   0          2m23s
pod/v2-hello-hooks-2-7cd697b954-ddxds    1/1     Running     0          31s
pod/v2-post-upgrade-hook-hooks-2-g7xr9   0/1     Completed   0          31s
pod/v2-pre-upgrade-hook-hooks-2-p7kvf    0/1     Completed   0          34s

NAME                               READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/v2-hello-hooks-2   1/1     1            1           31s

NAME                                          DESIRED   CURRENT   READY   AGE
replicaset.apps/v2-hello-hooks-2-7cd697b954   1         1         1       31s

NAME                                     STATUS     COMPLETIONS   DURATION   AGE
job.batch/post-install-hook-hooks-1      Complete   1/1           3s         2m20s
job.batch/pre-install-hook-hooks-1       Complete   1/1           2s         2m23s
job.batch/v2-post-upgrade-hook-hooks-2   Complete   1/1           4s         31s
job.batch/v2-pre-upgrade-hook-hooks-2    Complete   1/1           3s         34s
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v2 [main]> helm rollback hooks -n n3
Rollback was a success! Happy Helming!
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v2 [main]> helm list -A
NAME    NAMESPACE       REVISION        UPDATED                                 STATUS          CHART           APP VERSION
hooks   n3              3               2025-07-16 08:44:18.1742158 +0800 CST   deployed        hooks-0.1.0     1.0.0
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v2 [main]> kubectl.exe get all -n n3
NAME                                     READY   STATUS      RESTARTS   AGE
pod/hello-hooks-1-7cd697b954-9d4kk       1/1     Running     0          22s
pod/post-install-hook-hooks-1-smhvb      0/1     Completed   0          4m34s
pod/post-rollback-hook-hooks-1-r284z     0/1     Completed   0          22s
pod/pre-install-hook-hooks-1-vmz2d       0/1     Completed   0          4m37s
pod/pre-rollback-hook-hooks-1-kxftg      0/1     Completed   0          25s
pod/v2-post-upgrade-hook-hooks-2-g7xr9   0/1     Completed   0          2m45s
pod/v2-pre-upgrade-hook-hooks-2-p7kvf    0/1     Completed   0          2m48s

NAME                            READY   UP-TO-DATE   AVAILABLE   AGE
deployment.apps/hello-hooks-1   1/1     1            1           22s

NAME                                       DESIRED   CURRENT   READY   AGE
replicaset.apps/hello-hooks-1-7cd697b954   1         1         1       22s

NAME                                     STATUS     COMPLETIONS   DURATION   AGE
job.batch/post-install-hook-hooks-1      Complete   1/1           3s         4m34s
job.batch/post-rollback-hook-hooks-1     Complete   1/1           4s         22s
job.batch/pre-install-hook-hooks-1       Complete   1/1           2s         4m37s
job.batch/pre-rollback-hook-hooks-1      Complete   1/1           3s         25s
job.batch/v2-post-upgrade-hook-hooks-2   Complete   1/1           4s         2m45s
job.batch/v2-pre-upgrade-hook-hooks-2    Complete   1/1           3s         2m48s
C:\code\learning-k8s\ExamplesOfChart\hooks\hooks-v2 [main]> helm uninstall hooks -n n3
release "hooks" uninstalled
```

The events show the hooks.

```
C:\code\learning-k8s\ExamplesOfChart\hooks [main]> kubectl.exe events -n n3 --watch
LAST SEEN   TYPE     REASON             OBJECT                         MESSAGE
0s          Normal   SuccessfulCreate   Job/pre-install-hook-hooks-1   Created pod: pre-install-hook-hooks-1-vmz2d
0s          Normal   Scheduled          Pod/pre-install-hook-hooks-1-vmz2d   Successfully assigned n3/pre-install-hook-hooks-1-vmz2d to kind-worker
0s          Normal   Pulled             Pod/pre-install-hook-hooks-1-vmz2d   Container image "busybox:1.37.0" already present on machine
0s          Normal   Created            Pod/pre-install-hook-hooks-1-vmz2d   Created container: pre-install-hook-hooks-1
0s          Normal   Started            Pod/pre-install-hook-hooks-1-vmz2d   Started container pre-install-hook-hooks-1
0s          Normal   Completed          Job/pre-install-hook-hooks-1         Job completed
0s          Normal   ScalingReplicaSet   Deployment/hello-hooks-1             Scaled up replica set hello-hooks-1-7cd697b954 from 0 to 1
0s          Normal   SuccessfulCreate    ReplicaSet/hello-hooks-1-7cd697b954   Created pod: hello-hooks-1-7cd697b954-7fpfj
0s          Normal   Scheduled           Pod/hello-hooks-1-7cd697b954-7fpfj    Successfully assigned n3/hello-hooks-1-7cd697b954-7fpfj to kind-worker2
0s          Normal   SuccessfulCreate    Job/post-install-hook-hooks-1         Created pod: post-install-hook-hooks-1-smhvb
0s          Normal   Scheduled           Pod/post-install-hook-hooks-1-smhvb   Successfully assigned n3/post-install-hook-hooks-1-smhvb to kind-worker3
0s          Normal   Pulled              Pod/hello-hooks-1-7cd697b954-7fpfj    Container image "nginx:1.29.0" already present on machine
0s          Normal   Pulled              Pod/post-install-hook-hooks-1-smhvb   Container image "busybox:1.37.0" already present on machine
0s          Normal   Created             Pod/hello-hooks-1-7cd697b954-7fpfj    Created container: my-nginx
0s          Normal   Created             Pod/post-install-hook-hooks-1-smhvb   Created container: post-install-hook-hooks-1
0s          Normal   Started             Pod/hello-hooks-1-7cd697b954-7fpfj    Started container my-nginx
0s          Normal   Started             Pod/post-install-hook-hooks-1-smhvb   Started container post-install-hook-hooks-1
0s          Normal   Completed           Job/post-install-hook-hooks-1         Job completed
0s          Normal   SuccessfulCreate    Job/v2-pre-upgrade-hook-hooks-2       Created pod: v2-pre-upgrade-hook-hooks-2-p7kvf
0s          Normal   Scheduled           Pod/v2-pre-upgrade-hook-hooks-2-p7kvf   Successfully assigned n3/v2-pre-upgrade-hook-hooks-2-p7kvf to kind-worker
0s          Normal   Pulled              Pod/v2-pre-upgrade-hook-hooks-2-p7kvf   Container image "busybox:1.37.0" already present on machine
0s          Normal   Created             Pod/v2-pre-upgrade-hook-hooks-2-p7kvf   Created container: pre-upgrade-hook-hooks-2
0s          Normal   Started             Pod/v2-pre-upgrade-hook-hooks-2-p7kvf   Started container pre-upgrade-hook-hooks-2
0s          Normal   Completed           Job/v2-pre-upgrade-hook-hooks-2         Job completed
0s          Normal   ScalingReplicaSet   Deployment/v2-hello-hooks-2             Scaled up replica set v2-hello-hooks-2-7cd697b954 from 0 to 1
0s          Normal   SuccessfulCreate    ReplicaSet/v2-hello-hooks-2-7cd697b954   Created pod: v2-hello-hooks-2-7cd697b954-ddxds
0s          Normal   Scheduled           Pod/v2-hello-hooks-2-7cd697b954-ddxds    Successfully assigned n3/v2-hello-hooks-2-7cd697b954-ddxds to kind-worker3
0s          Normal   Killing             Pod/hello-hooks-1-7cd697b954-7fpfj       Stopping container my-nginx
0s          Normal   SuccessfulCreate    Job/v2-post-upgrade-hook-hooks-2         Created pod: v2-post-upgrade-hook-hooks-2-g7xr9
0s          Normal   Scheduled           Pod/v2-post-upgrade-hook-hooks-2-g7xr9   Successfully assigned n3/v2-post-upgrade-hook-hooks-2-g7xr9 to kind-worker
0s          Normal   Pulled              Pod/v2-hello-hooks-2-7cd697b954-ddxds    Container image "nginx:1.29.0" already present on machine
0s          Normal   Pulled              Pod/v2-post-upgrade-hook-hooks-2-g7xr9   Container image "busybox:1.37.0" already present on machine
0s          Normal   Created             Pod/v2-hello-hooks-2-7cd697b954-ddxds    Created container: my-nginx
0s          Normal   Created             Pod/v2-post-upgrade-hook-hooks-2-g7xr9   Created container: post-upgrade-hook-hooks-2
0s          Normal   Started             Pod/v2-hello-hooks-2-7cd697b954-ddxds    Started container my-nginx
0s          Normal   Started             Pod/v2-post-upgrade-hook-hooks-2-g7xr9   Started container post-upgrade-hook-hooks-2
0s          Normal   Completed           Job/v2-post-upgrade-hook-hooks-2         Job completed
0s          Normal   SuccessfulCreate    Job/pre-rollback-hook-hooks-1            Created pod: pre-rollback-hook-hooks-1-kxftg
0s          Normal   Scheduled           Pod/pre-rollback-hook-hooks-1-kxftg      Successfully assigned n3/pre-rollback-hook-hooks-1-kxftg to kind-worker
0s          Normal   Pulled              Pod/pre-rollback-hook-hooks-1-kxftg      Container image "busybox:1.37.0" already present on machine
0s          Normal   Created             Pod/pre-rollback-hook-hooks-1-kxftg      Created container: pre-rollback-hook-hooks-1
0s          Normal   Started             Pod/pre-rollback-hook-hooks-1-kxftg      Started container pre-rollback-hook-hooks-1
0s          Normal   Completed           Job/pre-rollback-hook-hooks-1            Job completed
0s          Normal   ScalingReplicaSet   Deployment/hello-hooks-1                 Scaled up replica set hello-hooks-1-7cd697b954 from 0 to 1
0s          Normal   SuccessfulCreate    ReplicaSet/hello-hooks-1-7cd697b954      Created pod: hello-hooks-1-7cd697b954-9d4kk
0s          Normal   Scheduled           Pod/hello-hooks-1-7cd697b954-9d4kk       Successfully assigned n3/hello-hooks-1-7cd697b954-9d4kk to kind-worker
0s          Normal   Killing             Pod/v2-hello-hooks-2-7cd697b954-ddxds    Stopping container my-nginx
0s          Normal   SuccessfulCreate    Job/post-rollback-hook-hooks-1           Created pod: post-rollback-hook-hooks-1-r284z
0s          Normal   Scheduled           Pod/post-rollback-hook-hooks-1-r284z     Successfully assigned n3/post-rollback-hook-hooks-1-r284z to kind-worker2
0s          Normal   Pulled              Pod/hello-hooks-1-7cd697b954-9d4kk       Container image "nginx:1.29.0" already present on machine
0s          Normal   Pulled              Pod/post-rollback-hook-hooks-1-r284z     Container image "busybox:1.37.0" already present on machine
0s          Normal   Created             Pod/hello-hooks-1-7cd697b954-9d4kk       Created container: my-nginx
0s          Normal   Created             Pod/post-rollback-hook-hooks-1-r284z     Created container: post-rollback-hook-hooks-1
0s          Normal   Started             Pod/hello-hooks-1-7cd697b954-9d4kk       Started container my-nginx
0s          Normal   Started             Pod/post-rollback-hook-hooks-1-r284z     Started container post-rollback-hook-hooks-1
0s          Normal   Completed           Job/post-rollback-hook-hooks-1           Job completed
0s          Normal   SuccessfulCreate    Job/pre-delete-hook-hooks-1              Created pod: pre-delete-hook-hooks-1-qpwfj
0s          Normal   Scheduled           Pod/pre-delete-hook-hooks-1-qpwfj        Successfully assigned n3/pre-delete-hook-hooks-1-qpwfj to kind-worker3
0s          Normal   Pulled              Pod/pre-delete-hook-hooks-1-qpwfj        Container image "busybox:1.37.0" already present on machine
0s          Normal   Created             Pod/pre-delete-hook-hooks-1-qpwfj        Created container: pre-delete-hook-hooks-1
0s          Normal   Started             Pod/pre-delete-hook-hooks-1-qpwfj        Started container pre-delete-hook-hooks-1
0s          Normal   Completed           Job/pre-delete-hook-hooks-1              Job completed
0s          Normal   Killing             Pod/hello-hooks-1-7cd697b954-9d4kk       Stopping container my-nginx
0s          Normal   SuccessfulCreate    Job/post-delete-hook-hooks-1             Created pod: post-delete-hook-hooks-1-2rl7n
0s          Normal   Scheduled           Pod/post-delete-hook-hooks-1-2rl7n       Successfully assigned n3/post-delete-hook-hooks-1-2rl7n to kind-worker2
0s          Normal   Pulled              Pod/post-delete-hook-hooks-1-2rl7n       Container image "busybox:1.37.0" already present on machine
0s          Normal   Created             Pod/post-delete-hook-hooks-1-2rl7n       Created container: post-delete-hook-hooks-1
0s          Normal   Started             Pod/post-delete-hook-hooks-1-2rl7n       Started container post-delete-hook-hooks-1
0s          Normal   Completed           Job/post-delete-hook-hooks-1             Job completed
```

See more about Helm Chart Hooks at https://helm.sh/docs/topics/charts_hooks/.
