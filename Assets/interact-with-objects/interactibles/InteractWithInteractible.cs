namespace LearnUnity.InteractWithObjects
{
    using System.Collections.Generic;
    using UnityEngine;

    public class InteractWithInteractible : Interactible
    {
        [SerializeField]
        private List<Interactible> objects;

        private bool shouldActivate = false;

        public override void Interact(GameObject actor)
        {
            foreach (var item in objects)
            {
                item.canInteract = shouldActivate;
            }
            shouldActivate = !shouldActivate;
        }
    }
}
