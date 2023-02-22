namespace LearnUnity.TopDownAction
{
    using TMPro;
    using UnityEngine;

    public class WaveUI : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner spawner;

        private TMP_Text label;

        public void Start()
        {
            label = GetComponent<TMP_Text>();
            UpdateLabel();
        }

        public void OnEnable()
        {
            spawner.OnChange += UpdateLabel;
        }

        public void OnDisable()
        {
            spawner.OnChange -= UpdateLabel;
        }

        private void UpdateLabel()
        {
            var wave = spawner.Wave + 1;
            label.text = "Wave: " + wave;
        }
    }
}
