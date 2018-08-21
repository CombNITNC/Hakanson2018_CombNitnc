using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	MoneyManager moneyManagerScript;
	[SerializeField] GameObject Coin100;
	// Use this for initialization
	void Start () {
		moneyManagerScript = GetComponent<MoneyManager>();
		moneyManagerScript.ChangeMoney(100);
	}
	
	// Update is called once per frame
	void Update () {	
		Run();
	}

	private void Run(){
		// Space入力で10円追加
		if(Input.GetKeyDown(KeyCode.Space)){
			Instantiate(Coin100, Vector2.zero, Quaternion.identity);
		}
	}
}
