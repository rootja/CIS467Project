using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

	// Every item should have some sort of an effect when either acquired or used.
	public abstract void Effect ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
