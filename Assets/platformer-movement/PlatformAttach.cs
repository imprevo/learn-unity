namespace LearnUnity.PlatformerMovement
{
    using UnityEngine;

    public class PlatformAttach : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (ShouldBeAttached(other.gameObject))
            {
                other.transform.SetParent(transform);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (ShouldBeAttached(other.gameObject))
            {
                other.transform.SetParent(null);
            }
        }

        private bool ShouldBeAttached(GameObject other)
        {
            return other.GetComponent<Player>() != null;
        }
    }
}
