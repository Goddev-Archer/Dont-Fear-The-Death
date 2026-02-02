Write-Host "Starte Build-Vorgang fuer Einzeldatei-Executable (.exe)..." -ForegroundColor Cyan

$projectPath = ".\Dont_Fear_The_Death\Dont_Fear_The_Death.csproj"
$outputDir = ".\Build\SingleFileRelease"

# Verzeichnis bereinigen
if (Test-Path $outputDir) {
    Remove-Item $outputDir -Recurse -Force
}

# dotnet publish ausfuehren
# -r win-x64: Zielplattform Windows 64-bit
# --self-contained: .NET Runtime wird mitgeliefert (keine Installation noetig)
# -p:PublishSingleFile=true: Alles in eine EXE packen
# -p:IncludeAllContentForSelfExtract=true: Auch Content-Dateien (Frames) in die EXE packen und beim Start entpacken
# -p:EnableCompressionInSingleFile=true: Dateigroesse reduzieren
dotnet publish $projectPath -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true -p:EnableCompressionInSingleFile=true -o $outputDir

if ($LASTEXITCODE -eq 0) {
    Write-Host "Build erfolgreich abgeschlossen!" -ForegroundColor Green
    Write-Host "Die .exe befindet sich in: $outputDir" -ForegroundColor White
    Invoke-Item $outputDir
} else {
    Write-Host "Fehler beim Build-Vorgang." -ForegroundColor Red
}
