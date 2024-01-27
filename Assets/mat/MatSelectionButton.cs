using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatSelectionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public MatData MatData;
	[SerializeField] public TMP_Text text;
	[SerializeField] Image image;
	[SerializeField] Color EnabledColor;
	[SerializeField] Color SelectedColor;
	[SerializeField] Color DisabledColor;
	[SerializeField] Color PressingColor;
	public bool CanBeClicked = true;
	public bool isSelected = false;

	public int index => MatData.Index;

	private void Awake()
	{
		LevelResourcesManager.ResourcesRefresh += RefreshState;
	}

	private void Start()
	{
		isSelected = false;
		RefreshState();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (CanBeClicked)
		{
			if (!isSelected)
				Select();
			else
				Deselect();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (CanBeClicked)
			SetColor(PressingColor);
	}

	public void Select()
	{
		Debug.Log("clicked");
		isSelected = true;
		MatSelectionManager.I.MatHasBeenSelected(this);
		RefreshState();
	}

	public void Deselect()
	{
		if (this != MatSelectionManager.I.CurrentlySelectedMatButton) return;

		MatSelectionManager.I.CurrentlySelectedMatButton = null;
		isSelected = false;
		RefreshState();
	}

	public void AvailableUp()
	{
		LevelResourcesManager.I.matCurrent[index] += 1;
		RefreshState();
	}

	public void AvailableDown()
	{
		LevelResourcesManager.I.matCurrent[index] -= 1;
		RefreshState();
	}

	public void RefreshState()
	{
		var current = LevelResourcesManager.I.matCurrent[index];
		CanBeClicked = current > 0;

		text.text = current.ToString();

		if (!CanBeClicked)
		{
			SetColor(DisabledColor);
			Deselect();
		}
		else if (isSelected)
			SetColor(SelectedColor);
		else
			SetColor(EnabledColor);
	}

	private void SetColor(Color c)
	{
		image.color = c;
	}
}
