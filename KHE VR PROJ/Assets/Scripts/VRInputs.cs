using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
public class VRInputs : MonoBehaviour {
    public Transform cameraRig;
    public SteamVR_Action_Pose handPose;
    public SteamVR_Action_Boolean handTrigger;
    public SteamVR_Action_Boolean handGrip;
    public Transform head;
    public float playerHeight;
    public GameObject leftHandObj;
    public GameObject rightHandObj;
    private void Start()
    {
        playerHeight = head.position.y;
    }


    private void Update()
    {
        /*RaycastHit raycastHit;
        if (Physics.Raycast(leftHandObj.transform.position, leftHandObj.transform.forward, out raycastHit))
        {
            Button button = raycastHit.collider.gameObject.GetComponent<Button>();
            Debug.Log(raycastHit.collider.name);


            if (button && handTrigger.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                button.onClick.Invoke();
            }
                
        }*/
    }
}
