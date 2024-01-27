using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NullNode : HexNode
{
	private void Awake()
	{
		Image.enabled = false;
	}

	public void OnPointerClick(PointerEventData eventData) { }
}