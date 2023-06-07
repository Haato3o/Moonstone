using Moonstone.Core.Architecture.Scanner;
using Moonstone.Core.Entity.Context;
using Moonstone.Core.Entity.Game;
using Moonstone.Core.Memory;

namespace Moonstone.Integrations.Soulstone.Game;
internal class SoulstoneContext : IContext
{
    private readonly IScanService _scanService;
    private readonly SoulstoneGame _game;

    public IGame Game => _game;

    public SoulstoneContext(
        IProcess process,
        IScanService scanService)
    {
        _scanService = scanService;
        _game = new SoulstoneGame(process, _scanService);
    }
}
