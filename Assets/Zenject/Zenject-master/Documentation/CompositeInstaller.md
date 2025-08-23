# CompositeInstaller

## Table Of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
<details>
<summary>Details</summary>

- [Introduction](#introduction)
  - [CompositeMonoInstaller](#compositemonoinstaller)
  - [CompositeScriptableObjectInstaller](#compositescriptableobjectinstaller)
  - [FYI](#fyi)

</details>
<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Introduction
CompositeInstaller is the composite pattern of Zenject installers.  
CompositeInstaller can compose other installers and can be used as follows:

- A reusable installer of other installers group
- A loosely-coupled installer of other installers
- A proxy installer to installers for some features

For example, Suppose you use a CompositeScriptableObjectInstaller asset in a package provided by another developer.  
If the developer add some installers to the CompositeScriptableObjectInstaller asset in the package, all you need to do is update the package and you can receive features of the new installers.

### CompositeMonoInstaller
- Add "CompositeMonoInstaller" component to any GameObject
- Set "MonoInstaller"s (including "CompositeMonoInstaller") to "CompositeMonoInstaller"
- Set "CompositeMonoInstaller" to any "Context"

![](./Images/CompositeInstaller/CompositeMonoInstallerInspector.jpg)

### CompositeScriptableObjectInstaller
- Select `Create -> Zenject -> Composite Scriptable Object Installer` to create the asset

![](./Images/CompositeInstaller/CompositeScriptableObjectInstallerCreateAsset.jpg)

- Set "ScriptableObjectInstaller"s (including "CompositeScriptableObjectInstaller") to "CompositeScriptableObjectInstaller"

![](./Images/CompositeInstaller/CompositeScriptableObjectInstallerInspector.jpg)

- Set "CompositeScriptableObjectInstaller" to any Context

![](./Images/CompositeInstaller/CompositeScriptableObjectInstallerInstall.jpg)

### FYI
- If any circular references are found in a composite installer, the property on the inspector will get red as a warning

![](./Images/CompositeInstaller/CompositeMonoInstallerCircularReference.jpg)
![](./Images/CompositeInstaller/CompositeScriptableObjectInstallerCircularReference.jpg)