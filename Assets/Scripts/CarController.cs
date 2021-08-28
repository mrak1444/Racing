using Tools;

internal class CarController : BaseController
{
    private CarControllerView _view;
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Car" };

    public CarController()
    {
        _view = LoadView();
    }

    private CarControllerView LoadView()
    {
        var objView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);

        return objView.GetComponent<CarControllerView>();
    }
}
