using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    public static Unit Instance { get; private set; }

    public event EventHandler onSelectedActionChanged;
    public event EventHandler<bool> onBusyChanged;

    [SerializeField] private LayerMask groundLayerMask;

    private MoveAction moveAction;
    private BaseAction[] baseUnitActions;
    private BaseAction selectedAction;

    public bool isBusy;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        moveAction = GetComponent<MoveAction>();
        baseUnitActions = GetComponents<BaseAction>();

        SetSelectedAction(moveAction);
    }

    private void Update()
    {
        if (isBusy) return;

        HandleSelectedAction();
    }

    //
    // Summary :
    //     Handle Unit action based on the selected UI action.
    private void HandleSelectedAction()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            SetUnitToBusy();
            selectedAction.TakeAction(MouseUtility.GetMouseWorldPosition(), ClearUnitBusyState);
        }
    }

    //
    // Summary :
    //     Set Unit state to busy when any action is taken.
    public void SetUnitToBusy()
    {
        isBusy = true;

        onBusyChanged?.Invoke(Instance, isBusy);
    }

    //
    // Summary :
    //     Reset Unit to unbusy state.
    public void ClearUnitBusyState()
    {
        isBusy = false;

        onBusyChanged?.Invoke(Instance, isBusy);
    }

    //
    // Summary :
    //     Return available unit actions.
    public BaseAction[] GetBaseUnitActions()
    {
        return baseUnitActions;
    }

    //
    // Summary :
    //     Set unit current selected action.
    public void SetSelectedAction(BaseAction baseAction)
    {
        if (isBusy) return;

        selectedAction = baseAction;

        onSelectedActionChanged?.Invoke(this, EventArgs.Empty);
    }

    //
    // Summary :
    //     Return unit selected action.
    public BaseAction GetSelectedAction()
    {
        return selectedAction;
    }
}
