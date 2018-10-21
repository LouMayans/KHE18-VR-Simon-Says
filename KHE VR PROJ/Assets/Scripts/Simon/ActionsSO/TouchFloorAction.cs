using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SimonAction/TouchFloorAction")]
public class TouchFloorAction : SimonAction {

    public float distanceFromFloor;
    public bool leftHand;
    public bool rightHand;

    public override bool CheckAction(bool doAction)
    {
        if ( 
            (leftHand == (vrInput.handPose.GetLocalPosition(Valve.VR.SteamVR_Input_Sources.LeftHand).y < distanceFromFloor))
            && (rightHand == (vrInput.handPose.GetLocalPosition(Valve.VR.SteamVR_Input_Sources.RightHand).y < distanceFromFloor))
            )
            return true;
        return false;
    }
}
