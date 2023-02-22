namespace LearnUnity.InteractWithObjects
{
    using UnityEngine;

    public class InteractWithMessage : Interactible
    {
        [SerializeField]
        private Message message;

        [SerializeField]
        private float delay = 1f;

        private int count = 1;

        public override void Interact(GameObject actor)
        {
            message.ShowMessage("Showed times: " + count, delay);
            count++;
        }
    }
}
