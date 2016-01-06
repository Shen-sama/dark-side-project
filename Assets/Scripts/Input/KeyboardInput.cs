using UnityEngine;
using System.Collections;

public class KeyboardInput : IPlayerInput 
{
	public Vector2 Axis
	{
		get
		{
			return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		}
	}

	public bool ChangeToNextCharacter
	{
		get
		{
			return Input.GetKeyDown(KeyCode.E);
		}
	}

	public bool ChangeToPreviousCharacter
	{
		get
		{
			return Input.GetKeyDown(KeyCode.Q);
		}
	}

	public bool Start
	{
		get
		{
			return Input.GetKeyDown(KeyCode.Return);
		}
	}

	public bool Submit
	{
		get
		{
			return Input.GetKeyDown(KeyCode.Z);
		}
	}

	public bool Cancel
	{
		get
		{
			return Input.GetKeyDown(KeyCode.X);
		}
	}
}
