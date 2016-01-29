using UnityEngine;
using System.Collections;

public static class Util 
{
	public static Vector3 Scale (Vector3 scaleAmount, Vector3 originalScale)
	{
		return originalScale += scaleAmount;
	}
}
