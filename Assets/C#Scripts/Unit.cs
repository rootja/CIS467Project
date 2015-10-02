using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

	// Every unit must have an algorithm or method of moving on the board.
	public abstract void Move();

	// Every unit must have an inventory.
	public abstract GameObject[] Inventory ();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
