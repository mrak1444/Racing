using Profile;
using Tools;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
        }

        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };

        private readonly ProfilePlayer _profilePlayer;
        private MainMenuView _view;

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game", ("time", Time.realtimeSinceStartup));
            _profilePlayer.AdsShower.ShowVideo();
            Advertisement.AddListener(_profilePlayer.AdsListener);
        }
    }
}