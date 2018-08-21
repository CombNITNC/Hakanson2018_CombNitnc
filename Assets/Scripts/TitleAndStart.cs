using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAndStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyTitle(){
		GameManager scriptGM = GameObject.Find("GameManager").GetComponent<GameManager>();
		scriptGM.GameStart();
		Destroy(this.gameObject);
	}
}
