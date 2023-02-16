namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class HealthItem : MonoBehaviour, IInteractible
    {
        [SerializeField]
        private int health = 50;

        public void Use(GameObject actor)
        {
            var stats = actor.GetComponent<Stats>();
            if (stats)
            {
                stats.Heal(health);
                Destroy(gameObject);
            }
        }
    }
}
