namespace LearnUnity.InteractWithObjects
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Interactible : MonoBehaviour
    {
        [SerializeField]
        public bool canInteract = true;

        public abstract void Interact(GameObject actor);
    }
}
