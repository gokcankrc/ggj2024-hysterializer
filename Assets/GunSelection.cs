using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunSelection : MonoBehaviour
{
	public int GunIndex;

	public void OnPointerClick()
	{
		if (ResourcesManager.I.GunLevel < GunIndex)
		{
			Debug.Log("cant buy the gn");
			return;
		}

		MapManager.I.SelectedGunID = GunIndex;
	}
}
