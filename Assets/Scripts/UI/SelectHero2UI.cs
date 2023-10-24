using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using ZBase.UnityScreenNavigator.Core.Modals;

public class SelectHero2UI : Modal
{
    public Button closeBtn;
    public Button openSelectHero1Btn;

    protected override void Start()
    {
        base.Start();
        closeBtn.onClick.AddListener(OnClickedCloseBtn);
        openSelectHero1Btn.onClick.AddListener(() => 
        UIService.OpenModalAsync(UIPath.select_hero.ToString()).Forget());
    }

    private void OnClickedCloseBtn()
    {
        UIService.CloseModal();
    }
}
