using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour {

	public Text customerOrder;

	public Text displayScore;

	public GameObject victoryText;
	private Animator thanks;

	private CoffeeManager coffeeManager;

	public Drinks customerWants;
	public static int score = 0;
	// Use this for initialization
	void Start () {

		coffeeManager = FindObjectOfType<CoffeeManager> ();

		thanks = victoryText.GetComponent<Animator> ();

		GenerateOrder ();
	}

	void Display(string order){
		customerOrder.text = order;
	}

	void DisplayOrder(){
		if(customerWants == Drinks.blackCoffee){
			Display ("I'll have black coffee!");
		}
		if (customerWants == Drinks.cafeAuLait) {
			Display ("Cafe au Lait please thank you");
		}
		if(customerWants == Drinks.creamCoffee){
			Display ("coffee and cream.");
		}
		if(customerWants == Drinks.latte){
			Display("I'd like a latte");
		}
		if (customerWants == Drinks.badDrink) {
			Display ("milk.");
		}
		if (customerWants == Drinks.nil) {
			GenerateOrder ();
		}
		if (customerWants == Drinks.turbo) {
			Display ("I'll have a turbo~!");
		}
	}

	void GenerateOrder(){
		customerWants = GetRandomEnum<Drinks> ();
		Debug.Log (customerWants);
	}
	// Update is called once per frame
	void Update () {
		DisplayOrder ();

		displayScore.text = "" + score;

		if (customerWants == coffeeManager.playerDrink) {
			thanks.SetTrigger ("correctOrder");
			score++;
			GenerateOrder ();
		}
	}

	//not my code -- comes from bunny83 at answers.unity ty ty
	//using it call random orders
	static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
		return V;
	}
}
