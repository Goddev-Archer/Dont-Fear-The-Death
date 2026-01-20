# Skript zum Erstellen eines Release-Builds für Windows x64

$projectPath = Join-Path $PSScriptRoot "Dont_Fear_The_Death\Dont_Fear_The_Death.csproj"
$outputDir = Join-Path $PSScriptRoot "Build\Release"

Write-Host "Starte Release-Build..."
Write-Host "Projekt: $projectPath"
Write-Host "Ausgabe: $outputDir"

# Lösche altes Ausgabeverzeichnis falls vorhanden
if (Test-Path $outputDir) {
    Write-Host "Bereinige altes Ausgabeverzeichnis..."
    Remove-Item $outputDir -Recurse -Force
}

# Führe dotnet publish aus
# -c Release: Optimierte Release-Konfiguration
# -r win-x64: Zielplattform Windows 64-Bit
# --self-contained: Beinhaltet die .NET Runtime (keine Installation beim Nutzer nötig)
# -p:PublishSingleFile=true: Erstellt eine einzelne .exe Datei (plus Ressourcen)
dotnet publish $projectPath -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o $outputDir

if ($LASTEXITCODE -eq 0) {
    Write-Host "`nBuild erfolgreich abgeschlossen!" -ForegroundColor Green
    Write-Host "Die ausführbare Datei befindet sich in: $outputDir"
} else {
    Write-Host "`nFehler beim Erstellen des Builds." -ForegroundColor Red
    Exit 1
}
