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

		Shen = new Player ("Shen Shi Harzgard", new KeyboardInput());
		TK = new Player ("Tenkai Ishiyama", new KeyboardInput());
		Jin = new Player ("Jin Katashi", new KeyboardInput());

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

		if (SelectedCharacter.Input.ChangeToNextCharacter) 
		{
			SelectedCharacterIndex++;
			if (SelectedCharacterIndex >= playableCharacters.Count)
			{
				SelectedCharacterIndex = 0;
			}
		}

		if (SelectedCharacter.Input.ChangeToPreviousCharacter) 
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
