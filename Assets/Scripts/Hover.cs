using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {


	private bool goDown = true;
	
	// Update is called once per frame
	void Update () {

		Vector3 vertical = new Vector3(0.0f, 0.75f, 0.0f);


		if (transform.position.y >= -4.20f && goDown == true)
        {
			transform.position = transform.position - vertical * Time.deltaTime;
		}
        else
        {
			goDown = false;
        }

		if (transform.position.y < 2.20f && goDown == false)
		{
			transform.position = transform.position + vertical * Time.deltaTime;
		}
        else
        {
			goDown = true;
        }



	}
}
