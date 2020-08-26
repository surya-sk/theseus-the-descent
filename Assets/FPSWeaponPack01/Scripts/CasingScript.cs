using UnityEngine;
using System.Collections;

public class CasingScript : MonoBehaviour {

	void Awake () {
		//Detach after half a second
		Invoke ("DetachParent", 0.3f);
	}

	void DetachParent () {
		//Detach the casing from its parent.
		transform.SetParent (null);
	}
}
