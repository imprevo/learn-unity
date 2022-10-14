namespace LearnUnity.TopDownMovementWithStateMachine
{
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private TextMesh hpLabel;
        [SerializeField]
        private int hp = 3;

        public void Start()
        {
            hpLabel.text = hp.ToString();
        }

        public void TakeDamage()
        {
            hp--;
            hpLabel.text = hp.ToString();

            if (hp < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
