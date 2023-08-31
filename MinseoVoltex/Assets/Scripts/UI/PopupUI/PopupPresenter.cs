using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopupPresenter : PresenterBase<PopupView>
{
    public void Bind(String info, (String, UnityAction) button)
    {
        base.Bind();
        _view.Info.text = info;
        _view.Button.onClick.AddListener(button.Item2);
        _view.ButtonText.text = button.Item1;
        _view.OpenView();
    }
    public override void Release()
    {
        _view.Button.onClick.RemoveAllListeners();
        _view.Info.text = "";
        _view.ButtonText.text = "";
        _view.CloseView();
    }
}
