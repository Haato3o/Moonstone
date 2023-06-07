namespace Moonstone.Core.Architecture.Scanner;

public interface IScanService : IDisposable
{
    public void AddAll(Action[] delegates);
    public void RemoveAll(Action[] delegates);
}