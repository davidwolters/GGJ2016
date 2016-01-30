using UnityEngine;
using System.Collections;

public static class Player_Controls
{
	public static KeyCode forward (PlayerType player)
	{
		return (player == PlayerType.PLAYER1) ? KeyCode.W : KeyCode.DownArrow;
	}

	public static KeyCode backward (PlayerType player)
	{
		return (player == PlayerType.PLAYER1) ? KeyCode.S : KeyCode.UpArrow;
	}

	public static KeyCode left (PlayerType player)
	{
		return (player == PlayerType.PLAYER1) ? KeyCode.A : KeyCode.LeftArrow;
	}

	public static KeyCode right (PlayerType player)
	{
		return (player == PlayerType.PLAYER1) ? KeyCode.D : KeyCode.RightArrow;
	}

	public static KeyCode shoot (PlayerType player)
	{
		return (player == PlayerType.PLAYER1) ? KeyCode.F : KeyCode.RightAlt;
	}

	public static KeyCode pickUpSheep (PlayerType player)
	{
		return (player == PlayerType.PLAYER1) ? KeyCode.G : KeyCode.Period;
	}



}
