function Install-SpecificityDocumentation() {
	pushd $PsScriptRoot\..\docs
	try {
		Uninstall-SpecificityDocumentation
		.\HelpLibraryManagerLauncher.exe /viewerVersion 2.0 /catalogName VisualStudio11 /locale en-us /wait 0 /operation install /sourceUri "%CD%\SpecificityDocumentation.msha" | Out-Null
	} finally {
		popd
	}
}

function Uninstall-SpecificityDocumentation() {
	pushd $PsScriptRoot\..\docs
	try {
		.\HelpLibraryManagerLauncher.exe /viewerVersion 2.0 /catalogName VisualStudio11 /locale en-us /wait 0 /operation uninstall /vendor "Vendor Name" /productName "Specificity Unit Testing Library" /bookList "Specificity Unit Testing Library" | Out-Null
	} finally {
		popd
	}
}

Export-ModuleMember -Function Install-SpecificityDocumentation,Uninstall-SpecificityDocumentation