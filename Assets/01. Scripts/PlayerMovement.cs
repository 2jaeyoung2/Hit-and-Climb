using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;

    private Rigidbody rb;

    private int _moveSpeed;

    #region properties

    public int MoveSpeed
    {
        get => _moveSpeed;

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _moveSpeed = value;

            Debug.Log("current speed: " + _moveSpeed);
        }
    }

    #endregion

    private void FixedUpdate()
    {
        // moveDirection(방향)이 있다면
        if (moveDirection != Vector2.zero)
        {
            
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            moveDirection = ctx.ReadValue<Vector2>().normalized;
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            moveDirection = Vector2.zero;
        }
    }
}
