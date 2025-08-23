@echo off

grip %~dp0\..\README.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\README.html
grip %~dp0\..\Documentation\AutoMocking.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\AutoMocking.html
grip %~dp0\..\Documentation\CheatSheet.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\CheatSheet.html
grip %~dp0\..\Documentation\Signals.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\Signals.html
grip %~dp0\..\Documentation\Factories.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\Factories.html
grip %~dp0\..\Documentation\MemoryPools.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\MemoryPools.html
grip %~dp0\..\Documentation\ReleaseNotes.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\ReleaseNotes.html
grip %~dp0\..\Documentation\SubContainers.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\SubContainers.html
grip %~dp0\..\Documentation\WritingAutomatedTests.md --export %~dp0\..\UnityProject\Assets\Plugins\Zenject\Documentation\WritingAutomatedTests.html
