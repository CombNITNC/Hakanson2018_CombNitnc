using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = transform.position;
		pos -= new Vector2(0.1f, 0);
		this.transform.position = pos;
	}
}
