using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatSelectionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] public Mat Mat;
	[SerializeField] Image image;
	[SerializeField] Color EnabledColor;
	[SerializeField] Color SelectedColor;
	[SerializeField] Color DisabledColor;
	[SerializeField] Color PressingColor;
	public bool CanBeClicked = true;
	public bool isSelected = true;
	public MatData MatData;

	private void Start()
	{
		RefreshVisuals();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (CanBeClicked)
			Select();
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
		RefreshVisuals();
	}

	public void Deselect()
	{
		isSelected = false;
		RefreshVisuals();
	}
	public void AvailableUp()
	{
		throw new NotImplementedException();
	}

	public void AvailableDown()
	{
		throw new NotImplementedException();
	}

	public void RefreshVisuals()
	{
		if (!CanBeClicked)
			SetColor(DisabledColor);
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
