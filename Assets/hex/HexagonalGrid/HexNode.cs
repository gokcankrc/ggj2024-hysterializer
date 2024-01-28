using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HexNode : MonoBehaviour, IPointerClickHandler
{
	public HexVector hex;
	public Image Image;
	public NodeMatVisual currentNodeMatVisual;
	public MatSelectionButton currentAttachedMatButton;
	public int CurrentAttachedIndex = -1;
	public AudioClip audioClip;

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		MatSelectionManager.I.HexNodeHasBeenSelected(this, CurrentAttachedIndex);
	}

	public void AttachMat(MatSelectionButton selectedMatButton)
	{
		if (currentNodeMatVisual != null)
		{
			Debug.LogError("HexNode deteched mat internally. Should not happen.");
			DetachMat();
		}
		currentAttachedMatButton = selectedMatButton;
		currentNodeMatVisual = Instantiate(selectedMatButton.MatData.NodeMatVisual, transform.position, Quaternion.identity, transform);
		CurrentAttachedIndex = selectedMatButton.MatData.Index;
		SoundManager.Play(audioClip);

		currentAttachedMatButton.AvailableDown();
	}

	public void DetachMat()
	{
		if (currentNodeMatVisual == null)
			return;
		currentAttachedMatButton.AvailableUp();
		Destroy(currentNodeMatVisual.gameObject);

		currentAttachedMatButton = null;
		currentNodeMatVisual = null;
		CurrentAttachedIndex = -1;
	}
}
