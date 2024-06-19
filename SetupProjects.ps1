
param (
    [Parameter(Mandatory=$true)]
    [string] $ProjectName
)

$slnFileName = "LeetcodeMsft"

if (-not (Test-Path -Path $slnFileName.sln)) {
   dotnet new sln --name $slnFileName 
}

if (Test-Path -Path .\$ProjectName) {
    Write-Error "Error: The project name '$ProjectName' already exists. Please choose a different name."
    return
}


$projectFolder = $ProjectName
$slnFilePath = Get-Location

New-Item -ItemType Directory -Path .\$projectFolder

Push-Location
Set-Location .\$projectFolder

$libProjectName = "$projectFolder.Lib"
$testProjectName = "$projectFolder.Tests"

dotnet new classlib -n $libProjectName
dotnet new xunit -n $testProjectName
dotnet sln $slnFilePath add $libProjectName\$libProjectName.csproj
dotnet sln $slnFilePath add $testProjectName\$testProjectName.csproj
dotnet add $testProjectName\$testProjectName.csproj reference $libProjectName\$libProjectName.csproj
dotnet add $testProjectName\$testProjectName.csproj package FluentAssertions

Pop-Location