using Cysharp.Threading.Tasks;
using ZBase.UnityScreenNavigator.Core;

public class UIController : UnityScreenNavigatorLauncher
{
    protected override void Start()
    {
        base.Start();
        UIService.OpenMainScreen().Forget();
    }
}
