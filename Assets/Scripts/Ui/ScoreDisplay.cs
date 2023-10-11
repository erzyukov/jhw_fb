using UnityEngine;
using TMPro;

namespace Game
{
    public class ScoreDisplay : MonoBehaviour
    {
		[SerializeField] private LevelScore _levelScore;
		[SerializeField] private TextMeshProUGUI _scoreField;

		private void Start()
		{
			_levelScore.ScoreChanged += OnScoreChanged;
		}

		private void OnDestroy()
		{
			_levelScore.ScoreChanged -= OnScoreChanged;
		}

		private void OnScoreChanged(int amount)
		{
			_scoreField.text = amount.ToString();
		}
	}
}