using Tools;
using UnityEngine;

internal class CarControllerView : MonoBehaviour
{
    private GameObject _wheelsView;

    public GameObject Init(ResourcePath _wheelsPath, GameObject _carView)
    {
        _wheelsView = Object.Instantiate(ResourceLoader.LoadPrefab(_wheelsPath), _carView.transform, false);
        return _wheelsView;
    }

    public GameObject WheelView
    {
        get => _wheelsView;
    }
}
