using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VMManager : MonoBehaviour {
	private MoneyManager moneyManagerScript;

	[SerializeField] private GameObject can;
	[SerializeField] private Text keyText;
	private GameObject canEntryPoint;
	private string[] keys = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
	private int num_q;

	// Use this for initialization
	void Start () {
		moneyManagerScript = GameObject.Find("GameManager").GetComponent<MoneyManager>();
		canEntryPoint = GameObject.Find("CanEntryPoint");
		num_q = SetKey();
	}
	
	// Update is called once per frame
	void Update () {
		// 指定キーの入力で商品を購入
		if(Input.GetKeyDown(keys[num_q])){
			if(moneyManagerScript.GetMoney() >= 100) {
				moneyManagerScript.AddMoney(-100);
				Instantiate(can, canEntryPoint.transform.position, Quaternion.identity);
				num_q = SetKey();
			}
		}
	}
	
	private int SetKey(){
		int num = Random.Range(0,keys.Length);
		keyText.text = "Press " + keys[num];
		return num;
	}
}
