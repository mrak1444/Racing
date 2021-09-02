using Profile;
using Tools;

internal class CarController : BaseController
{
    private CarControllerView _view;
    private Car _car;
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/Car" };

    public CarController(Car Car)
    {
        _view = LoadView();
        _viewPath = new ResourcePath { PathResource = Car.ResourcePath };
    }

    private CarControllerView LoadView()
    {
        var objView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);

        return objView.GetComponent<CarControllerView>();
    }
}
