namespace LearnUnity.PointAndClick
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AI;

    public class Player : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        private LayerMask groundLayers;
        [SerializeField]
        private CursorController cursor;

        private Coroutine co;

        private RaycastHit mouseHit;

        public void Update()
        {
            LookForTarget();

            if (Input.GetMouseButtonDown(0))
            {
                SetTarget();
            }
        }

        private void LookForTarget()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out mouseHit, groundLayers))
            {
                Debug.DrawLine(ray.origin, mouseHit.point, Color.green);
                cursor.SetHover();
            }
            else
            {
                cursor.SetDefault();
            }
        }

        private void SetTarget()
        {
            if (mouseHit.collider == null)
            {
                return;
            }

            if (co != null)
            {
                StopCoroutine(co);
            }

            var interactible = mouseHit.collider.gameObject.GetComponent<Interactible>();

            if (interactible)
            {
                agent.SetDestination(mouseHit.point);
                co = StartCoroutine(InteractWhenReachDestination(interactible));
            }
            else
            {
                agent.SetDestination(mouseHit.point);
            }
        }

        private IEnumerator InteractWhenReachDestination(Interactible interactible)
        {
            yield return new WaitUntil(IsReachDestination);
            // TODO: rotate agent
            if (CanInteract(interactible))
            {
                interactible.Interact();
                var portal = interactible.gameObject.GetComponent<Portal>();
                if (portal != null)
                {
                    agent.Warp(portal.target.position);
                }
            }
        }

        private bool IsReachDestination()
        {
            return !agent.pathPending
                && agent.remainingDistance <= agent.stoppingDistance
                && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
        }

        private bool CanInteract(Interactible interactible)
        {
            // TODO: check distance to interactible
            return interactible != null && agent.remainingDistance < 1f;
        }
    }
}
