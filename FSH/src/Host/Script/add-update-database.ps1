Write-Host "Updating Configurations for MySQL Provider..."
$databaseJsonContent.DatabaseSettings.DBProvider = "mysql"
$databaseJsonContent.DatabaseSettings.ConnectionString = $mysqlConnectionString
$databaseJsonContent | ConvertTo-Json | set-content $databaseJsonPath

$hangfireJsonContent.HangfireSettings.Storage.StorageProvider = "mysql"
$hangfireJsonContent.HangfireSettings.Storage.ConnectionString = $mysqlConnectionString
$hangfireJsonContent | ConvertTo-Json | set-content $hangfireJsonPath

Write-Host "Adding Migrations for MySQL Provider..."
dotnet ef migrations add $commitMessage --project .././Migrators/Migrators.MySQL/ --context ApplicationDbContext -o Migrations/Application
Write-Host "Adding Migrations for MySQL Provider...Done`n"
Write-Host "**************************`n"
