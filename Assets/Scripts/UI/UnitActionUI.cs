using System.Collections.Generic;
using UnityEngine;

public class UnitActionUI : MonoBehaviour
{
    [SerializeField] private Transform actionButtonPrefab;
    [SerializeField] private Transform actionButtonContainerTransform;

    private List<UnitActionButtonUI> unitActionButtonList;

    private void Awake()
    {
        unitActionButtonList = new List<UnitActionButtonUI>();
    }

    private void Start()
    {
        Unit.Instance.onSelectedActionChanged += Instance_onSelectedActionChanged;

        CreateUnitActionButtons();
        UpdateSelectedVisual();
    }

    private void Instance_onSelectedActionChanged(object sender, System.EventArgs e)
    {
        UpdateSelectedVisual();
    }

    //
    // Summary :
    //     Create action buttons UI.
    private void CreateUnitActionButtons()
    {
        foreach (BaseAction baseAction in Unit.Instance.GetBaseUnitActions())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainerTransform);
            UnitActionButtonUI unitActionButtonUI = actionButtonTransform.GetComponent<UnitActionButtonUI>();
            unitActionButtonUI.SetBaseAction(baseAction);

            unitActionButtonList.Add(unitActionButtonUI);
        }
    }

    //
    // Summary :
    //     Create action buttons UI visual.
    private void UpdateSelectedVisual()
    {
        foreach (UnitActionButtonUI unitActionButtonUI in unitActionButtonList)
        {
            unitActionButtonUI.UpdateSelectedVisual();
        }
    }
}
