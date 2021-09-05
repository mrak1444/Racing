using Profile;
using Tools;
using UnityEngine;

internal class CarController : BaseController
{
    private CarControllerView _view;
    private Car _car;
    private GameObject _carView;
    private GameObject _wheelsView;
    private readonly ResourcePath _carPath = new ResourcePath { PathResource = "Prefabs/Car" };
    private readonly ResourcePath _wheelsPath = new ResourcePath { PathResource = "Prefabs/Wheels" };

    public CarController(Car Car)
    {
        _car = Car;
        _view = LoadView();
        _carPath = new ResourcePath { PathResource = Car.ResourcePath };
        _wheelsView = _view.Init(_wheelsPath, _carView);
        AddGameObjects(_wheelsView);
    }

    private CarControllerView LoadView()
    {
        _carView = Object.Instantiate(ResourceLoader.LoadPrefab(_carPath));
        AddGameObjects(_carView);
        return _carView.GetComponent<CarControllerView>();
    }
}
