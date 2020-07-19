$artifactAlias = "BrandCi.BrandBookV2"
$versionInfoFileName = "$(System.DefaultWorkingDirectory)/" + $artifactAlias + "/drop/versioninfo.txt"


Write-Host "Create Version-Info File"

New-Item $versionInfoFileName
Set-Content $versionInfoFileName "$(Release.Artifacts." + $artifactAlias + ".SourceVersion)"