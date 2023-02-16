namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Interactor : MonoBehaviour
    {
        [SerializeField]
        private GameObject actor;

        public void OnTriggerEnter(Collider other)
        {
            var item = other.gameObject.GetComponent<IInteractible>();
            item?.Use(actor);
        }
    }
}
