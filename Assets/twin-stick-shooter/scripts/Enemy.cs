namespace LearnUnity.TwinStickShooter
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;

        public void Start()
        {
            StartCoroutine(AttackLoop());
        }

        public void OnDestroy()
        {
            StopAllCoroutines();
        }

        public IEnumerator AttackLoop()
        {
            var wait = new WaitForSeconds(0.5f);
            while (true)
            {
                yield return wait;
                weapon.Attack();
            }
        }
    }
}
