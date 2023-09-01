using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class MainMenuView : ViewBase
{
    protected override void InitView()
    {
        StartCoroutine(BindStartButton());
    }

    IEnumerator BindStartButton()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<MainMenuPresenter>().Bind();
    }
}