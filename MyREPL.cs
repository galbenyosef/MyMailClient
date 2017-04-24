using System;

namespace MyMailClient
{
    class MyREPL
    {
        private readonly ICommand[] commands;

        private State state;
        public MyREPL(ICommand[] cmds) { commands = cmds; state = new State(); }
        public void Start()
        {
            string input;

            SayHello();

            while (true)
            {
                try
                {
                    Console.Write("> ");
                    if ((input = ReadLine().ToLower()) == "exit")
                        break;
                    Execute(new ParsedInput(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
        }
        string ReadLine() { return Console.ReadLine(); }
        ParsedInput ParseCommand(string text) { return (new ParsedInput(text)); }
        void Execute(ParsedInput input)
        {
            foreach (var cmd in commands)
            {
                if (cmd.Name.Equals(input.Command))
                {
                    cmd.Execute(input.Param, state);
                    return;
                }
            }
            throw new Exception($"Bad command '{input.Command}'");
        }
        void SayHello()
        {
            Console.WriteLine(
                "Hello REPL client\n" +
                "-----------------\n" +
                "Use the following commands to send emails:\n" +
                "subject <subject> - update the message subject\n" +
                "body <body> - update the message body\n" +
                "to <email>[,<email>]* - update the message recipient list\n" +
                "send - send the email using the current subject, body and recipient list\n" +
                "type 'exit' to exit\n"
            );
        }
    }
}
