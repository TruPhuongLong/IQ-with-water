using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelController : MonoBehaviour
{
	Vector3 start;

	// Start is called before the first frame update
	void Start()
    {
		
    }

	public void translateTo(Transform location) {
		start = transform.position;
		transform.position = location.transform.position;
	}

	public void resetPosition() {
		transform.position = start;
	}
}
