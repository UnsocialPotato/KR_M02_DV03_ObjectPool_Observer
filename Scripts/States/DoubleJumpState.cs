using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;
    float launchTime;

    public void Enter(Player player)
    {
        Debug.Log("Entering State: Double Jump");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.velocity = new Vector3(0, 5, 0);
        launchTime = Time.time;
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, .5f) && (Time.time - launchTime > 0.5f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DivingPlayerState divingState = new DivingPlayerState();
            divingState.Enter(player);
        }
    }
}
