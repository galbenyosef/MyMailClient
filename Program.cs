
using System;
using System.Windows;

namespace MyMailClient
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            /* Command line execution
            ---------------------------
            MyREPL repl = new MyREPL(new ICommand[]
            {
                new SubjectCommand("subject"),
                new ToCommand("to"),
                new BodyCommand("body"),
                new SendCommand("send")
            });
            repl.Start();
            ---------------------------
             */



            ///* UI execution 
           //---------------------------
            MainWindow window = new MainWindow();
            Application app = new Application();
            app.Run(window);
            //--------------------------
            //*/
        }
    }
}


   