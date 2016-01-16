using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GUIControl : MonoBehaviour {

	public bool[] Unlockers;

	// Use this for initialization
	void Awake () 
	{
		Unlockers = new bool[4];

		for (int u = 0; u < Unlockers.Length; u++) 
		{
			Unlockers [u] = true;
		}
	}

	public int SimulateUpDownOnGUI(int arrayIndex, IPlayerInput input, string direction, 
		int numberButtons, int linhas, int i)
	{
		if (direction == "Vertical")
		{
			if (input.Axis.y < 0 && Unlockers[arrayIndex])
			{
				int lastIndex = i;
				i++;

				if (i == numberButtons)
				{
					i = lastIndex;
				}

				Unlockers[arrayIndex] = false;
			}

			if (input.Axis.y > 0 && Unlockers[arrayIndex])
			{
				int lastIndex = i;
				i--;

				if (i < 0)
				{
					i = lastIndex;
				}

				Unlockers[arrayIndex] = false;
			}

			if (input.Axis.y == 0 && !Unlockers[arrayIndex])
			{
				Unlockers[arrayIndex] = true;
			}
		}

		if (direction == "Horizontal")
		{
			if (input.Axis.x < 0 && Unlockers[arrayIndex])
			{
				int lastIndex = i;
				i--;

				if (i < 0)
				{
					i = lastIndex;

				}
				Debug.Log (i);
				Unlockers[arrayIndex] = false;
			}

			if (input.Axis.x > 0 && Unlockers[arrayIndex])
			{
				int lastIndex = i;
				i++;

				if (i == numberButtons)
				{
					i = lastIndex;

				}
				Debug.Log (i);
				Unlockers[arrayIndex] = false;
			}

			if (input.Axis.x == 0 && !Unlockers[arrayIndex])
			{
				Unlockers[arrayIndex] = true;
			}
		}

		if (direction == "Both")
		{
			int buttonsPorLinha = numberButtons / linhas;

			if (input.Axis.x < 0 && Unlockers[arrayIndex])
			{
				int lastIndex = i;
				i--;

				if (i < 0)
				{
					i = lastIndex;
				}

				Unlockers[arrayIndex] = false;
			}

			if (input.Axis.x < 0 && Unlockers[arrayIndex])
			{
				i++;

				if (i == numberButtons)
				{
					i = numberButtons - 1;
				}

				Unlockers[arrayIndex] = false;
			}

			if (input.Axis.y > 0 && Unlockers[arrayIndex])
			{
				int lastIndex = i;
				i -= buttonsPorLinha;

				if (i < 0)
				{
					i = lastIndex;
				}

				Unlockers[arrayIndex] = false;
			}

			if (input.Axis.y < 0 && Unlockers[arrayIndex])
			{
				int lastIndex = i;
				i += buttonsPorLinha;
	
				if (i >= numberButtons)
				{
					i = lastIndex;
				}

				Unlockers[arrayIndex] = false;
			}

			if ((input.Axis.x == 0 && input.Axis.y == 0) && !Unlockers[arrayIndex])
			{
				Unlockers[arrayIndex] = true;
			}
		}

		return i;
    }

	public void ButtonControl(PointerEventData pointer, IPlayerInput input, Button[] buttons, int i)
	{
		ExecuteEvents.Execute(buttons[i].gameObject, pointer, ExecuteEvents.pointerEnterHandler);

		foreach (Button b in buttons) 
		{
			if (b != buttons [i]) 
			{
				ExecuteEvents.Execute(b.gameObject, pointer, ExecuteEvents.pointerExitHandler);
			}
		}

		if (input.Submit)
		{
			ExecuteEvents.Execute(buttons[i].gameObject, pointer, ExecuteEvents.submitHandler);
		}
	}
}
