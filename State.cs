using System;
using System.Collections.Generic;

namespace MyMailClient
{
    class State
    {
        private readonly Dictionary<string, string> state = new Dictionary<string, string>();
        public void Add(string cmd, string param) { state[cmd] = param; }
        public string GetParams(string cmd) => state[cmd];
    }
}
