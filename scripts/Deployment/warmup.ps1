$baseUrl = 'https://brandci.cloud'

$urls = @(
    '/Home/Index',
    '/Product/Overview',
    '/Product/Creation',
    '/Product/Documentation',
    '/Product/Collaboration',
    '/Product/Sharing',
    '/Product/Optimization',
    '/Pricing/Index',
    '/Blog/Overview',
    '/Blog/Index',
    '/Support/Contact',
    '/Support/Faq',
    '/Auth/Login/Index',
    '/Auth/Register/Index',
    '/Auth/ForgotPassword',
    '/Legal/Imprint',
    '/Legal/PrivacyPolicy',
    '/Legal/Cookie',
    '/Legal/PrivacyRequest'
)


Foreach ($url IN $urls)
{
    #region Preparation
    $completeUrl = $baseUrl + $url
    $response = Invoke-WebRequest -Uri $completeUrl -Method Get

    $statusCode = $response.StatusCode
    $statusCodeGroup = $statusCode.ToString().substring(0,1)
    #endregion

    #region Determine Status
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
    #endregion

    #region Output
    Write-Host "Url: " $url
    Write-Host "Method: GET"
    Write-Host "Status: " $statusCode "`n`n" -ForegroundColor $status
    #endregion
}


Write-Host "`n`n"
Write-Host "Warmup completed"
Write-Host "Touched" $urls.count "Routes"

Read-Host