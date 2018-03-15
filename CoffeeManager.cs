using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Drinks{ blackCoffee, creamCoffee , latte, espresso, turbo, nil, badDrink, cafeAuLait, americano};

public class CoffeeManager : MonoBehaviour {
	//outputs
	public Text output;

	public Drinks playerDrink;


	//components of drink
	public bool hasCoffee = false;
	public bool hasCream = false;
	public bool hasEspresso = false;
	public bool hasSteamed = false;

	// Use this for initialization
	void Start () {
		playerDrink = Drinks.nil;
		
	}

	public void addCoffee(){
		hasCoffee = !hasCoffee;
		Debug.Log ("coffee" + hasCoffee);
	}

	public void addCream(){
		hasCream = !hasCream;
		Debug.Log ("cream is" + hasCream);
	}

	public void addEspresso(){
		hasEspresso = !hasEspresso;
		Debug.Log ("hi mark = " + hasEspress);
	}
	
	public void addSteamed(){
		hasSteamed = !hasSteamed;
		Debug.Log ("steamed milk =" + hasSteamed);
	}

	public void makeDrink(){

		if (hasEspresso) {
			makeEspresso ();
		} else if (hasCoffee) {
			makeCoffee ();
		} else {
			playerDrink = Drinks.badDrink;
		}

	}

	void makeEspresso(){

		if (hasCoffee && !hasSteamed) {
			playerDrink = Drinks.turbo;
		} else if (hasSteamed) {
			playerDrink = Drinks.latte;
		} else if (!hasCream) {
			playerDrink = Drinks.espresso;
		}
	}

	void makeCoffee(){
		if (!hasSteamed && hasCream) {
			playerDrink = Drinks.creamCoffee;
			output.text = "coffee with cream";
		} else if (hasSteamed) {
			playerDrink = Drinks.cafeAuLait;
		} else if (!hasSteamed && !hasCream) {
			playerDrink = Drinks.blackCoffee;
			output.text = "black coffee";
		}else {
			playerDrink = Drinks.badDrink;
		}
	}
	// Update is called once per frame
	void Update () {
		if (playerDrink == Drinks.blackCoffee) {
			output.text = "black coffee";
		}
		if (playerDrink == Drinks.creamCoffee) {
			output.text = "coffee with cream";
		}
		if (playerDrink == Drinks.espresso) {
			output.text = "espresso";
		}
		if (playerDrink == Drinks.latte) {
			output.text = "latte";
		}
		if (playerDrink == Drinks.turbo) {
			output.text = "Turbo!!";
		}
		if (playerDrink == Drinks.cafeAuLait) {
			output.text = "Cafe au lait!";
		}
		if (playerDrink == Drinks.badDrink) {
			output.text = "bad drink :<";
		}
	}
}
