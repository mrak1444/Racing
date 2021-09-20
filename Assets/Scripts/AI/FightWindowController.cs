using Profile;
using Tools;
using UnityEngine;

internal class FightWindowController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/FightWindowView" };
    private FightWindowView _fightWindowView;
    private ProfilePlayer _profilePlayer;

    public FightWindowController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _fightWindowView = LoadView(placeForUi);
        _fightWindowView.CloseButton.onClick.AddListener(CloseFight);
    }

    private void CloseFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    private FightWindowView LoadView(Transform placeForUi)
    {
        GameObject objectView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<FightWindowView>();
    }
}
