$baseUrl = 'https://brandci.cloud'

$urls = @(
    '/Home/Index',
    '/Product/Overview',
    '/Product/Creation',
    '/Product/Documentation',
    '/Product/Collaboration',
    '/Product/Sharing',
    '/Product/Optimization'
)


Foreach ($url IN $urls)
{
    $completeUrl = $baseUrl + $url
    $response = Invoke-WebRequest -Uri $completeUrl -Method Get

    $statusCode = $response.StatusCode
    $statusCodeGroup = $statusCode.ToString().substring(0,1)


    $status = 'Yellow'
    if($statusCodeGroup -eq '2') {
        $status = 'Green'
    }
    elseif($statusCodeGroup -eq '4') {
        $status = 'Red'
    }
    elseif($statusCodeGroup -eq '5') {
        $status = 'Red'
    }
    

    # Output
    Write-Host "Url: " $url
    Write-Host "Status: " $statusCode "`n`n" -ForegroundColor $status

}


Write-Host "`n`n"
Write-Host "Warmup completed"
Write-Host "Touched" $urls.count "Routes"


Read-Host