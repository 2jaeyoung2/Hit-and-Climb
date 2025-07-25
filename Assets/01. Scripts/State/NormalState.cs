using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IPlayerRotationStates
{
    PlayerRotation player;

    public void EnterState(PlayerRotation player)
    {
        this.player = player;
    }

    public void UpdatePerState()
    {
        if (player.PlayerMovement.InputVector != Vector2.zero)
        {
            Vector3 moveVector = new Vector3(player.PlayerMovement.InputVector.x, 0, player.PlayerMovement.InputVector.y);

            Quaternion targetRotation = Quaternion.LookRotation(moveVector);

            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.fixedDeltaTime * player.RotateSpeed);
        }
    }

    public void ExitState()
    {

    }
}
