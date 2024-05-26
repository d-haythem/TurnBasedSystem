using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actionButtonText;
    [SerializeField] private Button actionButton;
    [SerializeField] private GameObject selectedGameObject;

    private BaseAction baseAction;

    //
    // Summary :
    //     Change action button UI text and set selected action.
    public void SetBaseAction(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        actionButtonText.text = baseAction.GetActionName().ToUpper();

        actionButton.onClick.AddListener(() =>
        {
            Unit.Instance.SetSelectedAction(baseAction);
        });
    }

    //
    // Summary :
    //     Add visual to the selected button action UI.
    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = Unit.Instance.GetSelectedAction();

        selectedGameObject.SetActive(selectedBaseAction == baseAction);
    }

}