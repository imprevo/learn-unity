namespace LearnUnity.TopDownAction
{
    using System.Collections;
    using UnityEngine;

    public class MeleeWeapon : MonoBehaviour
    {
        [SerializeField]
        private float attackDuration = 0.3f;

        [SerializeField]
        private float attackCooldown = 1f;

        [SerializeField]
        private float attackDistance = 1f;


        [SerializeField]
        private GameObject hurtBox;

        private Coroutine attackCoroutine;

        public float AttackDistance => attackDistance;

        public void Start()
        {
            hurtBox.SetActive(false);
        }

        public void OnDestroy()
        {
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
        }

        public void Attack()
        {
            if (attackCoroutine != null)
            {
                return;
            }

            attackCoroutine = StartCoroutine(AutoAttack());
        }

        private IEnumerator AutoAttack()
        {
            hurtBox.SetActive(true);
            yield return new WaitForSeconds(attackDuration);
            hurtBox.SetActive(false);
            yield return new WaitForSeconds(attackCooldown);
            attackCoroutine = null;
        }
    }
}
