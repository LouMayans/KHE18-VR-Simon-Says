using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SimonAction/CutObjectAction")]
public class CutObjectAction : SimonAction
{
    public GameObject cuttingToolPrefab;
    public GameObject objectToCutPrefab;

    private GameObject cuttingTool;
    private GameObject objectToCut;

    bool objectCut;


    public override void ActionStart(VRInputs vrinp)
    {
        objectCut = false;
        base.ActionStart(vrinp);
        cuttingTool = Instantiate<GameObject>(cuttingToolPrefab);
        
        cuttingTool.transform.SetParent(vrInput.leftHandObj.transform);
        cuttingTool.transform.localRotation = Quaternion.identity;
        cuttingTool.transform.localPosition = Vector3.zero;
        objectToCut = Instantiate<GameObject>(objectToCutPrefab);
        objectToCut.transform.position = (new Vector3(vrInput.head.transform.forward.x, 1, vrInput.head.transform.forward.z) * 1) + vrInput.head.transform.position;
        //objectToCut.transform.position = new Vector3(objectToCut.transform.position.x -1 ,vrInput.head.position.y * .6f, objectToCut.transform.position.z);
        ObjectCollisionBridge ocb = cuttingTool.GetComponentInChildren<ObjectCollisionBridge>();
        if (ocb)
        {
            ocb.init(this);
        }
    }

    public override bool CheckAction(bool doAction)
    {
        return objectCut;
    }

    public override void ActionEnd()
    {
        Destroy(cuttingTool);
        Destroy(objectToCut);
        objectToCut = null;
        cuttingTool = null;
    }
    public override void OnCollisionEnters(Collider col)
    {
        if (col.gameObject == objectToCut)
        {
            objectCut = true;
            Destroy(objectToCut);
            objectToCut = null;
        }
           
    }

}

