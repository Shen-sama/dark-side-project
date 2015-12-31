using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player 
{
	//Info
	public string Name;
	public int Level;
	public int SkillPoints;
	public int HealthPoints;
	public int ManaPoints;
	public Sprite Portrait;

	//Status (Visible)
	public int Strenght;
	public int Agility;
	public int Inteligence;
	public int Luck;
	public int PhysicalAttack;
	public int MagicalAttack;
	public int PhysicalDefense;
	public int MagicalDefense;

	//Status (Visible)
	public int CriticalChance;
	public int EvasionChance;
	public int TurnTime;

	//Skills

	//Itens

	public Player(string name, int level, int healthPoints, int manaPoints, int strenght, int agility, 
	              int inteligence, int luck, int physicalAttack, int magicalAttack, int physicalDefense, 
	              int magicalDefense)
	{
		Name = name;
		Level = level;
		SkillPoints = 5 + (inteligence / 2);
		Strenght = strenght;
		Agility = agility;
		Inteligence = inteligence;
		Luck = luck;
		PhysicalAttack = physicalAttack;
		MagicalAttack = magicalAttack;
		PhysicalDefense = physicalDefense;
		MagicalDefense = magicalDefense;

		HealthPoints = healthPoints;
		ManaPoints = manaPoints;

		Portrait = Resources.Load<Sprite> ("Playable Characters/" + name);
	}

	public void UpdatingHPMP()
	{
		HealthPoints += (Strenght * 19);
		ManaPoints += (Inteligence * 9);
	}
}
