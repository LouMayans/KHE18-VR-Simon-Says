using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollisionBridge : MonoBehaviour {
    private SimonAction _action;
    // Use this for initialization
    public void init (SimonAction action) {
        _action = action;
	}

    private void OnCollisionEnter(Collision iCollision)
    {
        if (_action)
            _action.OnCollisionEnters(iCollision.collider);
    }
    private void OnCollisionExit(Collision iCollision)
    {
        if (_action)
            _action.OnCollisionEnters(iCollision.collider);
    }
    private void OnCollisionStay(Collision iCollision)
    {
        if (_action)
            _action.OnCollisionEnters(iCollision.collider);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_action)
            _action.OnCollisionEnters(other);
    }
}
