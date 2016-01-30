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

	public static void SetCarryingSheep (bool carrying, PlayerType player)
	{
		switch (player)
		{
		case PlayerType.PLAYER1:
			Player_CarrySheep.carryingSheep1 = carrying;
			break;
		case PlayerType.PLAYER2:
			Player_CarrySheep.carryingSheep2 = carrying;
			break;
		}
	}

	public static bool CarryingSheep (PlayerType player)
	{
		switch (player)
		{
		case PlayerType.PLAYER1:
			return Player_CarrySheep.carryingSheep1;
			break;
		case PlayerType.PLAYER2:
			return Player_CarrySheep.carryingSheep2;
			break;
		}
		return false;
	}
}
