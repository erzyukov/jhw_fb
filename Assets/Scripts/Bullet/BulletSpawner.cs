using UnityEngine;

namespace Game
{
    public class BulletSpawner : ObjectPool
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField] private float _speed;

		private void Start()
		{
			Initialize(_prefab);
		}

		public void Spawn(Vector3 position, Vector3 direction)
		{
			if (TryGetObject(out GameObject bulletObject))
			{
				bulletObject.SetActive(true);
				bulletObject.transform.position = position;
				float zAngle = Vector3.SignedAngle(direction, Vector3.right, Vector3.forward);
				bulletObject.transform.localRotation = Quaternion.Euler(0, 0, -zAngle);

				Bullet bullet = bulletObject.GetComponent<Bullet>();
				bullet.Initialize(direction * _speed);
			}
		}
	}
}
