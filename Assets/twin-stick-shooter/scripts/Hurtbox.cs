namespace LearnUnity.TwinStickShooter
{
    using System;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class Hurtbox : MonoBehaviour
    {
        public event Action OnHit;

        public void OnTriggerEnter(Collider other)
        {
            var damagable = other.gameObject.GetComponent<Damagable>();
            damagable?.TakeDamage();
            OnHit?.Invoke();
            Debug.Log("OnHit " + other.gameObject);
        }
    }
}
