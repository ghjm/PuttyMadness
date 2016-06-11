$apiUrl = 'https://ci.appveyor.com/api'
$accountName = 'ghjm'
$projectSlug = 'puttymadness'

$project = Invoke-RestMethod -Method Get -Uri "$apiUrl/projects/$accountName/$projectSlug"
$jobId = $project.build.jobs[0].jobId
$artifacts = Invoke-RestMethod -Method Get -Uri "$apiUrl/buildjobs/$jobId/artifacts"
$version = $project.build.version
$dir = Split-Path $MyInvocation.MyCommand.Path

$old_content = (gc "$dir\README.md")
$new_content = @()
$skipping = $FALSE

$reader = [System.IO.StreamReader] "$dir\README.md"
for (;;) {
    $line = $reader.ReadLine()
    if ($line -eq $null) { break }
    if ($skipping) {
        if ($line -match "^\s*$") {
            $skipping = $FALSE
        }
    } else {
        if ($line -match "Version (.*) Downloads:") {
            $skipping = $TRUE
            $new_content += "Version $version Downloads:"
            foreach ($a in $artifacts) {
                $new_content += "* [" + $a.name + "]($apiUrl/buildjobs/$jobId/artifacts/" + $a.fileName + ")"
            }
            $new_content += ""
        } else {
            $new_content += $line
        }
    }
}
$reader.Close()

$writer = [System.IO.StreamWriter] "$dir\README.md"
foreach ($line in $new_content) {
    $writer.WriteLine($line)
}
$writer.Close()
