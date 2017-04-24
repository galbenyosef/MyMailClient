

namespace MyMailClient
{
    interface ICommand
    {
        string Name { get; }
        void Execute(string param, State state);
    }
    abstract class REPLCommand : ICommand
    {
        public string Name { get; }
        public REPLCommand(string name)
        {
            Name = name;
        }
        public abstract void Execute(string param, State state);

    }
}
