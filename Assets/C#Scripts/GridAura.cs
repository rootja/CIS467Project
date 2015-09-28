using UnityEngine;
using System.Collections;

public class GridAura : MonoBehaviour {

	Animator animator;

	string spritename;

	int clr;

	int timer;

	// Use this for initialization
	void Start () {
	
		// Color to display of Aura Sprite Strip
		// "SquareAuraStrip_strip4_x" where x is one of the following ints
		// 0 = Red, 1 = Blue, 2 = Yellow, 3 = Green
		int clr = 2;
		//int dist = 1;
		spritename = "SquareAuraStrip_strip4_2";

		int timer = 10;

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		//if(Collision2D.Equals(Player)){
		//	clr = 3;
		//}

		//really sloppy here, don't yell at me yet

		Vector3 check = new Vector3((this.transform.position.x),(this.transform.position.y),0F);

		// Change color to red if a bad location
		if(Physics.CheckSphere(check,0.5F)){
			clr = 0;
		}
		else{
			clr = 2;
		}

		// Change sprite to the appropriate color
		spritename = "SquareAuraStrip_strip4_" + clr;
//		animator.Play (spritename);

		// This is kind of an experiment, probably not final
     	timer--;
		if (timer < 0) {
			timeup();
		}
	}

	void timeup () {

		Destroy(this.gameObject, 0.1F);

	}
}
