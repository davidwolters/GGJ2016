using UnityEngine;
using System.Collections;

public static class Util 
{
	public static Vector3 Scale (Vector3 scaleAmount, Vector3 originalScale)
	{
		return originalScale += scaleAmount;
	}

	public static bool Shooting (PlayerType player)
	{
		if (player == PlayerType.PLAYER1)
		{
			return Player_Webshoot.shooting1;
		} else
		{
			return Player_Webshoot.shooting2;	
		}
	}
}
