namespace LearnUnity.TopDownAction
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Healthbar : MonoBehaviour
    {
        [SerializeField]
        private Stats stats;

        private Slider slider;

        public void Start()
        {
            slider = GetComponent<Slider>();
            UpdateHealth();
        }

        public void OnEnable()
        {
            stats.OnChange += UpdateHealth;
        }

        public void OnDisable()
        {
            stats.OnChange -= UpdateHealth;
        }

        private void UpdateHealth()
        {
            slider.maxValue = stats.MaxHealth;
            slider.value = stats.Health;
        }
    }
}
