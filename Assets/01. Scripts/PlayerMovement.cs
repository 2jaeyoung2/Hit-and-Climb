using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private Vector2 _inputVector;

    private float _moveSpeed;

    #region properties

    public Vector2 InputVector
    {
        get => _inputVector;

        private set
        {
            _inputVector = value;
        }
    }

    public float MoveSpeed
    {
        get => _moveSpeed;

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            if (_moveSpeed != value) // ���ο� ���� ������
            {
                Debug.Log("current speed: " + value);
            }

            _moveSpeed = value;
        }
    }
    #endregion

    private void Start()
    {
        MoveSpeed = 5f;
    }

    private void FixedUpdate()
    {
        // tempVector(����)�� �ִٸ�
        if (InputVector != Vector2.zero)
        {
            Vector3 moveVector = new Vector3(InputVector.x, 0, InputVector.y);

            moveVector = MoveSpeed * moveVector * Time.fixedDeltaTime;

            rb.MovePosition(transform.position + moveVector);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            InputVector = ctx.ReadValue<Vector2>().normalized;
        }
        else if (ctx.phase == InputActionPhase.Canceled)
        {
            InputVector = Vector2.zero;

            rb.velocity = Vector3.zero;
        }
    }
}
