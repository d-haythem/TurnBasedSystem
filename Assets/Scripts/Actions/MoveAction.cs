using System;
using UnityEngine;

public class MoveAction : BaseAction
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 targetPosition;
    private Animator animator;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponentInChildren<Animator>();

        targetPosition = transform.position;
    }

    private void Update()
    {
        HandleUnitMovement();
    }

    //
    // Summary :
    //     Unit take action.
    public override void TakeAction(Vector3 targetPosition, Action onActionCompleted)
    {
        base.TakeAction(targetPosition, onActionCompleted);
        
        this.targetPosition = targetPosition;
    }

    //
    // Summary :
    //     Move the unit to the target direction.
    private void HandleUnitMovement()
    {
        if (!isActive) return;

        float stoppingDistance = .1f;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            HandleUnitRotation(moveDirection);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            isActive = false;
            onActionCompleted();
        }
    }

    //
    // Summary :
    //     Fix unit rotation based on the target position direction.
    private void HandleUnitRotation(Vector3 moveDirection)
    {
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    //
    // Summary :
    //     Return action name.
    public override string GetActionName()
    {
        return "Move";
    }
}
