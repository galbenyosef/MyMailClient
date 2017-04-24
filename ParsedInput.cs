using System;
using System.Collections.Generic;

namespace MyMailClient
{
    class ParsedInput
    {
        private string command, param;
        public string Command => command;
        public string Param => param;
        public ParsedInput(string text)
        {

            Parse(text);
        }
        private void Parse(string text)
        {
            string[] splitted = text.Split(' ');
            command = splitted[0].ToLower();
            Console.WriteLine(text.Length  ); 
            if (text.Length-command.Length != 0)
                param = text.Substring(command.Length+1);
            else param = text.Substring(command.Length);
        }
    }
}