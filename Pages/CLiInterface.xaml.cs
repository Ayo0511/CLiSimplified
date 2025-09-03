using Microsoft.Maui.Controls;
using System;
 

namespace CLISimplified.Pages;

public partial class CLiInterface : ContentPage
{
    // Start in My Documents by default
    string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    //method references
    public ConvenienceCommands CnvCommands = new ConvenienceCommands();
    public FileFolderOperations FileFolderOperations = new FileFolderOperations();

    public CLiInterface()
	{
		InitializeComponent();
	}

    #region
    private void OnCommandEntered(object sender, EventArgs e)
    {
        string input = CommandEntry.Text?.Trim() ?? "";
        CommandEntry.Text = ""; // clear input after reading
        string command= input.Split(' ')[0].ToLower();
      
        

        switch (command)
        {
            default:
                Output("Unknown Command"); break;
            case "goto":
                GoToPath(input); break;
            case "ls":
                FileFolderOperations.ListFiles(currentPath,ConsoleOutput);break;
            case "createfolder":
                FileFolderOperations.CreateFolder(input,ConsoleOutput,currentPath); break;
            case "exit":
                CnvCommands.Exit(); break;
            case "help":
                CnvCommands.Help(ConsoleOutput); break;
            case "clear":
                CnvCommands.ClearConsole(ConsoleOutput); break;
            case "delete":
                FileFolderOperations.DeleteFolder(input,currentPath,ConsoleOutput);break;
            case "moveup":
                FileFolderOperations.MoveUp(input,currentPath,ConsoleOutput); break;
            case "showpath":
                showDir(); break;
            case "copypath":
                CnvCommands.copyCurrentDir(currentPath,ConsoleOutput); break;
        }
    }
    #endregion




    void GoToPath(string path)
    {
        string[] parts = path.Split(' ', 2);
        string args = parts.Length > 1 ? parts[1] : "";
        if (string.IsNullOrWhiteSpace(args))
        {
            Output("Provide a directory");
            return;
        }
        
        string fullPath = Path.IsPathRooted(args) ? args : Path.Combine(currentPath, args);
        if (Directory.Exists(fullPath))
        {
            currentPath = fullPath;
            Output($"Current directory: {currentPath}");
        }
        else
        {
            Output("Directory does not exist!");
        }
    }
    public void showDir()
    {
        Output($"{currentPath}");
    }

    
    public void Output(string text)
    {
        ConsoleOutput.Text += text + Environment.NewLine;
        ConsoleOutput.CursorPosition = ConsoleOutput.Text.Length; // scroll to bottom
    }

   
}











/*Windows PowerShell
Copyright (C) Microsoft Corporation. All rights reserved.

Install the latest PowerShell for new features and improvements! https://aka.ms/PSWindows

PS C:\Users\ayool\Desktop\testDIR> */


/*CLISimplified
 * Current path +currentPath
 */





/*void CreateFolder(string command)
   {
       // Example command: "mkdir MyFolder"
       string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

       if (parts.Length < 2)
       {
           Output("Error: No folder name provided.");
           return;
       }
       string folderName = parts[1];
       string newFolderPath = Path.Combine(currentPath, folderName);

       if (!Directory.Exists(newFolderPath))
       {
           Directory.CreateDirectory(newFolderPath);
           Output($"Folder created: {newFolderPath}");
       }
       else
       {
           Output("Folder already exists!");
       }
   }*

private void ListFiles()
   {
       string[] dirs = Directory.GetDirectories(currentPath);
       string[] files = Directory.GetFiles(currentPath);

       foreach (var dir in dirs)
           Output("[DIR] " + Path.GetFileName(dir));
       foreach (var file in files)
           Output(Path.GetFileName(file));
   }
 private void Help()
    {
        Output("...Available commands:");
        Output("...goto [path]   - Change directory");
        Output("...ls            - List files and folders");
        Output("...createfolder [name]  - Create a new folder");
      //  Output("rename old new- Rename a file or folder");
        Output("...delete [name] - Delete a file or folder");
      //  Output("pwd           - Show current directory");
        Output("...clear         - Clear the console output");
        Output("help          - Show this help message");
        Output("...exit          - Close the application");
    }

 void DeleteFolder(string command)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 2)
        {
            Output("Error: No folder name provided.");
            return;
        }
        string folderName = parts[1];
        string FolderPath = Path.Combine(currentPath, folderName);
        if (Directory.Exists(FolderPath))
        {
            Directory.Delete(FolderPath,true);
            Output($"Folder deleted: {FolderPath}");
        }
        else
        {
            Output("Folder does not exist!");
        }
    }
*/