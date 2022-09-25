using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    public void Enter(Player player)
    {
        Debug.Log("Entering State: Sprint");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.AddForce(0, 0, 3000 * Time.deltaTime, ForceMode.VelocityChange);
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}
