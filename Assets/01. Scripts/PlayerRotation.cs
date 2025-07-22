using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    private float _rotateSpeed;

    public float RotateSpeed
    {
        get => _rotateSpeed;

        set
        {
            _rotateSpeed = value;
        }
    }

    private void FixedUpdate()
    {
        if (playerMovement.InputVector != Vector2.zero)
        {
            Debug.Log(playerMovement.InputVector);

            Vector3 moveVector = new Vector3(playerMovement.InputVector.x, 0, playerMovement.InputVector.y);

            Quaternion targetRotation = Quaternion.LookRotation(moveVector);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * RotateSpeed);
        }
    }
}