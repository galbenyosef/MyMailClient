using System;

namespace MyMailClient
{
    class SubjectCommand : REPLCommand, ICommand
    {
        public SubjectCommand(string name) : base(name)
        {
        }
        public override void Execute(string param, State state)
        {
            if (String.IsNullOrEmpty(param))
                throw new Exception($"Command {Name} requires 1 parameter");
            state.Add(Name, param);
            string content = param.Length > 14 ? param.Substring(0, 14) : param;
            Console.WriteLine("Command output: Subject updated to "+"'"+content+"'...");
        }
    }
    class BodyCommand : REPLCommand, ICommand
    {
        public BodyCommand(string name) : base(name)
        {
        }
        public override void Execute(string param, State state)
        {
            if (String.IsNullOrEmpty(param))
                throw new Exception($"Command {Name} requires 1 parameter");
            state.Add(Name, param);
            string content = param.Length > 14 ? param.Substring(0, 14) : param;
            Console.WriteLine("Command output: Body updated to " + "'" + content + "'...");
        }
    }
    class ToCommand : REPLCommand, ICommand
    {
        public ToCommand(string name) : base(name)
        {
        }
        public override void Execute(string param, State state)
        {
            if (String.IsNullOrEmpty(param))
                throw new Exception($"Command {Name} requires 1 parameter");
            state.Add(Name, param);
            int recipients;
            recipients = state.GetParams(Name).Split(',').Length;
           
            string target = recipients > 1 ? $"{recipients} recipients" : param;

            Console.WriteLine("Command output: To updated to " + target);
        }
    }
    class SendCommand : REPLCommand, ICommand
    {
        public SendCommand(string name) : base(name)
        {
        }
        public override void Execute(string param, State state)
        {
            EmailClient client;
            string subject, body;

            client = new EmailClient(
                "csharpdevs@gmail.com", "123456---"
                );
            try
            {
                subject = state.GetParams("subject");
                body = state.GetParams("body");
                var recipients = state.GetParams("to").Split(',');
                foreach (var recipient in recipients)
                {
                    client.Send(recipient, subject, body);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Subject or body is empty");
            }
        }
    }
}
