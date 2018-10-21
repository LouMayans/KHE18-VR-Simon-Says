using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonAction : ScriptableObject {
    [HideInInspector]
    public VRInputs vrInput;
    public SimonAction negativeAction;
    public string actionName = "DefaultName";
    public float actionTime = 1;

    public virtual void ActionStart(VRInputs vrinp)
    {
        if (vrInput == null)
            vrInput = vrinp;
        if (negativeAction != null)
            negativeAction.ActionStart(vrInput);
    }
    public virtual bool CheckAction(bool doAction)
    {
        if (negativeAction != null)
        {
            return negativeAction.CheckAction(true);
        }
        else
        {
            Debug.Log("No negative action");
            return true;
        }
    }
    public virtual void ActionEnd() { }

    public virtual void OnCollisionEnters(Collider col) { }
    public virtual void OnCollisionStays(Collider col) { }
    public virtual void OnCollisionExits(Collider col) { }
}
