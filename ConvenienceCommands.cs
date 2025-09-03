using CLISimplified.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLISimplified
{
    
   public class ConvenienceCommands
    {
      
        public void ClearConsole(Editor ConsoleOutput)
        {
            ConsoleOutput.Text = "";
        }

        public void Exit()
        {

            Application.Current?.Quit();
        }
      public void Help(Editor editor)
        {
            ConsoleOutput("...Available commands:",editor);
            ConsoleOutput("...goto [path]   - Change directory",editor);
            ConsoleOutput("...ls            - List files and folders", editor);
            ConsoleOutput("...createfolder [name]  - Create a new folder", editor);
            //  Output("rename old new- Rename a file or folder");
            ConsoleOutput("...delete [name] - Delete a file or folder", editor);
            //  Output("pwd           - Show current directory");
            ConsoleOutput("...clear         - Clear the console output", editor);
            ConsoleOutput("help          - Show this help message", editor);
            ConsoleOutput("...exit          - Close the application", editor);
        }

        private void ConsoleOutput(string text, Editor? editorput = null)
        {
            if (editorput == null) return;
            editorput.Text += text + Environment.NewLine;
            editorput.CursorPosition = editorput.Text.Length;
        }

        public void copyCurrentDir(string currentPath,Editor editor)
        {
            Clipboard.SetTextAsync($"{currentPath}");
            ConsoleOutput("Current Directory copied",editor);
        }
    }
}
