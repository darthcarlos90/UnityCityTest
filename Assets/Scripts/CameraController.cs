using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour {

    public GameObject targetObject;
    private Vector3 offset;
	
	// Update is called once per frame
	void Update () {
        // move from local space to world space and move?
        offset = targetObject.transform.TransformPoint(0, 15, 30);

        // So move the camera in a difference of 7 units from the object we are following
        transform.position = Vector3.Lerp(transform.position, offset, 7 * Time.deltaTime);

        // keep looking at the position of the object
        transform.LookAt(targetObject.transform.position);
	}
}
