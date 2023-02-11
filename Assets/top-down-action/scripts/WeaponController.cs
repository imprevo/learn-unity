namespace LearnUnity.TopDownAction
{
    using System.Collections;
    using UnityEngine;

    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectilePrefab;

        private float attackDelay = 1f;

        private Coroutine attackCoroutine;

        public void OnEnable()
        {
            attackCoroutine = StartCoroutine(AutoAttack());
        }

        public void OnDisable()
        {
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
        }

        private IEnumerator AutoAttack()
        {
            while (true)
            {
                yield return new WaitForSeconds(attackDelay);
                Attack();
            }
        }

        private void Attack()
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
