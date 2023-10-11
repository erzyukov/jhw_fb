using UnityEngine;

namespace Game
{
	public class Enemy : MonoBehaviour, IDestuctable
	{
		public void DestroyObject()
		{
			gameObject.SetActive(false);
		}
	}
}
