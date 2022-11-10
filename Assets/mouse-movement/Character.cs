namespace LearnUnity.MouseMovement
{
    using UnityEngine;
    using UnityEngine.AI;

    public class Character : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent agent;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetTarget();
            }
        }

        private void SetTarget()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.tag == "Terrain")
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
