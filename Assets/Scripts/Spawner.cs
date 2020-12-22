using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject obstacle;

	private float time_elapsed;
	public float spawn_cd;
	public float decreaseTime;
	public float minTime = 0.65f;
	private Vector3 highSpawnTransform = new Vector3(0f, 1.25f, 0f);

	// Update is called once per frame
	void Update () {
		if(time_elapsed <= 0)
        {



			int rand = Random.Range(0, 2);
			if (rand == 0)
            {
				Instantiate(obstacle, transform.position, Quaternion.identity);
			}
            else
            {
				Instantiate(obstacle, transform.position+highSpawnTransform, Quaternion.identity);
			}


			time_elapsed = spawn_cd;
			if (spawn_cd > minTime)
            {
				spawn_cd -= decreaseTime;
            }
        }

		else
        {
			time_elapsed -= Time.deltaTime;
        }
	}
}
