using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private Transform _shootDirectionPoint;

		[SerializeField] private int _rewardAmount;
		[SerializeField] private float _shootingDelay;
		[SerializeField] private float _shootingStartDelay;

		private BulletSpawner _bulletSpawner;
		private bool _canShoot;

		public event UnityAction<Enemy, int> Killed;

		private void OnEnable()
		{
			_canShoot = true;
			StartCoroutine(StartShooting());
		}

		private void OnDisable()
		{
			_canShoot = false;
			StopCoroutine(StartShooting());
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.TryGetComponent(out Bullet bullet))
				Killed?.Invoke(this, _rewardAmount);

			gameObject.SetActive(false);
		}

		public void Initialize(BulletSpawner bulletSpawner)
		{
			_bulletSpawner = bulletSpawner;
		}

		public void Unsubscribe() =>
			Killed = null;

		private IEnumerator StartShooting()
		{
			yield return new WaitForSeconds(_shootingStartDelay);
			
			WaitForSeconds wait = new WaitForSeconds(_shootingDelay);

			while (_canShoot)
			{
				Vector3 direction = (_shootDirectionPoint.position - _shootPoint.position).normalized;
				_bulletSpawner.Spawn(_shootPoint.position, direction);

				yield return wait;
			}
		}
	}
}
