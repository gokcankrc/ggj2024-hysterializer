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
	[SerializeField] Color DisabledAndSelectedColor;
	[SerializeField] Color PressingColor;
	public int CurrentResource => LevelResourcesManager.I.matCurrent[index];
	public bool HasResource = true;
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
		if (!isSelected)
			Select();
		else
			Deselect();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (HasResource)
			SetColor(PressingColor);
	}

	public void Select()
	{
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
		var current = CurrentResource;
		HasResource = current > 0;

		text.text = current.ToString();

		if (!HasResource)
			SetColor(DisabledColor);
		else if (isSelected)
			SetColor(SelectedColor);
		else
			SetColor(EnabledColor);
		if (!HasResource && isSelected)
			SetColor(DisabledAndSelectedColor);
	}

	private void SetColor(Color c)
	{
		image.color = c;
	}
}
