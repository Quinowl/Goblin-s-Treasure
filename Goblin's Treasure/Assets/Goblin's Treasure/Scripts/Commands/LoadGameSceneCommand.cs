using System.Threading.Tasks;

namespace GoblinsTreasure.Scripts.Commands {

    public class LoadGameSceneCommand : ICommand {

        public async Task Execute() {

            await new LoadSceneCommand(Constants.SCENE_GAME).Execute();
            //TODO: Complete this with game states
        }

    }
}