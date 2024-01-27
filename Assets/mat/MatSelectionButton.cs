using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatSelectionButton : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] Image image;

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("clicked");
	}
}
