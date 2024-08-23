using GoblinsTreasure.Scripts.UI;
using System.Threading.Tasks;

namespace GoblinsTreasure.Scripts.Commands {

    public class FadeInCommand : ICommand {

        public async Task Execute() => await ServiceLocator.Instance.GetService<ScreenFade>().FadeIn();
    }

}