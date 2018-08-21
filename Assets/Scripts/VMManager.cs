using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VMManager : MonoBehaviour {
	private MoneyManager moneyManagerScript;

	[SerializeField] private GameObject[] canList;
	[SerializeField] private Text[] keyText;
	private GameObject canEntryPoint;
	private int num_q;
	private int count;

	private struct Can {
		public string key;
		public int price;

		public Can(string k, int p){
			key = k;
			price = p;
		}
	}

	Can[] product = new Can[4];

	// Use this for initialization
	void Start () {
		moneyManagerScript = GameObject.Find("GameManager").GetComponent<MoneyManager>();
		canEntryPoint = GameObject.Find("CanEntryPoint");
		count = 0;
		product[0] = new Can("a", 130);
		product[1] = new Can("s", 100);
		product[2] = new Can("d", 200);
		product[3] = new Can("f", 160);


		SetProduct();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < product.Length; i++){
			if(Input.GetKeyDown(product[i].key)){
				if(moneyManagerScript.GetMoney() >= product[i].price) {
					moneyManagerScript.AddMoney(-product[i].price);
					Instantiate(canList[i], canEntryPoint.transform.position, Quaternion.identity);
					
					// 指定キーの入力で商品を購入
					if(i == num_q){
						count++;
						SetProduct();
					}
				}
			}
		}
	}
	
	private void  SetProduct(){
		// 購入キーの設定
		num_q= Random.Range(0,product.Length);

		// 表示
		for(int i = 0; i < keyText.Length; i++){
			keyText[i].text = "Press " + product[num_q].key + "\n¥" + product[num_q].price;
		}
	}

	public int GetCount(){
		return count;
	}
}
