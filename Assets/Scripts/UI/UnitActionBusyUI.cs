using UnityEngine;

public class UnitActionBusyUI : MonoBehaviour
{
    private void Start()
    {
        Unit.Instance.onBusyChanged += Instance_onBusyChanged;

        Hide();
    }

    private void Instance_onBusyChanged(object sender, bool isBusy)
    {
        if (isBusy) Show();
        else Hide();
    }

    //
    // Summary :
    //     Create action buttons UI.
    private void Show()
    {
        gameObject.SetActive(true);
    }

    //
    // Summary :
    //     Create action buttons UI.
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
