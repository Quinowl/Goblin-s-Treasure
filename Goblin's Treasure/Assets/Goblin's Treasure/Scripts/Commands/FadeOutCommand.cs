using System.Threading.Tasks;

public class FadeOutCommand : ICommand {

    public async Task Execute() => await ServiceLocator.Instance.GetService<ScreenFade>().FadeOut();
}