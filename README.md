# HellSkate : Team 4

# Members
Project Manager: Jack Dugan (jdugan415)\
Communications Lead: Jude Menard (JudeMen)\
Git Master: Andrew Mallory (andrewmallory8)\
Design Lead: Aaron Arceneaux (Noraaxu)\
Quality Assurance Tester: John Holcomb (johnholcomb10)

# About Our Software
This is the semester-long project for Team 4, "Hellskate." The project was created with Unity in C#, using Unity 6 as the game engine and VSCode for scripting. This game is a 2D platformer, where the player moves around on a skateboard and can fight several types of enemies throughout three different levels. The game can be run out of the editor, or you can export it yourself into an executable. Information for how to run the game and test it in the editor can be found below:

## Controls in Game
- Left - A/Left Arrow
- Right - D/Right Arrow
- Jump - Spacebar
- Enter/Exit Combat Mode - X
- Attack (while in Combat Mode) - Z
- Pause Game - Esc

## Platforms Tested on
- Windows 11
- Have not tested other platforms, but Unity builds can be exported for other platforms. Instructions for that can be found here:
  https://docs.unity3d.com/Packages/com.unity.industrial.forma@4.1/manual/build-setup.html

# Important Links
Kanban Board: https://github.com/orgs/CSC-3380-Spring-2025/projects/1 \
Designs: https://drive.google.com/drive/folders/1sHhacgMYCPELJCLtA2DdhESWkmDdt5Vn \
Styles Guide(s): https://www.dofactory.com/csharp-coding-standards

# How to Run Dev and Test Environment

## Dependencies
- Unity Hub (version 3.12.0)
  https://unity.com/download

- Unity 6 (version 6000.0.38f1)
  https://unity.com/releases/editor/whats-new/6000.0.38#notes (or download within editor, per instructions in Downloading Dependencies section below)

- VSCode (version 1.99.3)
  https://code.visualstudio.com/download
  Extensions within VSCode:
  - C# :: ms-dotnettools.csharp
  - C# Dev Kit :: ms-dotnettools.csdevkit
  - Unity :: visualstudiotoolsforunity.vstuc
  - .NET Install Tool (should be automatically installed alongside C#/C# Dev Kit) :: ms-dotnettools.vscode-dotnet-runtime

- .NET SDK (version 9.0.200)
  https://github.com/dotnet/core/blob/main/release-notes/9.0/9.0.2/9.0.2.md?WT.mc_id=dotnet-35129-website

## Not required but recommended:
- Github Desktop
  https://desktop.github.com/download/

- Other helpful, but not required, VSCode extensions:
  - IntelliCode for C# Dev Kit :: ms-dotnettools.vscodeintellicode-csharp
  - Unity Code Snippets :: kleber-swf.unity-code-snippets

### Downloading Dependencies
1. Go to unity.com, create a Unity account, and download Unity Hub for your platform (link in Dependencies section).
2. In Unity Hub, go to the "Installs" tab on the left sidebar, click on "Install Editor," and download Unity Editor version 6000.0.38f1. If this version does not show up in the editor, you can use the link provided in the Dependencies section, instead. Ensure that the script compiler that will be used is VSCode.
3. VSCode extensions can be found by searching their names within the search bar in the "Extensions" tab on VSCode (link in Dependencies section).
4. You will likely get an error within VSCode stating that a .NET SDK could not be found. You will have to download and install the .NET SDK (link in Dependencies section) if you have not already done so. You will have to restart your device once the SDK is installed.
5. [NOT REQUIRED] Additionally, download the GitHub desktop app (link in Dependencies section) to make commits easier and to create pull requests straight from the app.

## Getting Started with the Project
1. Make sure the Main branch is selected on GitHub and clone the repository onto your computer/laptop to access all files.
2. [NOT REQUIRED] You can add this repository to Github Desktop by clicking "File" on the top left of Github Desktop once downloaded, then selecting "Add Repository" and choosing your local disk location for the repository. To find the repo on your disk, simply find the folder in your PC/laptop that is titled "GitHub" (where you cloned the repo from step 1). From there, use the folder titled "Team-4". If the app is downloaded and has the repository added, make sure that the default branch titled "Main" is selected before using the Unity editor.
3. After downloading the editor, click "Add" on the "Projects" tab of Unity Hub.
4. Add the repository by using the first option and finding the repo on your disk.
5. To find the repo on your disk, simply find the folder in your PC/laptop that is titled "GitHub" (where you cloned the repo from step 1 and added to Github Desktop in step 2). From there, use the folder titled "My project" within "Team-4".
6. Once done, load the Project, it should default to the title "My Project", if not then just ensure that the repo is listed in the Project details.
7. The project may take a while to load as it is also loading ALL of the assets from the repo.
8. You can play the game using steps 4-9 in the following section:

## Setting up Project to Make Changes and Run Afterwards
1. Once in the editor, you may have to set VSCode as your default script editor. To do so, click on the "Edit" tab in the top left of the editor, then select "Preferences," navigate to the "External Tools" tab on the sidebar, and change the "External Script Editor" dropdown to Visual Studio Code.
2. This should not be necessary for this version of the Unity Editor, but you may also have to add Visual Studio Code to the package manager in the Unity Editor. Select the "Window" tab in the top left of the editor, then select "Package Manager." In the pop-up window, change the "Packages: In Project" option at the top to "Unity Registry," search Visual Studio in the search bar on the top right of the pop-up windows, and install the Visual Studio Code Editor package.
3. Save your changes both within the editor and within VSCode, if any.
4. Let the Unity editor reload and then go to the Scenes folder that is located in the "Assets" folder in the "Project" tab.
5. Double-click on the "TitleScreen" scene.
6. Once on the "TitleScreen" scene, double-click on the option located at the top of the screen that says "Game."
7. Once in the "Game" option, change the option that says "Free Aspect" to "Full HD."
8. Set the Scale by the "Full HD" option so that the entire game fits withinin your editor window.
9. Then, simply hit the Play button near the top of the screen to start the game.

  You can always export the game as an executable at any time. Instructions for that can be found here: https://blog.terresquall.com/2023/07/how-to-export-your-unity-project-onto-exe-windows/
