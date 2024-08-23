using GoblinsTreasure.Scripts.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GoblinsTreasure.Scripts.Commands {

    public class LoadSceneCommand : ICommand {

        private readonly string _sceneName;

        public LoadSceneCommand(string sceneName) => _sceneName = sceneName;

        public async Task Execute() {

            await new FadeInCommand().Execute();
            LoadingScreen loadingScreen = ServiceLocator.Instance.GetService<LoadingScreen>();
            loadingScreen.Show();
            await LoadScene(_sceneName);
            loadingScreen.Hide();
            await new FadeOutCommand().Execute();
        }

        private async Task LoadScene(string sceneName) {

            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);
            while (!loadSceneAsync.isDone) await Task.Yield();
            await Task.Yield();
        }
    }

}