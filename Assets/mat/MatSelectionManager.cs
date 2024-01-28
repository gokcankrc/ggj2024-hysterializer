using RegularDuck._Core.Helpers;
using System;
using UnityEngine;

public class MatSelectionManager : Singleton<MatSelectionManager>
{
	public MatSelectionButton CurrentlySelectedMatButton;
	public AudioClip Select;

	public void MatHasBeenSelected(MatSelectionButton matSelectionButton)
	{
		Deselect();

		CurrentlySelectedMatButton = matSelectionButton;
		SoundManager.Play(Select);
	}

	public void HexNodeHasBeenSelected(HexNode hexNode, int matIndex)
	{
		if (CurrentlySelectedMatButton == null) return;
		if (hexNode.CurrentAttachedIndex != CurrentlySelectedMatButton.index)
		{
			AttachMatToNode(hexNode, CurrentlySelectedMatButton);
		}
		else
		{
			hexNode.DetachMat();
		}
	}

	private void AttachMatToNode(HexNode hexNode, MatSelectionButton selection)
	{
		hexNode.DetachMat();
		if (selection.CurrentResource == 0) return;
		hexNode.AttachMat(selection);
	}

	public void Deselect()
	{
		if (CurrentlySelectedMatButton != null)
			CurrentlySelectedMatButton.Deselect();
		CurrentlySelectedMatButton = null;
	}
}
