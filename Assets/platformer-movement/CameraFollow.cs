namespace LearnUnity.PlatformerMovement
{
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        public void LateUpdate()
        {
            if (target)
            {
                Follow();
            }
        }

        private void Follow()
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
