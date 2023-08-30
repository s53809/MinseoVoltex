using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPresenter : PresenterBase<MainMenuView>
{
    public override void Bind()
    {
        _view.StartButton.onClick.AddListener(() => Debug.Log("Hello, World!"));
    }

    public override void Release()
    {
        
    }
}
