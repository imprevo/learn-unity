namespace LearnUnity.TwinStickShooter
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private NavMeshAgent agent;

        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            StartCoroutine(CalculateLoop());
        }

        public void OnDestroy()
        {
            StopAllCoroutines();
        }

        public IEnumerator CalculateLoop()
        {
            var wait = new WaitForSeconds(0.5f);
            while (target)
            {
                agent.SetDestination(target.position);
                yield return wait;
            }
        }
    }
}
