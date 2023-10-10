using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class ObjectPool : MonoBehaviour
    {
		[SerializeField] private GameObject _container;
		[SerializeField] private int _capacity;

		private Camera _camera;
		private List<GameObject> _pool = new List<GameObject>();

		protected void Initialize(GameObject prefab)
		{
			_camera = Camera.main;

            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(prefab, _container.transform);
				spawned.SetActive(false);

				_pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out GameObject result)
		{
			result = _pool.FirstOrDefault(item => item.activeSelf == false);

			return result != null;
		}

		protected void DisableObjectAbroadScreen()
		{
			Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

			_pool
				.Where(item => item.activeSelf == true && item.transform.position.x < disablePoint.x)
				.ToList()
				.ForEach(item => item.SetActive(false));
		}

		public void ResetPool()
		{
			_pool.ForEach(item => item.SetActive(false));
		}
    }
}
