using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SimonAction/DabAction")]
public class DabAction : SimonAction {

    public override bool CheckAction(bool doAction)
    {
        if(!doAction)
            return base.CheckAction(true);

        if (vrInput.handPose.GetLocalPosition(Valve.VR.SteamVR_Input_Sources.LeftHand).y > vrInput.head.position.y
            && vrInput.handPose.GetLocalPosition(Valve.VR.SteamVR_Input_Sources.RightHand).y > vrInput.head.position.y)
        {
            Vector3 leftHandDirection = vrInput.head.position - vrInput.handPose.GetLocalPosition(Valve.VR.SteamVR_Input_Sources.LeftHand);
            Vector3 rightHandDirection = vrInput.head.position - vrInput.handPose.GetLocalPosition(Valve.VR.SteamVR_Input_Sources.RightHand);
            float leftHandResult = LouMath.AngleDir(vrInput.head.forward, leftHandDirection, Vector3.up);
            float rightHandResult = LouMath.AngleDir(vrInput.head.forward, rightHandDirection, Vector3.up);

            if (leftHandResult == rightHandResult && leftHandResult != 0)
                return true;
            return false;
        }
        else
            return false;
    }
}
