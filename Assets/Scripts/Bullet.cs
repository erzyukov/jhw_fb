using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
		private Vector3 _speed;

		private void Update()
		{
			transform.Translate(_speed * Time.deltaTime, transform.parent);
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			gameObject.SetActive(false);
		}

		public void Initialize(Vector3 speed)
		{
			_speed = speed;
		}
	}
}