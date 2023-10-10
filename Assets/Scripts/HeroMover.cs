using UnityEngine;

namespace Game
{
	[RequireComponent (typeof (Rigidbody2D))]
	public class HeroMover : MonoBehaviour
	{
		[SerializeField] private Vector3 _startPosition;
		[SerializeField] private float _speed;
		[SerializeField] private float _tapForce;
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private float _maxRotationZ;
		[SerializeField] private float _minRotationZ;

		private Rigidbody2D _rigidbody;
		private Quaternion _maxRotation;
		private Quaternion _minRotation;

		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody2D>();

			_maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
			_minRotation = Quaternion.Euler(0, 0, _minRotationZ);
			
			ResetHero();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_rigidbody.velocity = new Vector2(_speed, 0);
				transform.rotation = _maxRotation;
				_rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
			}

			transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
		}

		public void ResetHero()
		{
			transform.position = _startPosition;
			transform.rotation = Quaternion.identity;
			_rigidbody.velocity = Vector2.zero;
		}
	}
}