using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Heroes")]
public class Heroes : ScriptableObject {

	public string heroName = "Default Name";
    public string bio = "";
    public float health;
    public float healthRegen;
	public float mana;
    public float manaRegen;
    public float attackDamage;
    public float attackSpeed;
	public float magicDamge;
	public float defense;
	public float resistance;
    public float movementSpeed;
	public float jumpForce;
	
	// Defense Penetration
	// Resist Penetration
	// Life Steal
	// Critical
	// Critical Damage
	// Movement Speed
   
}
