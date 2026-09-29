# Builds the core submodule and places camillia_core.dll + C# bindings in Generated\.
# Usage: scripts\build-core.ps1 [-Profile debug|release]
param([ValidateSet("debug", "release")][string]$Profile = "release")
$ErrorActionPreference = "Stop"

$Root = Resolve-Path (Join-Path $PSScriptRoot "..")
if (-not (Test-Path (Join-Path $Root "core\Cargo.toml"))) {
    git -C $Root submodule update --init
}
& (Join-Path $Root "core\scripts\build-windows.ps1") -OutDir (Join-Path $Root "Generated") -Profile $Profile
