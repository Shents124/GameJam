using Cysharp.Threading.Tasks;
using ZBase.UnityScreenNavigator.Core.Modals;
using ZBase.UnityScreenNavigator.Core.Screens;

public struct UIContant
{
    public const string SCREEN = "Screen";
    public const string MODAL = "Modal";
    public const string ACTIVITY = "Activity";
}

public static class UIService 
{
    public static async UniTask OpenScreen(string path, bool playAnimation = true, params object[] args)
    {
        var screenOptions = new ScreenOptions(path, playAnimation);
        await ScreenContainer.Find(UIContant.SCREEN).PushAsync(screenOptions, args);
    }

    public static async UniTask PreloadScreen(string path)
    {
        //var screenOptions = new ScreenOptions(path, playAnimation);
        await ScreenContainer.Find(UIContant.SCREEN).PreloadAsync(path);
    }

    public static async UniTask OpenModalAsync(string resourcePath, bool playAnimation = true,
            bool? closeWhenClickOnBackDrop = true,
            float? backDropAlpha = 0.7f, params object[] args)
    {
        var modalOptions = new ModalOptions(resourcePath, playAnimation, backdropAlpha: backDropAlpha, closeWhenClickOnBackdrop: closeWhenClickOnBackDrop);
        await ModalContainer.Find(UIContant.MODAL).PushAsync(modalOptions, args); 
    }

    public static void CloseModal(bool playAnimation = true)
    {
        ModalContainer.Find(UIContant.MODAL).Pop(playAnimation);
    }
}
