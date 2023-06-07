using Moonstone.Core.Architecture.Scanner;
using Moonstone.Core.Entity.Game;
using Moonstone.Core.Entity.Player;
using Moonstone.Core.Memory;

namespace Moonstone.Integrations.Soulstone.Game;

public class SoulstoneGame : Scannable, IGame
{
    private readonly SoulstonePlayer _player;

    public IPlayer Player => _player;

    public SoulstoneGame(
        IProcess process,
        IScanService scanService
    ) : base(process, scanService)
    {
        _player = new SoulstonePlayer(process, scanService);
    }

}