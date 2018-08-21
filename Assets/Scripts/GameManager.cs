using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	MoneyManager moneyManagerScript;
	[SerializeField] GameObject coin100;
	[SerializeField] GameObject coin10;
	// Use this for initialization
	void Start () {
		moneyManagerScript = GetComponent<MoneyManager>();
		moneyManagerScript.ChangeMoney(100);
	}
	
	// Update is called once per frame
	void Update () {	
		Run();
		
		// Debug お金を1000円に固定
		// moneyManagerScript.ChangeMoney(1000);
	}

	private void Run(){
		Random.Range(1,1);
		// Space入力で10円追加
		if(Input.GetKeyDown(KeyCode.Space)){
			if(Random.Range(0, 100) < 10) Instantiate(coin100, Vector2.zero, Quaternion.identity);
			else Instantiate(coin10, Vector2.zero, Quaternion.identity);
		}
	}
}
