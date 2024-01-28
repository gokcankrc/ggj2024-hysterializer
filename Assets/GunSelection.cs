using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GunSelection : MonoBehaviour
{
	public int GunIndex;
	public bool Selected;
	public Image image;
	public Color EnabledColor;
	public Color DisabledColor;
	public Color SelectedColor;

	private void Start()
	{
		RefreshVisuals();
		GameManager.I.ScreenTransitionDone += RefreshVisuals;
	}

	public void OnPointerClick()
	{
		if (ResourcesManager.I.GunLevel < GunIndex)
		{
			Debug.Log("cant buy the gn");
			return;
		}

		if (MapManager.I.CurrentSelectedGun != null)
		{
			MapManager.I.CurrentSelectedGun.Selected = false;
			MapManager.I.CurrentSelectedGun.RefreshVisuals();
		}

		MapManager.I.SelectedGunID = GunIndex;
		MapManager.I.CurrentSelectedGun = this;

		Selected = true;
		RefreshVisuals();
	}

	public void RefreshVisuals()
	{
		if (ResourcesManager.I.GunLevel < GunIndex)
		{
			image.color = DisabledColor;
		}
		else
		{
			if (!Selected)
			{
				image.color = EnabledColor;
			}
			else
			{
				image.color = SelectedColor;
			}
		}
	}
}
