    [Void][Reflection.Assembly]::LoadWithPartialName("Microsoft.Web.Administration")

    $serverIP = "85.214.151.85"

	$app_siteName = "brandci.philipp-moser.de"
	$app_Path = "C:\inetpub\vhosts\philipp-moser.de\BrandCi\Production"

	$maint_siteName = "maintenance.brandci.philipp-moser.de"
    $maint_Path = "C:\inetpub\vhosts\philipp-moser.de\BrandCi\__MAINTENANCE__"

    $serverManager = New-Object Microsoft.Web.Administration.ServerManager

	#Application
    $app_Site = $serverManager.Sites | where { $_.Name -eq $app_siteName }
    $app_rootApp = $app_Site.Applications | where { $_.Path -eq "/" }
    $app_rootVdir = $app_rootApp.VirtualDirectories | where { $_.Path -eq "/" }
    $app_rootVdir.PhysicalPath = $app_Path
	#./Application


	#Maintenance
	$maint_site = $serverManager.Sites | where { $_.Name -eq $maint_siteName }
    $maint_rootApp = $maint_site.Applications | where { $_.Path -eq "/" }
    $maint_rootVdir = $maint_rootApp.VirtualDirectories | where { $_.Path -eq "/" }
    $maint_rootVdir.PhysicalPath = $maint_Path
	#./Maintenance


    $serverManager.CommitChanges()