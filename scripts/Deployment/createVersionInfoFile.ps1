Write-Host "Create Version-Info File"

New-Item "versioninfo.txt"
Set-Content "versioninfo.txt" $(Release.Artifacts.BrandCi.BrandBookV2.SourceVersion)