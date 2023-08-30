using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : ViewBase
{
    public Text Title;
    public Button StartButton;

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
