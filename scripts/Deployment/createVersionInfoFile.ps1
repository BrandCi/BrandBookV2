$sourceVersion = $args[0]



Write-Host "Create Version-Info File"

New-Item "versioninfo.txt"
Set-Content "versioninfo.txt" "$sourceVersion"