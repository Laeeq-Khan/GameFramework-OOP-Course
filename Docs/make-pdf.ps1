# Helper script to convert Lecture-FirstDesktopApp.md to PDF if pandoc is available

$md = "Docs\Lecture-FirstDesktopApp.md"
$pdf = "Docs\Lecture-FirstDesktopApp.pdf"

function ErrorExit($msg){ Write-Host $msg -ForegroundColor Red; exit 1 }

# Check for pandoc
$pandoc = Get-Command pandoc -ErrorAction SilentlyContinue
if (-not $pandoc) {
    Write-Host "pandoc not found. To create PDF:
- install pandoc (https://pandoc.org/installing.html)
- ensure LaTeX engine (e.g., MiKTeX or TinyTeX) is installed for PDF output or use --pdf-engine=wkhtmltopdf if installed
Then run: pandoc $md -o $pdf --pdf-engine=xelatex --toc" -ForegroundColor Yellow
    Exit 0
}

Write-Host "Running pandoc to create PDF..." -ForegroundColor Green
$pandocArgs = @($md, '-o', $pdf, '--pdf-engine=xelatex', '--toc')
$p = Start-Process -FilePath $pandoc.Path -ArgumentList $pandocArgs -NoNewWindow -Wait -PassThru
if ($p.ExitCode -eq 0) {
    Write-Host "PDF created: $pdf" -ForegroundColor Green
} else {
    ErrorExit "pandoc failed with exit code $($p.ExitCode)"
}
