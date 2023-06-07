using Moonstone.UI.Observable;
using System.Collections.ObjectModel;

namespace Moonstone.Overlay.Damage.ViewModels;

internal class DamageMeterViewModel : ViewModel
{
    public ObservableCollection<SkillStatsViewModel> Skills { get; } = new();
}
