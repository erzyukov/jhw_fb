using UnityEngine;
using UnityEngine.Events;

namespace Game
{
	[RequireComponent (typeof (HeroMover), typeof(BulletSpawner))]
    public class Hero : MonoBehaviour
    {
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private Transform _shootDirectionPoint;

		private HeroMover _heroMover;
		private BulletSpawner _bulletSpawner;

		public event UnityAction Died;

		private void Start ()
		{
			_heroMover = GetComponent<HeroMover>();
			_bulletSpawner = GetComponent<BulletSpawner>();
		}

		private void Update ()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector3 direction = (_shootDirectionPoint.position - _shootPoint.position).normalized;
				_bulletSpawner.Spawn(_shootPoint.position, direction);
			}
		}

		public void Die()
		{
			Died.Invoke();
		}
	}
}
