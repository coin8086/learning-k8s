{{/* Generate an array */}}
{{- define "doodle.array" }}
array:
{{- range tuple "a" "b" "c" }}
- {{ . }}:
  {{- range tuple 1 2 3 }}
  - {{ . }}
  {{- end }}
{{- end }}
{{- end }}

{{/* Generate a value for use in a single line. */}}
{{- define "name" }}
{{- default .Chart.Name .Values.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}
