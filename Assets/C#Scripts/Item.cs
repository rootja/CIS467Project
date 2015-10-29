using UnityEngine;
using System.Collections;

public class Item {

	public string Name { get; set; }

	public Item(string itemName){
		if(itemName.Contains("(Clone)")){
			Name = itemName.Substring(0, itemName.Length - 7);
		}
		else{
			Name = itemName;
		}
	}

	// Every item should have some sort of an effect when used.
	public void Use (Player player){
		switch (Name) {
		case "Heart":
			player.Health++;
			break;
		case "RupeeSmall":
			player.Currency++;
			break;
		case "RupeeMedium":
			player.Currency += 5;
			break;
		case "RupeeLarge":
			player.Currency += 10;
			break;
		case "HealthPotion":
			player.Health += 5;
			break;
		}
	}

}
