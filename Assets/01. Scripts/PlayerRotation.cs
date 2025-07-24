using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;

    private IPlayerStatesRotation currentState;

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

        Debug.Log(currentState);

        RotateSpeed = 10f;
    }

    private void FixedUpdate()
    {
        currentState.UpdatePerState();
    }

    public void ChangeStateTo(IPlayerStatesRotation states)
    {
        currentState?.ExitState();

        currentState = states;

        currentState.EnterState(this);
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        // TODO: 공격 플래그
    }
}