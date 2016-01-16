using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuInGameManager : MonoBehaviour {

	private GUIControl _control;
	private PlayerManager _player;

	public GameObject Arrows;
	public GameObject MenuButtons;
	public GameObject PreviewOfCharacters;

	public Button[] MenuInGameButtons;

	public int MenuInGameNumberOfButtons;
	public int PreviewCharacterMenuNumberOfStageOfSlots;

	public int MenuInGameIndex;
	public int PreviewCharacterMenuIndex;

	// Use this for initialization
	void Start () 
	{
		_control = FindObjectOfType (typeof(GUIControl)) as GUIControl;
		_player = FindObjectOfType (typeof(PlayerManager)) as PlayerManager;

		MenuInGameButtons = GetComponentsInChildren<Button> ();

		MenuInGameNumberOfButtons = 9;
		PreviewCharacterMenuNumberOfStageOfSlots = 4;

		MenuInGameIndex = 0;
		PreviewCharacterMenuIndex = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var pointer = new PointerEventData(EventSystem.current);

		MenuInGameIndex = _control.SimulateUpDownOnGUI (0, _player.SelectedCharacter.Input, "Vertical", MenuInGameNumberOfButtons, 6, MenuInGameIndex);
		PreviewCharacterMenuIndex = _control.SimulateUpDownOnGUI (1, _player.SelectedCharacter.Input, "Horizontal", PreviewCharacterMenuNumberOfStageOfSlots, 1, PreviewCharacterMenuIndex);
		_control.ButtonControl (pointer, _player.SelectedCharacter.Input, MenuInGameButtons, MenuInGameIndex);

		ShowPreviewOfCharacters ();
		PreviousNextControl (pointer);
	}

	public void ShowPreviewOfCharacters()
	{
		int i = 1;

		var Preview1UpInfo = PreviewOfCharacters.transform.GetChild (0).GetChild (0);
		var Preview1DownInfo = PreviewOfCharacters.transform.GetChild (0).GetChild (1);

		var Preview2UpInfo = PreviewOfCharacters.transform.GetChild (1).GetChild (0);
		var Preview2DownInfo = PreviewOfCharacters.transform.GetChild (1).GetChild (1);

		var Preview3UpInfo = PreviewOfCharacters.transform.GetChild (2).GetChild (0);
		var Preview3DownInfo = PreviewOfCharacters.transform.GetChild (2).GetChild (1);

		int IndexSlot1 = i * (PreviewCharacterMenuIndex + 1);
		int IndexSlot2 = (i + 1) * (PreviewCharacterMenuIndex + 1);
		int IndexSlot3 = (i + 2) * (PreviewCharacterMenuIndex + 1);

		if (IndexSlot3 - 1 < _player.playableCharacters.Count) 
		{
			Preview1UpInfo.GetChild (0).GetComponent<Text> ().text = "Lv. " + _player.playableCharacters [(IndexSlot1) - 1].Stats.Level;
			Preview1UpInfo.GetChild (2).GetComponent<Text> ().text = _player.playableCharacters [(IndexSlot1) - 1].Name;
			Preview1DownInfo.GetChild (5).GetComponent<Text> ().text = _player.playableCharacters [(IndexSlot1) - 1].Stats.SkillPoints + " pts";

			Preview2UpInfo.GetChild (0).GetComponent<Text> ().text = "Lv. " + _player.playableCharacters [(IndexSlot2) - 1].Stats.Level;
			Preview2UpInfo.GetChild (2).GetComponent<Text> ().text = _player.playableCharacters [(IndexSlot2) - 1].Name;
			Preview2DownInfo.GetChild (5).GetComponent<Text> ().text = _player.playableCharacters [(IndexSlot2) - 1].Stats.SkillPoints + " pts";

			Preview3UpInfo.GetChild (0).GetComponent<Text> ().text = "Lv. " + _player.playableCharacters [(IndexSlot3) - 1].Stats.Level;
			Preview3UpInfo.GetChild (2).GetComponent<Text> ().text = _player.playableCharacters [(IndexSlot3) - 1].Name;
			Preview3DownInfo.GetChild (5).GetComponent<Text> ().text = _player.playableCharacters [(IndexSlot3) - 1].Stats.SkillPoints + " pts";
		}
		else 
		{
			Preview1UpInfo.GetChild (0).GetComponent<Text> ().text = "Lv. ";
			Preview1UpInfo.GetChild (2).GetComponent<Text> ().text = "";
			Preview1DownInfo.GetChild (5).GetComponent<Text> ().text = " pts";

			Preview2UpInfo.GetChild (0).GetComponent<Text> ().text = "Lv. ";
			Preview2UpInfo.GetChild (2).GetComponent<Text> ().text = "";
			Preview2DownInfo.GetChild (5).GetComponent<Text> ().text = " pts";

			Preview3UpInfo.GetChild (0).GetComponent<Text> ().text = "Lv. ";
			Preview3UpInfo.GetChild (2).GetComponent<Text> ().text = "";
			Preview3DownInfo.GetChild (5).GetComponent<Text> ().text = " pts";
		}
	}

	public void PreviousNextControl(PointerEventData p)
	{
		VisibleArrows ();

		Button previous = Arrows.transform.GetChild (0).GetComponent<Button> ();
		Button next = Arrows.transform.GetChild (1).GetComponent<Button> ();

		if (_player.SelectedCharacter.Input.Axis.x > 0 && PreviewCharacterMenuIndex < 3) 
		{
			ExecuteEvents.Execute(next.gameObject, p, ExecuteEvents.submitHandler);
		}

		if (_player.SelectedCharacter.Input.Axis.x < 0 && PreviewCharacterMenuIndex > 0) 
		{
			ExecuteEvents.Execute(previous.gameObject, p, ExecuteEvents.submitHandler);
		}
	}

	void VisibleArrows()
	{
		if (PreviewCharacterMenuIndex == 0) 
		{
			Arrows.transform.GetChild (0).gameObject.SetActive (false);
		} 
		else 
		{
			Arrows.transform.GetChild (0).gameObject.SetActive (true);
		}

		if (PreviewCharacterMenuIndex == 3) 
		{
			Arrows.transform.GetChild (1).gameObject.SetActive (false);
		} 
		else 
		{
			Arrows.transform.GetChild (1).gameObject.SetActive (true);
		}
	}
}
