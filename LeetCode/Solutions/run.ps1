param([string]$file)

if (-not $file) {
    Write-Host "Usage: .\run.ps1 0001_TwoSum"
    Write-Host "Available files:"
    Get-ChildItem "*.cs" | ForEach-Object { Write-Host "  - $($_.BaseName)" }
    return
}

dotnet script "$file.cs"