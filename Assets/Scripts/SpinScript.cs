using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour {


    public int rotSpeed = 3;
    public int bobSpeed = 1;
    private Vector3 startPos;
    private bool goUp = true;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));

        if (goUp)
        {
            transform.Translate(new Vector3(0, bobSpeed * Time.deltaTime, 0));
        } else
        {
            transform.Translate(new Vector3(0, -bobSpeed * Time.deltaTime, 0));
        }


        if(transform.position.y >= startPos.y + 1)
        {
            goUp = false;
        } else if(transform.position.y <= startPos.y)
        {
            goUp = true;
        }
	}
}
