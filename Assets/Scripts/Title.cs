using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {
	[SerializeField] GameObject next;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			Instantiate(next, Vector3.zero, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
