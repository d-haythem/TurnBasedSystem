using System;
using UnityEngine;

public class SpinAction : BaseAction
{
    private float totalSpinAmount;

    private void Update()
    {
        if (!isActive) return;

        HandleUnitRotation();
    }

    //
    // Summary :
    //     Spin unit once.
    private void HandleUnitRotation()
    {
        float spinAmount = 360f * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, spinAmount, 0);

        totalSpinAmount += spinAmount;

        if (totalSpinAmount >= 360f)
        {
            isActive = false;
            onActionCompleted();
        }
    }

    //
    // Summary :
    //     Generic action method.
    public override void TakeAction(Vector3 targetPosition, Action onActionCompleted)
    {
        base.TakeAction(targetPosition, onActionCompleted);

        totalSpinAmount = 0;
    }

    //
    // Summary :
    //     Return action name.
    public override string GetActionName()
    {
        return "Spin";
    }
}
