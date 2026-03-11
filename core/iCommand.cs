namespace Winux.Core
{
    public interface iCommand
    {
        string Name { get; }
        string[] Aliases { get; }
        void Execute(string[] args);
    }
}