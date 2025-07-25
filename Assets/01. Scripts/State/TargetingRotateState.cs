using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingRotateState : IPlayerRotationStates
{
    PlayerRotation player;

    public void EnterState(PlayerRotation player)
    {
        this.player = player;

        this.player.PlayerMovement.MoveSpeed = 2.5f; // Ÿ���� �� �ӵ� ����
    }

    public void UpdatePerState()
    {
        TargetingRotation();

        // V ���� ��ȯ ����
        if (player.PlayerAttack.IsTargeting == false) // Ÿ���� ������ ��
        {
            player.ChangeStateTo(new NormalRotateState());
        }
    }

    public void ExitState()
    {
        player.PlayerMovement.ResetMoveSpeed(); // Ÿ���� ���� �� �ӵ� ���󺹱�
    }

    private void TargetingRotation()
    {
        // TODO: Ÿ���� �� ���콺 Ŀ�� ��ġ �ٶ󺸰� �ؾߵ�.
    }
}
