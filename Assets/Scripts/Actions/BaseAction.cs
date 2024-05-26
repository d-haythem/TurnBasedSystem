using System;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected Action onActionCompleted;

    protected bool isActive;

    protected virtual void Awake()
    {
    }

    //
    // Summary :
    //     Return action name.
    public abstract string GetActionName();

    //
    // Summary :
    //     Generic action method.
    public virtual void TakeAction(Vector3 targetPosition, Action onActionCompleted)
    {
        this.onActionCompleted = onActionCompleted;
        isActive = true;
    }
}
