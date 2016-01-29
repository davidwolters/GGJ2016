using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player_NetworkSetup : NetworkBehaviour 
{

	[SerializeField] private Behaviour[] componentsToDisable;

	void Start () 
	{
		if (!isLocalPlayer)
		{
			for (int i = 0; i < componentsToDisable.Length; i++)
			{
				componentsToDisable [i].enabled = false;
			}
		}

	}

}
