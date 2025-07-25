using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;

    private IPlayerRotationStates currentRotationState;

    private float _rotateSpeed;

    #region properties

    public PlayerMovement PlayerMovement
    {
        get => _playerMovement;
    }

    public float RotateSpeed
    {
        get => _rotateSpeed;

        set
        {
            _rotateSpeed = value;
        }
    }
    #endregion

    private void Start()
    {
        ChangeStateTo(new NormalState());

        Debug.Log(currentRotationState);

        RotateSpeed = 25f;
    }

    private void FixedUpdate()
    {
        currentRotationState.UpdatePerState();
    }

    public void ChangeStateTo(IPlayerRotationStates states)
    {
        currentRotationState?.ExitState();

        currentRotationState = states;

        currentRotationState.EnterState(this);
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        // TODO: 공격 플래그
    }
}