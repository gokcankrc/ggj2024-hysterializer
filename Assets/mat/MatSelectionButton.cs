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
	[SerializeField] AudioClip DeselectClip;
	public int CurrentResource => LevelManager.I.matCurrent[index];
	public bool HasResource = true;
	public bool isSelected = false;

	public int index => MatData.Index;

	private void Awake()
	{
		LevelManager.ResourcesRefresh += RefreshState;
	}

	private void Start()
	{
		isSelected = false;
		RefreshState();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		transform.localScale = Vector3.one * 1.0f;
		if (!isSelected)
		{ Select(); }
		else
		{
			SoundManager.Play(DeselectClip);
			Deselect();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		transform.localScale = Vector3.one * 0.93f;
		if (HasResource)
			SetColor(PressingColor);
	}

	public void Select()
	{
		isSelected = true;
		MatSelectionManager.I.MatHasBeenSelected(this);
		transform.localScale = Vector3.one * 1.2f;
		RefreshState();
	}

	public void Deselect()
	{
		if (this != MatSelectionManager.I.CurrentlySelectedMatButton) return;

		MatSelectionManager.I.CurrentlySelectedMatButton = null;
		isSelected = false;
		transform.localScale = Vector3.one * 1.0f;
		RefreshState();
	}

	public void AvailableUp()
	{
		LevelManager.I.matCurrent[index] += 1;
		RefreshState();
	}

	public void AvailableDown()
	{
		LevelManager.I.matCurrent[index] -= 1;
		RefreshState();
	}

	public void RefreshState()
	{
		var current = CurrentResource;
		HasResource = current > 0;

		text.text = current.ToString() + "x";

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
