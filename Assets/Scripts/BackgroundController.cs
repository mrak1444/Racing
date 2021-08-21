using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

internal class BackgroundController : BaseController
{
    private BackgroundView _view;
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/background" };
    private readonly IReadOnlySubscriptionProperty<float> _leftMove;
    private readonly IReadOnlySubscriptionProperty<float> _rightMove;
    private readonly SubscriptionProperty<float> _diff;

    public BackgroundController(IReadOnlySubscriptionProperty<float> leftMove, IReadOnlySubscriptionProperty<float> rightMove)
    {
        _view = LoadView();
        _leftMove = leftMove;
        _rightMove = rightMove;
        _diff = new SubscriptionProperty<float>();

        _view.Init(_diff);
        _leftMove.SubscribeOnChange(Move);
        _rightMove.SubscribeOnChange(Move);
    }

    protected override void OnDispose()
    {
        _leftMove.UnSubscriptionOnChange(Move);
        _rightMove.UnSubscriptionOnChange(Move);

        base.OnDispose();
    }

    private BackgroundView LoadView()
    {
        var objView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);

        return objView.GetComponent<BackgroundView>();
    }

    private void Move(float value)
    {
        _diff.Value = value;
    }
}
