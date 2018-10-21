using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
[CreateAssetMenu(menuName ="SimonAction/MoveAroundAction")]
public class MoveAroundAction : SimonAction
{
    

    private Vector3 leftHandStart;
    private Vector3 rightHandStart;
    private Vector3 HeadStart;
    private Vector3 leftHandCurrent;
    private Vector3 rightHandCurrent;
    private Transform HeadCurrent;

    public float distanceToMove;

    public override void ActionStart(VRInputs inp)
    {
        base.ActionStart(inp);
        leftHandStart = vrInput.handPose.GetLastLocalPosition(SteamVR_Input_Sources.LeftHand);
        rightHandStart = vrInput.handPose.GetLastLocalPosition(SteamVR_Input_Sources.RightHand);
        HeadStart = vrInput.head.position;
    }
    public override bool CheckAction(bool doAction)
    {
        if(!doAction)
            return base.CheckAction(true);

        leftHandCurrent = vrInput.handPose.GetLocalPosition(SteamVR_Input_Sources.LeftHand);
        rightHandCurrent = vrInput.handPose.GetLocalPosition(SteamVR_Input_Sources.RightHand);
        if (Vector3.Distance(leftHandStart, leftHandCurrent) > vrInput.cameraRig.transform.localScale.x * distanceToMove)
            return true;
        if (Vector3.Distance(rightHandStart, rightHandCurrent) > distanceToMove)
            return true;
        if (Vector3.Distance(HeadStart, vrInput.head.transform.position) > distanceToMove)
            return true;
        return false;
    }
}
