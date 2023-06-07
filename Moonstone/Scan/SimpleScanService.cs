using Moonstone.Core.Architecture.Scanner;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Moonstone.Scan;
internal class SimpleScanService : IScanService
{
    private readonly Timer _scheduler;
    private readonly List<Action> _scannables = new();

    public SimpleScanService()
    {
        _scheduler = new(_ => Scan(), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(50));
    }

    private void Scan()
    {
        foreach (Action scannable in _scannables.ToImmutableArray())
            scannable();
    }

    public void AddAll(Action[] delegates)
    {
        _scannables.AddRange(delegates);
    }

    public void RemoveAll(Action[] delegates)
    {
        _scannables.RemoveAll(delegates.Contains);
    }

    public void Dispose()
    {
        _scheduler.Dispose();
        _scannables.Clear();
    }
}
