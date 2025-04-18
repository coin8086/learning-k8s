# slurm

![Version: 0.2.1](https://img.shields.io/badge/Version-0.2.1-informational?style=flat-square) ![Type: application](https://img.shields.io/badge/Type-application-informational?style=flat-square) ![AppVersion: 24.11](https://img.shields.io/badge/AppVersion-24.11-informational?style=flat-square)

Helm Chart for Slurm HPC Workload Manager

## Requirements

| Repository | Name | Version |
|------------|------|---------|
| oci://ghcr.io/slinkyproject/charts | slurm-exporter | ~0.2.1 |
| oci://registry-1.docker.io/bitnamicharts | mariadb | ~16.3 |

## Values

| Key | Type | Default | Description |
|-----|------|---------|-------------|
| accounting.affinity | object | `{}` |  Set affinity for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/scheduling-eviction/assign-pod-node/#affinity-and-anti-affinity |
| accounting.enabled | bool | `true` |  Enables accounting services. |
| accounting.external.enabled | bool | `false` |  Use an external acounting instance (slurmdbd) instead of deploying one. |
| accounting.external.host | string | `""` |  The external acounting instance (slurmdbd) host. |
| accounting.external.port | integer | `6819` |  The external acounting instance (slurmdbd) port. |
| accounting.image.repository | string | `"ghcr.io/slinkyproject/slurmdbd"` |  Set the image repository to use. |
| accounting.image.tag | string | `"24.11-ubuntu24.04"` |  Set the image tag to use. |
| accounting.imagePullPolicy | string | `"IfNotPresent"` |  Set the image pull policy. |
| accounting.replicas | integer | `1` |  Set the number of replicas to deploy. |
| accounting.resources | object | `{}` |  Set container resource requests and limits for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#resource-requests-and-limits-of-pod-and-container |
| authcred.image.repository | string | `"ghcr.io/slinkyproject/sackd"` |  Set the image repository to use. |
| authcred.image.tag | string | `"24.11-ubuntu24.04"` |  Set the image tag to use. |
| authcred.imagePullPolicy | string | `"IfNotPresent"` |  Set the image pull policy. |
| authcred.resources | object | `{}` |  Set container resource requests and limits for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#resource-requests-and-limits-of-pod-and-container |
| compute.image.repository | string | `"ghcr.io/slinkyproject/slurmd"` |  Set the image repository to use. |
| compute.image.tag | string | The Release appVersion. |  Set the image tag to use. |
| compute.imagePullPolicy | string | `"IfNotPresent"` |  Set the image pull policy. |
| compute.nodesets | list | `[{"affinity":{},"enabled":true,"image":{"repository":"","tag":""},"imagePullPolicy":"IfNotPresent","name":"debug","nodeFeatures":[],"nodeGres":"","nodeSelector":{"kubernetes.io/os":"linux"},"nodeWeight":1,"partition":{"config":"State=UP MaxTime=UNLIMITED","enabled":true},"persistentVolumeClaimRetentionPolicy":{"whenDeleted":"Retain","whenScaled":"Retain"},"priorityClassName":"","replicas":1,"resources":{"limits":{"cpu":1,"memory":"1Gi"}},"updateStrategy":{"rollingUpdate":{"maxUnavailable":"20%"},"type":"RollingUpdate"},"volumeClaimTemplates":[]}]` |  Slurm NodeSets by object list. |
| compute.nodesets[0] | string | `{"affinity":{},"enabled":true,"image":{"repository":"","tag":""},"imagePullPolicy":"IfNotPresent","name":"debug","nodeFeatures":[],"nodeGres":"","nodeSelector":{"kubernetes.io/os":"linux"},"nodeWeight":1,"partition":{"config":"State=UP MaxTime=UNLIMITED","enabled":true},"persistentVolumeClaimRetentionPolicy":{"whenDeleted":"Retain","whenScaled":"Retain"},"priorityClassName":"","replicas":1,"resources":{"limits":{"cpu":1,"memory":"1Gi"}},"updateStrategy":{"rollingUpdate":{"maxUnavailable":"20%"},"type":"RollingUpdate"},"volumeClaimTemplates":[]}` |  Name of NodeSet. Must be unique. |
| compute.nodesets[0].affinity | object | `{}` |  Set affinity for Kubernetes Pod scheduling. |
| compute.nodesets[0].enabled | bool | `true` |  Enables the NodeSet in Slurm. |
| compute.nodesets[0].image.repository | string | `""` |  Set the image repository to use. |
| compute.nodesets[0].image.tag | string | `""` |  Set the image tag to use. |
| compute.nodesets[0].imagePullPolicy | string | `"IfNotPresent"` |  Set the image pull policy. |
| compute.nodesets[0].nodeFeatures | list | `[]` |  Set Slurm node Features as a list(string). Ref: https://slurm.schedmd.com/slurm.conf.html#OPT_Features |
| compute.nodesets[0].nodeGres | string | `""` |  Set Slurm node GRES. Ref: https://slurm.schedmd.com/slurm.conf.html#OPT_Gres_1 |
| compute.nodesets[0].nodeSelector | map | `{"kubernetes.io/os":"linux"}` |  Selector which must match a node's labels for the pod to be scheduled on that node. |
| compute.nodesets[0].nodeWeight | string | `1` |  Set Slurm node weight for Slurm scheduling. Ref: https://slurm.schedmd.com/slurm.conf.html#OPT_Weight |
| compute.nodesets[0].partition | object | `{"config":"State=UP MaxTime=UNLIMITED","enabled":true}` |  Partition describes the partition created specifically for this NodeSet to be added. |
| compute.nodesets[0].partition.config | string | `"State=UP MaxTime=UNLIMITED"` |  Extra Slurm partition configuration appended onto the partition line. Ref: https://slurm.schedmd.com/slurm.conf.html#lbAI |
| compute.nodesets[0].partition.enabled | bool | `true` |  Enables this NodeSet's partition line to be added in Slurm. |
| compute.nodesets[0].persistentVolumeClaimRetentionPolicy | object | `{"whenDeleted":"Retain","whenScaled":"Retain"}` |  The policy used for PVCs created from the NodeSet VolumeClaimTemplates. |
| compute.nodesets[0].persistentVolumeClaimRetentionPolicy.whenDeleted | string | `"Retain"` |  WhenDeleted specifies what happens to PVCs created from NodeSet VolumeClaimTemplates when the NodeSet is deleted. The default policy of `Retain` causes PVCs to not be affected by NodeSet deletion. The `Delete` policy causes those PVCs to be deleted. |
| compute.nodesets[0].persistentVolumeClaimRetentionPolicy.whenScaled | string | `"Retain"` |  WhenScaled specifies what happens to PVCs created from NodeSet VolumeClaimTemplates when the NodeSet is scaled down. The default policy of `Retain` causes PVCs to not be affected by a scale-in. The `Delete` policy causes the associated PVCs for any excess pods to be deleted. |
| compute.nodesets[0].priorityClassName | string | `""` |  Set the priority class to use. Ref: https://kubernetes.io/docs/concepts/scheduling-eviction/pod-priority-preemption/#priorityclass |
| compute.nodesets[0].replicas | integer | `1` |  Set the number of replicas to deploy. |
| compute.nodesets[0].resources | object | `{"limits":{"cpu":1,"memory":"1Gi"}}` |  Set container resource requests and limits for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#resource-requests-and-limits-of-pod-and-container |
| compute.nodesets[0].updateStrategy | object | `{"rollingUpdate":{"maxUnavailable":"20%"},"type":"RollingUpdate"}` |  Set the update strategy configuration. |
| compute.nodesets[0].updateStrategy.rollingUpdate | object | `{"maxUnavailable":"20%"}` |  Define the rolling update policy. Only used when "updateStrategy.type=RollingUpdate". |
| compute.nodesets[0].updateStrategy.rollingUpdate.maxUnavailable | string | `"20%"` |  The maximum number of pods that can be unavailable during the update. Value can be an absolute number (ex: 5) or a percentage of desired pods (ex: 10%). Absolute number is calculated from percentage by rounding up. This can not be 0. Defaults to 1. |
| compute.nodesets[0].updateStrategy.type | string | `"RollingUpdate"` |  Set the update strategy type. Can be either: "RollingUpdate"; "OnDelete". |
| compute.nodesets[0].volumeClaimTemplates | list | `[]` |  List of claims that pods are allowed to reference. The NodeSet controller is responsible for mapping network identities to claims in a way that maintains the identity of a pod. |
| compute.partitions | list | `[{"config":"State=UP Default=YES MaxTime=UNLIMITED","enabled":true,"name":"all","nodesets":["ALL"]}]` |  Slurm Partitions by object list. |
| compute.partitions[0] | string | `{"config":"State=UP Default=YES MaxTime=UNLIMITED","enabled":true,"name":"all","nodesets":["ALL"]}` |  Name of Partition. Must be unique. |
| compute.partitions[0].config | string | `"State=UP Default=YES MaxTime=UNLIMITED"` |  Extra Slurm partition configuration appended onto the partition line. Ref: https://slurm.schedmd.com/slurm.conf.html#lbAI |
| compute.partitions[0].enabled | bool | `true` |  Enables the partition in Slurm. |
| compute.partitions[0].nodesets | list | `["ALL"]` |  NodeSets to put into this Partition by name/key. NOTE: 'ALL' is a Slurm meta value to mean all nodes in the system. |
| controller.affinity | object | `{}` |  Set affinity for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/scheduling-eviction/assign-pod-node/#affinity-and-anti-affinity |
| controller.enabled | bool | `true` |  Enables the controller node. |
| controller.image.repository | string | `"ghcr.io/slinkyproject/slurmctld"` |  Set the image repository to use. |
| controller.image.tag | string | `"24.11-ubuntu24.04"` |  Set the image tag to use. |
| controller.imagePullPolicy | string | `"IfNotPresent"` |  Set the image pull policy. |
| controller.persistence.accessModes | list | `["ReadWriteOnce"]` |  Create a `PersistentVolumeClaim` with these access modes. |
| controller.persistence.annotations | object | `{}` |  Create a `PersistentVolumeClaim` with these annotations. |
| controller.persistence.existingClaim | string | `""` |  Name of an existing `PersistentVolumeClaim` to use instead of creating one from definition. NOTE: When not empty, the other persistence fields will be ignored. |
| controller.persistence.labels | object | `{}` |  Create a `PersistentVolumeClaim` with these labels. |
| controller.persistence.selector | object | `{}` |  Selector to match an existing `PersistentVolume`. |
| controller.persistence.size | string | `"4Gi"` |  Create a `PersistentVolumeClaim` with this storage size. |
| controller.persistence.storageClass | string | `"standard"` |  Create a `PersistentVolumeClaim` with this storage class. |
| controller.priorityClassName | string | `nil` |  Set the priority class to use. Ref: https://kubernetes.io/docs/concepts/scheduling-eviction/pod-priority-preemption/#priorityclass |
| controller.replicas | integer | `1` |  Set the number of replicas to deploy. |
| controller.resources | object | `{}` |  Set container resource requests and limits for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#resource-requests-and-limits-of-pod-and-container |
| fullnameOverride | string | `""` |  Overrides the full name of the release. |
| imagePullPolicy | string | `"IfNotPresent"` |  Set the image pull policy. |
| imagePullSecrets | list | `[]` |  Set the secrets for image pull. Ref: https://kubernetes.io/docs/tasks/configure-pod-container/pull-image-private-registry/ |
| jwt.hs256.existingSecret | string | `""` |  The existing secret to use otherwise one will be generated. |
| mariadb.affinity | object | `{}` |  |
| mariadb.auth.database | string | `"slurm_acct_db"` |  |
| mariadb.auth.existingSecret | string | `"slurm-mariadb-passwords"` |  |
| mariadb.auth.username | string | `"slurm"` |  |
| mariadb.enabled | bool | `true` |  |
| mariadb.metrics.enabled | bool | `false` |  |
| mariadb.metrics.serviceMonitor.enabled | bool | `false` |  |
| mariadb.primary.configuration | string | `"[mysqld]\nskip-name-resolve\nexplicit_defaults_for_timestamp\nbasedir=/opt/bitnami/mariadb\ndatadir=/bitnami/mariadb/data\nplugin_dir=/opt/bitnami/mariadb/plugin\nport={{ .Values.primary.containerPorts.mysql }}\nsocket=/opt/bitnami/mariadb/tmp/mysql.sock\ntmpdir=/opt/bitnami/mariadb/tmp\ninnodb_buffer_pool_size=4096M\ninnodb_lock_wait_timeout=900\ninnodb_log_file_size=1024M\nmax_allowed_packet=16M\nbind-address=*\npid-file=/opt/bitnami/mariadb/tmp/mysqld.pid\nlog-error=/opt/bitnami/mariadb/logs/mysqld.log\ncharacter-set-server=UTF8\ncollation-server=utf8_general_ci\nslow_query_log=0\nlong_query_time=10.0\nbinlog_expire_logs_seconds=2592000\n{{- if .Values.tls.enabled }}\nssl_cert=/opt/bitnami/mariadb/certs/{{ .Values.tls.certFilename }}\nssl_key=/opt/bitnami/mariadb/certs/{{ .Values.tls.certKeyFilename }}\n{{- if (include \"mariadb.tlsCACert\" .) }}\nssl_ca={{ include \"mariadb.tlsCACert\" . }}\n{{- end }}\n{{- end }}\n{{- if .Values.tde.enabled }}\nplugin_load_add=file_key_management\nfile_key_management_filename=/opt/bitnami/mariadb/tde/{{ .Values.tde.encryptedKeyFilename }}\nfile_key_management_filekey=FILE:/opt/bitnami/mariadb/tde/{{ .Values.tde.randomKeyFilename }}\nfile_key_management_encryption_algorithm={{ .Values.tde.fileKeyManagementEncryptionAlgorithm }}\ninnodb_encrypt_tables={{ .Values.tde.innodbEncryptTables }}\ninnodb_encrypt_log={{ .Values.tde.innodbEncryptLog }}\ninnodb_encrypt_temporary_tables={{ .Values.tde.innodbEncryptTemporaryTables }}\ninnodb_encryption_threads={{ .Values.tde.innodbEncryptionThreads }}\nencrypt_tmp_disk_tables={{ .Values.tde.encryptTmpDiskTables }}\nencrypt_tmp_files={{ .Values.tde.encryptTmpTiles }}\nencrypt_binlog={{ .Values.tde.encryptBINLOG }}\naria_encrypt_tables={{ .Values.tde.ariaEncryptTables }}\n{{- end }}\n\n[client]\nport=3306\nsocket=/opt/bitnami/mariadb/tmp/mysql.sock\ndefault-character-set=UTF8\nplugin_dir=/opt/bitnami/mariadb/plugin\n\n[manager]\nport=3306\nsocket=/opt/bitnami/mariadb/tmp/mysql.sock\npid-file=/opt/bitnami/mariadb/tmp/mysqld.pid"` |  |
| mariadb.primary.persistence.accessModes[0] | string | `"ReadWriteOnce"` |  |
| mariadb.primary.persistence.annotations | object | `{}` |  |
| mariadb.primary.persistence.enabled | bool | `true` |  |
| mariadb.primary.persistence.existingClaim | string | `""` |  |
| mariadb.primary.persistence.labels | object | `{}` |  |
| mariadb.primary.persistence.selector | object | `{}` |  |
| mariadb.primary.persistence.size | string | `"8Gi"` |  |
| mariadb.primary.persistence.storageClass | string | `"standard"` |  |
| mariadb.primary.priorityClassName | string | `""` |  |
| mariadb.resources | object | `{}` |  |
| mariadb.tde.enabled | bool | `false` |  |
| mariadb.tls.enabled | bool | `false` |  |
| nameOverride | string | `""` |  Overrides the name of the release. |
| namespaceOverride | string | `""` |  Overrides the namespace of the release. |
| priorityClassName | string | `""` |  Set the priority class to use. Ref: https://kubernetes.io/docs/concepts/scheduling-eviction/pod-priority-preemption/#priorityclass |
| restapi.affinity | object | `{}` |  Set affinity for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/scheduling-eviction/assign-pod-node/#affinity-and-anti-affinity |
| restapi.enabled | bool | `true` |  Enables restapi services. |
| restapi.image.repository | string | `"ghcr.io/slinkyproject/slurmrestd"` |  Set the image repository to use. |
| restapi.image.tag | string | `"24.11-ubuntu24.04"` |  Set the image tag to use. |
| restapi.imagePullPolicy | string | `"IfNotPresent"` |  Set the image pull policy. |
| restapi.priorityClassName | string | `""` |  Set the priority class to use. Ref: https://kubernetes.io/docs/concepts/scheduling-eviction/pod-priority-preemption/#priorityclass |
| restapi.replicas | integer | `1` |  Set the number of replicas to deploy. |
| restapi.resources | object | `{}` |  Set container resource requests and limits for Kubernetes Pod scheduling. Ref: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/#resource-requests-and-limits-of-pod-and-container |
| slurm-exporter.enabled | bool | `true` |  |
| slurm-exporter.exporter.enabled | bool | `true` |  |
| slurm-exporter.exporter.secretName | string | `"slurm-token-exporter"` |  |
| slurm.auth.existingSecret | string | `""` |  The existing secret to use otherwise one will be generated. |
| slurm.configFiles | map[string]string | `{}` |  Optional raw Slurm configuration files, as a map. The map key represents the config file by name; the map value represents config file contents as a string. Ref: https://slurm.schedmd.com/man_index.html#configuration_files |
| slurm.epilogScripts | map[string]string | `{}` |  The Epilog scripts for compute nodesets, as a map. The map key represents the filename; the map value represents the script contents. WARNING: The script must include a shebang (!) so it can be executed correctly by Slurm. Ref: https://slurm.schedmd.com/slurm.conf.html#OPT_Epilog Ref: https://slurm.schedmd.com/prolog_epilog.html Ref: https://en.wikipedia.org/wiki/Shebang_(Unix) |
| slurm.extraSlurmConf | string | `"MaxNodeCount=1024\nReturnToService=2\nEnforcePartLimits=NO\n#\n### PLUGINS & PARAMETERS ###\nSchedulerType=sched/backfill\nSchedulerParameters=defer_batch\nSelectType=select/cons_tres\nSelectTypeParameters=CR_Core_Memory\nSlurmctldParameters=enable_configless,enable_stepmgr\nSlurmdParameters=contain_spank\nCommunicationParameters=block_null_hash\nLaunchParameters=enable_nss_slurm,use_interactive_step,ulimit_pam_adopt\n#ReconfigFlags=KeepPartInfo,KeepPartState\nPrologFlags=Contain\nHashPlugin=hash/k12\n#\n### LOGGING ###\nSlurmctldDebug=info\nSlurmSchedLogLevel=1\nSlurmdDebug=info\n#DebugFlags=\nLogTimeFormat=iso8601_ms"` |  Extra slurm configuration lines to append to `slurm.conf`. WARNING: Values can override existing ones. Ref: https://slurm.schedmd.com/slurm.conf.html |
| slurm.extraSlurmdbdConf | string | `"CommitDelay=1\n#\n### LOGGING ###\nDebugLevel=info\n#DebugFlags=\nLogTimeFormat=iso8601_ms\n#\n# PLUGINS & PARAMETERS\n#CommunicationParameters=\nHashPlugin=hash/k12\n#\n### ARCHIVE ###\nArchiveDir=/tmp\n#ArchiveEvents=YES\n#ArchiveJobs=YES\n#ArchiveResvs=YES\n#ArchiveSteps=NO\n#ArchiveSuspend=NO\n#ArchiveTXN=NO\n#ArchiveUsage=NO\n#\n### PURGE ###\n#PurgeEventAfter=12month\n#PurgeJobAfter=12month\n#PurgeResvAfter=2month\n#PurgeStepAfter=2month\n#PurgeSuspendAfter=1month\n#PurgeTXNAfter=12month\n#PurgeUsageAfter=12month"` |  Extra slurmdbd configuration lines to append to `slurmdbd.conf`. WARNING: Values can override existing ones. Ref: https://slurm.schedmd.com/slurmdbd.conf.html |
| slurm.prologScripts | map[string]string | `{}` |  The Prolog scripts for compute nodesets, as a map. The map key represents the filename; the map value represents the script contents. WARNING: The script must include a shebang (!) so it can be executed correctly by Slurm. Ref: https://slurm.schedmd.com/slurm.conf.html#OPT_Prolog Ref: https://slurm.schedmd.com/prolog_epilog.html Ref: https://en.wikipedia.org/wiki/Shebang_(Unix) |

