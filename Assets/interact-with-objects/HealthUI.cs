namespace LearnUnity.InteractWithObjects
{
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TMP_Text))]
    public class HealthUI : MonoBehaviour
    {
        [SerializeField]
        private Health health;

        private TMP_Text label;

        public void Start()
        {
            label = GetComponent<TMP_Text>();
            UpdateHealth(0);
        }

        public void OnEnable()
        {
            health.OnChange += UpdateHealth;
        }

        public void OnDisable()
        {
            health.OnChange -= UpdateHealth;
        }

        public void UpdateHealth(int diff)
        {
            label.text = "HP: " + health.CurrentHealth;
        }
    }
}
