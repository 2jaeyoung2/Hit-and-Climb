using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 tempVector;

    [SerializeField]
    private Rigidbody rb;

    private float _moveSpeed;

    private float _rotateSpeed;

    #region properties

    public float MoveSpeed
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

    public float RotateSpeed
    {
        get => _rotateSpeed;

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _rotateSpeed = value;
        }
    }

    #endregion

    private void Start()
    {
        MoveSpeed = 5f;

        RotateSpeed = 10f;
    }

    private void FixedUpdate()
    {
        // tempVector(방향)이 있다면
        if (tempVector != Vector2.zero)
        {
            Vector3 moveVector = new Vector3(tempVector.x, 0, tempVector.y);

            Quaternion targetRotation = Quaternion.LookRotation(moveVector);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * RotateSpeed);

            moveVector = MoveSpeed * moveVector * Time.fixedDeltaTime;

            rb.MovePosition(transform.position + moveVector);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            tempVector = ctx.ReadValue<Vector2>().normalized;

            Debug.Log(tempVector);
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            tempVector = Vector2.zero;

            rb.velocity = Vector3.zero;
        }
    }
}
