using GoblinsTreasure.Scripts.UI;
using System.Threading.Tasks;

namespace GoblinsTreasure.Scripts.Commands {

    public class FadeOutCommand : ICommand {

        public async Task Execute() => await ServiceLocator.Instance.GetService<ScreenFade>().FadeOut();
    }

}