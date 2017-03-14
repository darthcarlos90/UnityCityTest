using UnityEngine;
using System.Collections;

public class PlayerHandler: MonoBehaviour {

    // Public accesors so the variables can be accesed from the Engine's UI
    public float speed;
    public float rotatioSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Hello World the time is " + Time.time);

        // Letters must be lowercase
        

        if (Input.GetKey("w"))
        {
            /**
             * Multiply the value by deltatime so that we have a satic speed no matter the users framerate
            **/
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        else if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(new Vector3(0, 1, 0) * speed * rotatioSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("a"))
        {
            transform.Rotate(new Vector3(0, -1, 0) * speed * rotatioSpeed * Time.deltaTime);
        }
    }
}
