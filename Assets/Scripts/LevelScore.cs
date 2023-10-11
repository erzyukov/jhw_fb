using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class LevelScore : MonoBehaviour
    {
		private int _score;

		public int Score => _score;
		public event UnityAction<int> ScoreChanged;

		public void AddScore(int amount)
		{
			_score += amount;
			ScoreChanged?.Invoke(_score);
		}
    }
}
