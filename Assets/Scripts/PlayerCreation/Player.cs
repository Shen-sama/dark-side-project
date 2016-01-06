using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player 
{
	//Input
	public IPlayerInput Input;

	//Info
	public string Name;
	public Sprite Portrait;

	//Status
	public PlayerStats Stats;

	//Skills

	//Itens

	public Player(string name, IPlayerInput input)
	{
		Name = name;

		Stats = new PlayerStats ();
		Stats.InitialStats (Name);

		Portrait = Resources.Load<Sprite> ("Playable Characters/" + name);

		Input = input;
	}

	public void UpdatingHPMP()
	{
		Stats.HealthPoints += (Stats.Strenght * 19);
		Stats.ManaPoints += (Stats.Inteligence * 9);
	}
}
