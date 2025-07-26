using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private bool _isTargeting = false;

    #region properties

    public bool IsTargeting
    {
        get => _isTargeting;

        private set
        {
            _isTargeting = value;
        }
    }

    #endregion

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsTargeting = true;
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            IsTargeting = false;
        }
    }
}
