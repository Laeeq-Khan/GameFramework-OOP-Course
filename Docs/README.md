PDF generation helper

Files created:
- `Lecture-FirstDesktopApp.md` — lecture notes in Markdown
- `make-pdf.ps1` — helper PowerShell script to run pandoc if available

How to create PDF:
1. Install Pandoc from https://pandoc.org/installing.html
2. (Optional) Install a LaTeX engine like MiKTeX for best PDF output, or use wkhtmltopdf
3. Run `.\Docs\make-pdf.ps1` from a PowerShell console in the project root

Alternative: Open `Lecture-FirstDesktopApp.md` in VS Code and print to PDF from the editor.