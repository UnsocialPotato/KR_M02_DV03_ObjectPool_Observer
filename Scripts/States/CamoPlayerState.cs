using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamoPlayerState : IPlayerState
{
    Material m_Material;

    public void Enter(Player player)
    {
        Debug.Log("Entering State: Camo");
        m_Material = player.GetComponent<Renderer>().material;
        m_Material.color = Color.white;
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.F))
        {
            m_Material = player.GetComponent<Renderer>().material;
            m_Material.color = Color.red;
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}
