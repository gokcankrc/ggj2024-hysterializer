using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewButton : MonoBehaviour
{

	public void OnClick()
	{
		var map = MapManager.I.SelectedMap;
		if (map == null) return;
        if (!map.IsUnlocked) return;

		// Start map
		LevelManager.I.EnterInterview(map);
	}
}
