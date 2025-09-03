using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLISimplified
{
    public class FileFolderOperations
    {
       public void CreateFolder(string command,Editor Output,string currentPath)
        {
            // Example command: "mkdir MyFolder"
            string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                ConsoleOutput("Error: No folder name provided.",Output);  
                return;
            }
            string folderName = parts[1];
            string newFolderPath = Path.Combine(currentPath, folderName);
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
                ConsoleOutput(($"Folder created: {newFolderPath}"),Output);
            }
            else
            {
                ConsoleOutput(("Folder already exists!"),Output);
            }
        }

       public void DeleteFolder(string command, string currentPath,Editor editor)
        {
            string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                ConsoleOutput("Error: No folder name provided.",editor);
                return;
            }
            string folderName = parts[1];
            string FolderPath = Path.Combine(currentPath, folderName);
            if (Directory.Exists(FolderPath))
            {
                Directory.Delete(FolderPath, true);
                ConsoleOutput($"Folder deleted: {FolderPath}",editor);
            }
            else
            {
                ConsoleOutput("Folder does not exist!", editor);
            }
        }


        public void ListFiles(string currentPath,Editor Output)
        {
            Editor tempedi = new Editor();
            string[] dirs = Directory.GetDirectories(currentPath);
            string[] files = Directory.GetFiles(currentPath);
            foreach (var dir in dirs)
                //Output.Text+=("[DIR] " + Path.GetFileName(dir))+Environment.NewLine+"testing";
                ConsoleOutput("[DIR]" + Path.GetFileName(dir),Output);

            foreach (var file in files)
               // Output.Text += (Path.GetFileName(file))+Environment.NewLine;
                ConsoleOutput("[File]" + Path.GetFileName(file),Output);
        }

        public void MoveUp(string command,string? path=null,Editor? editor=null) 
        {
            var parent=Directory.GetParent(path);
            if (parent is not null)
            {
                path = parent.FullName;
                ConsoleOutput($"Moved Up Directory", editor);
                ConsoleOutput($"Current Directory: {path}", editor);
            }
            else if (Directory.GetParent(path)==null){
                ConsoleOutput("Already at root directory", editor);
            }


           
        }



        private void ConsoleOutput(string text,Editor? editorput=null)
        {
            if (editorput == null) return;
            editorput.Text += text+Environment.NewLine;
            editorput.CursorPosition = editorput.Text.Length;
        }
    }//Output(Output)
}
