using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
	private MoneyManager moneyManagerScript;
	
	// Use this for initialization
	void Start () {
		moneyManagerScript = GameObject.Find("GameManager").GetComponent<MoneyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CoinDestroy(){
		moneyManagerScript.AddMoney(100);
		Destroy(this.gameObject);
	}
}
