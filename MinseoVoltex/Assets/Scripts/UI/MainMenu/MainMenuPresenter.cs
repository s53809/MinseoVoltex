using System;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuPresenter : PresenterBase<MainMenuView>
{
    public String Text = "Hello, World!";
    public override void Bind()
    {
        base.Bind();
        UnityAction events = () => UIInputManager.Ins.PopPresenter();
        PopupPresenter popup = FindObjectOfType<PopupPresenter>();
        _view.StartButton.onClick.AddListener(() => popup.Bind(Text, ("Yaho", events)));
    }

    public override void Release()
    {
    }
}
