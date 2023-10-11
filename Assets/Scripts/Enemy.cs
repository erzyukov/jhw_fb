using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private int _rewardAmount;

		public event UnityAction<Enemy, int> Killed;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.TryGetComponent(out Bullet bullet))
				Killed?.Invoke(this, _rewardAmount);

			gameObject.SetActive(false);
		}

		public void Unsubscribe() =>
			Killed = null;
	}
}
