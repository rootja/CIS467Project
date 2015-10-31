using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

	//These text objects display gameplay information to the player.
	public Text HealthText;
	public Text SkillText;
	public Text RupeeText;

	// Use this for initialization
	void Start () {
		//The following block sets up the HUD
		HealthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		HealthText.enabled = true;
		SkillText = GameObject.Find ("SkillText").GetComponent<Text> ();
		SkillText.enabled = true;
		RupeeText = GameObject.Find ("RupeeText").GetComponent<Text> ();
		RupeeText.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (PauseScript.isKeysEnabled) {
			HealthText.enabled = true;
			HealthText.text = "HEALTH: " + Player.health;
			SkillText.enabled = true;
			SkillText.text = "PLAYER LEVEL: " + Player.playerLevel;
			RupeeText.enabled = true;
			RupeeText.text = "RUPEES: " + Player.currency;
		} else {
			HealthText.enabled = false;
			SkillText.enabled = false;
			RupeeText.enabled = false;
		}


	}
}
