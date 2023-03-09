namespace LearnUnity.TwinStickShooter
{
    using System.Collections;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;

        public void Start()
        {
            StartCoroutine(AttackLoop());
        }

        public IEnumerator AttackLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                weapon.Attack();
            }
        }
    }
}
