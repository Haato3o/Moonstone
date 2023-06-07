using Moonstone.UI.Observable;

namespace Moonstone.Overlay.Damage.ViewModels;

internal class SkillStatsViewModel : ViewModel
{
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => SetValue(ref _name, value);
    }

    private float _damage;
    public float Damage
    {
        get => _damage;
        set => SetValue(ref _damage, value);
    }

    private float _percentage;
    public float Percentage
    {
        get => _percentage;
        set => SetValue(ref _percentage, value);
    }
}
