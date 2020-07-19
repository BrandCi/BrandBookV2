$versionInfoFileName = "$(System.DefaultWorkingDirectory)/BrandCi.BrandBookV2/drop/versioninfo.txt"


Write-Host "Create Version-Info File"

New-Item $versionInfoFileName
Set-Content $versionInfoFileName "$(Release.Artifacts.BrandCi.BrandBookV2.SourceVersion)"