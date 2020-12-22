using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_destroyer : MonoBehaviour {

	// Use this for initialization
	public float lifetime;

	void Start () {
		Destroy(gameObject, lifetime);
	}
	
}
