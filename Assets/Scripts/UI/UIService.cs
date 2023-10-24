using Cysharp.Threading.Tasks;
using ZBase.UnityScreenNavigator.Core.Modals;

public struct UIContant
{
    public const string SCREEN = "Screen";
    public const string MODAL = "Modal";
    public const string ACTIVITY = "Activity";
}

public static class UIService 
{
    public static async UniTask OpenModal(string resourcePath, bool playAnimation = true,
            bool? closeWhenClickOnBackDrop = true,
            float? backDropAlpha = 0.7f, params object[] args)
    {
        var modalOptions = new ModalOptions(resourcePath, playAnimation, backdropAlpha: backDropAlpha, closeWhenClickOnBackdrop: closeWhenClickOnBackDrop);
        await ModalContainer.Find(UIContant.MODAL).PushAsync(modalOptions, args); 
    }
}
