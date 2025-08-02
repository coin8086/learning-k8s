{{- /*
SPDX-FileCopyrightText: Copyright (C) SchedMD LLC.
SPDX-License-Identifier: Apache-2.0
*/}}

{{/*
Return the primary persistence existingClaim
*/}}
{{- define "mariadb.name" -}}
{{- printf "%s-mariadb" (.Release.Name) -}}
{{- end -}}

{{/*
Return the secret with MariaDB credentials
*/}}
{{- define "mariadb.secretName" -}}
{{- printf "%s-mariadb-passwords" (.Release.Name) -}}
{{- end -}}
