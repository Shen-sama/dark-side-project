using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	public Player Shen;
	public Player TK;
	public Player Jin;

	public List<Player> playableCharacters;
	public List<GameObject> playableCharactersModels;

	public GameObject SelectedCharacterModel;
	public Player SelectedCharacter;
	public int SelectedCharacterIndex;

	// Use this for initialization
	void Start () 
	{
		playableCharacters = new List<Player> ();

		Shen = new Player ("Shen Shi Harzgard", 1, 320, 100, 10, 15, 6, 12, 60, 0, 30, 20);
		TK = new Player ("Tenkai Ishiyama", 1, 480, 130, 15, 8, 8, 8, 45, 15, 50, 35);
		Jin = new Player ("Jin Katashi", 1, 280, 180, 8, 10, 15, 5, 20, 40, 20, 30);

		playableCharacters.Add (Shen);
		playableCharacters.Add (TK);
		playableCharacters.Add (Jin);

		foreach (Player p in playableCharacters) 
		{
			p.UpdatingHPMP();
		}

		SelectedCharacterIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		SelectedCharacter = playableCharacters [SelectedCharacterIndex];
		SelectedCharacterModel = playableCharactersModels [SelectedCharacterIndex];

		if (Input.GetKeyDown(KeyCode.E)) 
		{
			SelectedCharacterIndex++;
			if (SelectedCharacterIndex >= playableCharacters.Count)
			{
				SelectedCharacterIndex = 0;
			}
		}

		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			SelectedCharacterIndex--;
			if (SelectedCharacterIndex < 0)
			{
				SelectedCharacterIndex = playableCharacters.Count - 1;
			}
		}

		foreach (GameObject obj in playableCharactersModels) 
		{
			if (!(obj.Equals(SelectedCharacterModel)))
			{
				obj.GetComponent<MeshRenderer>().enabled = false;
			}
			else
			{
				obj.GetComponent<MeshRenderer>().enabled = true;
			}
		}
	}
}
