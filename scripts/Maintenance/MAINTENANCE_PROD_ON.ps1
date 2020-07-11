    [Void][Reflection.Assembly]::LoadWithPartialName("Microsoft.Web.Administration")

    $serverIP = "85.214.151.85"

	$app_siteName = "brandci.cloud"
	$app_Path = "C:\inetpub\vhosts\brandci.cloud\BrandCi\WEB\Production"

	$maint_siteName = "maintenance.brandci.cloud"
    $maint_Path = "C:\inetpub\vhosts\brandci.cloud\BrandCi\_Maintenance"

    $serverManager = New-Object Microsoft.Web.Administration.ServerManager

	#Application
    $app_Site = $serverManager.Sites | where { $_.Name -eq $app_siteName }
    $app_rootApp = $app_Site.Applications | where { $_.Path -eq "/" }
    $app_rootVdir = $app_rootApp.VirtualDirectories | where { $_.Path -eq "/" }
    $app_rootVdir.PhysicalPath = $maint_Path
	#./Application


	#Maintenance
	$maint_site = $serverManager.Sites | where { $_.Name -eq $maint_siteName }
    $maint_rootApp = $maint_site.Applications | where { $_.Path -eq "/" }
    $maint_rootVdir = $maint_rootApp.VirtualDirectories | where { $_.Path -eq "/" }
    $maint_rootVdir.PhysicalPath = $app_Path
	#./Maintenance


    $serverManager.CommitChanges()