using System.Collections;
using UnityEngine;

namespace Game
{
	public class EnemySpawner : ObjectPool
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField] private float _yPosition;
		[SerializeField] private float _startSpawnDelay;
		[SerializeField] private float _spawnDelay;
		[SerializeField] private float _spawnSpread;

		private bool _isWorking;

		private void Start()
		{
			Initialize(_prefab);
			_isWorking = true;
			StartCoroutine(StartSpawn());
		}

		private IEnumerator StartSpawn()
		{
			yield return new WaitForSeconds(_startSpawnDelay);

			while (_isWorking)
			{
				Spawn();

				float spread = Random.value * _spawnSpread;
				yield return new WaitForSeconds(_spawnDelay + spread);
			}
		}

		private void Spawn()
		{
			if (TryGetObject(out GameObject enemy))
			{
				enemy.transform.position = new Vector3(transform.position.x, _yPosition, transform.position.z);
				enemy.SetActive(true);
			}

			DisableObjectAbroadScreen();
		}
	}
}