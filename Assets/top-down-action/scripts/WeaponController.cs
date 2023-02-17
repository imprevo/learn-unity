namespace LearnUnity.TopDownAction
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectilePrefab;

        [SerializeField]
        private float shootDistance = 0.5f;

        private int level = 1;

        private float attackDelay = 1f;

        private Coroutine attackCoroutine;

        public event Action OnChange;

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

        public void Upgrade()
        {
            level++;
            attackDelay *= 0.95f;
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
            var step = 360 / level;
            for (var i = 0; i < level; i++)
            {
                Fire(step * i);
            }
        }

        private void Fire(float angle)
        {
            var rotation = transform.rotation * Quaternion.AngleAxis(angle, Vector3.up);
            var diff = rotation * Vector3.forward * shootDistance;
            Instantiate(projectilePrefab, transform.position + diff, rotation);
        }
    }
}
