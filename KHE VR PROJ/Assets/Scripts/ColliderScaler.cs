using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScaler : MonoBehaviour {
	
	void Update () {
        gameObject.GetComponent<BoxCollider>().size = new Vector3(
        gameObject.GetComponent<RectTransform>().rect.width,
        gameObject.GetComponent<RectTransform>().rect.height,
        0
        );
    }
}
