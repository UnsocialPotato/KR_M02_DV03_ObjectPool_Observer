using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Standing");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }

        //ducking
        if (Input.GetKeyDown(KeyCode.S))
        {
            DuckingPlayerState duckingState = new DuckingPlayerState();
            duckingState.Enter(player);
        }

        //sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SprintPlayerState sprintState = new SprintPlayerState();
            sprintState.Enter(player);
        }

        //camo or color change
        if (Input.GetKeyDown(KeyCode.F))
        {
            CamoPlayerState camoState = new CamoPlayerState();
            camoState.Enter(player);
        }
    }
}
