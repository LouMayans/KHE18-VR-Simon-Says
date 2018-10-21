using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SimonAction/DuckAction")]
public class DuckAction : SimonAction {
    public float duckdistanceMultiplier;
    public override bool CheckAction(bool doAction)
    {
        if(!doAction)
            return base.CheckAction(true);

        if (vrInput.head.position.y < vrInput.playerHeight * duckdistanceMultiplier)
            return true;
        return false;
    }
}
