using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
	public enum CoinList{
		Coin10,
		Coin100,
		none,
	}
	[SerializeField] CoinList KindofCoin = CoinList.none;

	private MoneyManager moneyManagerScript;
	
	// Use this for initialization
	void Start () {
		moneyManagerScript = GameObject.Find("GameManager").GetComponent<MoneyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CoinDestroy(){
		switch (KindofCoin.ToString()){
			case "Coin10":
				moneyManagerScript.AddMoney(10);
				break;
			case "Coin100":
				moneyManagerScript.AddMoney(100);
				break;
			default:
				return;
		}

		Destroy(this.gameObject);
	}
}
