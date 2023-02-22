namespace LearnUnity.InteractWithObjects
{
    using UnityEngine;

    public class InteractWithHealth : Interactible
    {
        [SerializeField]
        private int amount = 10;

        public override void Interact(GameObject actor)
        {
            var health = actor.GetComponent<Health>();
            health?.UpdateHealth(amount);
        }
    }
}
