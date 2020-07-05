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
    "Url: " + $url + "`n" + "Status: " + $response.StatusCode + "`n`n"

}


Read-Host