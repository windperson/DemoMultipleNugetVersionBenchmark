#Requires -Version 7

Get-ChildItem $PSScriptRoot\nupkgs\*.nupkg | ForEach-Object {
    $pkg = $_.Name
    $pkg = $pkg.Substring(0, $pkg.Length - 6)
    $pkg = $pkg.Substring(0, $pkg.IndexOf('.'))
    $pkg = $pkg.ToLower()
    if ($IsWindows)
    {
        $pkgPath = "$env:USERPROFILE\.nuget\packages\$pkg"
    }
    else
    {
        $pkgPath = "$HOME/.nuget/packages/$pkg"
    }
    if (Test-Path $pkgPath)
    {
        Remove-Item -r -Force $pkgPath
        Write-Output "Removed $pkgPath"
    }
    $localPkg = $_.FullName
    Remove-Item -r -Force $localPkg
}
