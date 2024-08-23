using System.Threading.Tasks;
using UnityEngine;

public class FadeInCommand : ICommand {

    public async Task Execute() => await ServiceLocator.Instance.GetService<ScreenFade>().FadeIn();
}