using System.Collections;
using UnityEngine;

namespace Game
{
	public class EnemySpawner : ObjectPool
	{
		[SerializeField] private LevelScore _levelScore;
		[SerializeField] private BulletSpawner _bulletSpawner;
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
			if (TryGetObject(out GameObject enemyObject))
			{
				enemyObject.transform.position = new Vector3(transform.position.x, _yPosition, transform.position.z);

				Enemy enemy = enemyObject.GetComponent<Enemy>();
				enemy.Killed += OnEnemyKilled;
				enemy.Initialize(_bulletSpawner);

				enemyObject.SetActive(true);
			}

			DisableObjectAbroadScreen();
		}

		private void OnEnemyKilled(Enemy enemy, int score)
		{
			enemy.Unsubscribe();
			_levelScore.AddScore(score);
		}
	}
}