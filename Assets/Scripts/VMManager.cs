using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VMManager : MonoBehaviour {
	private MoneyManager scriptMoneyManager;
	private GameManager scriptGameManager;
	[SerializeField] private GameObject[] canList;
	[SerializeField] private Text[] keyText;
	private GameObject canEntryPoint;
	private int num_q;
	private int num_oldq;
	private int count;
	

	private struct Can {
		public string key;
		public int price;

		public Can(string k, int p){
			key = k;
			price = p;
		}
	}

	[SerializeField] Can[] product = new Can[6];

	// Use this for initialization
	void Start () {
		scriptMoneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
		scriptGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		canEntryPoint = GameObject.Find("CanEntryPoint");
		count = 0;
		product[0] = new Can("a", 130);
		product[1] = new Can("s", 100);
		product[2] = new Can("d", 200);
		product[3] = new Can("f", 160);
		product[4] = new Can("z", 120);
		product[5] = new Can("x", 300);


		num_oldq = SetProduct();
	}
	
	// Update is called once per frame
	void Update () {
		if(scriptGameManager.gameFlag){
			for(int i = 0; i < product.Length; i++){
				if(Input.GetKeyDown(product[i].key)){
					if(scriptMoneyManager.GetMoney() >= product[i].price) {
						scriptMoneyManager.AddMoney(-product[i].price);
						Instantiate(canList[i], canEntryPoint.transform.position, Quaternion.identity);
						
						// 指定キーの入力で商品を購入
						if(i == num_q){
							count++;
							num_oldq = SetProduct();
						}
					}
				}
			}
		}
	}
	
	private int  SetProduct(){
		// 購入キーの設定
		num_q= Random.Range(0,product.Length);
		
		if(num_q == num_oldq){
			if(num_q == product.Length - 1) num_q = 0;
			else num_q++;
		}

		// 表示
		for(int i = 0; i < keyText.Length; i++){
			keyText[i].text = "Press [" + product[num_q].key + "]\n¥" + product[num_q].price;
		}

		return num_q;
	}

	public int GetCount(){
		if(count == null) return 0;
		return count;
	}
}
