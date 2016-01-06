using UnityEngine;
using System.Collections;

public interface IPlayerInput 
{
	Vector2 Axis { get; }
	bool ChangeToNextCharacter { get; }
	bool ChangeToPreviousCharacter { get; }
	bool Start { get; }
	bool Submit { get; }
	bool Cancel { get; }
}
