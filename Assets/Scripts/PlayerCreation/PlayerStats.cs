using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerStats 
{
	public int Level;
	public int SkillPoints;
	public int HealthPoints;
	public int ManaPoints;

	public int Strenght;
	public int Agility;
	public int Inteligence;
	public int Luck;
	public int PhysicalAttack;
	public int MagicalAttack;
	public int PhysicalDefense;
	public int MagicalDefense;

	public int CriticalChance;
	public int EvasionChance;
	public int TurnTime;

	public void InitialStats(string playerName)
	{
		//SkillPoints = 5 + (Inteligence / 2);

		if (playerName == "Shen Shi Harzgard") 
		{
			Level = 1;
			HealthPoints = 320;
			ManaPoints = 100;
			Strenght = 10;
			Agility = 15;
			Inteligence = 6;
			Luck = 12;
			PhysicalAttack = 60;
			MagicalAttack = 0;
			PhysicalDefense = 30;
			MagicalDefense = 20;
			SkillPoints = 8;
		}

		if (playerName == "Tenkai Ishiyama") 
		{
			Level = 1;
			HealthPoints = 480;
			ManaPoints = 130;
			Strenght = 15;
			Agility = 8;
			Inteligence = 8;
			Luck = 8;
			PhysicalAttack = 45;
			MagicalAttack = 15;
			PhysicalDefense = 50;
			MagicalDefense = 35;
			SkillPoints = 9;
		}

		if (playerName == "Jin Katashi") 
		{
			Level = 1;
			HealthPoints = 280;
			ManaPoints = 180;
			Strenght = 8;
			Agility = 10;
			Inteligence = 15;
			Luck = 5;
			PhysicalAttack = 20;
			MagicalAttack = 40;
			PhysicalDefense = 20;
			MagicalDefense = 30;
			SkillPoints = 12;
		}
	}
}
