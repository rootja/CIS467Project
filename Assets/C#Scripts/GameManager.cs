using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject cynthia;

	// Use this for initialization
	void Start () {
		Instantiate (player);
		Instantiate (cynthia);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
