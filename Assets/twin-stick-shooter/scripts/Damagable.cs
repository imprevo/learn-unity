namespace LearnUnity.TwinStickShooter
{
    using UnityEngine;

    public class Damagable : MonoBehaviour
    {
        public void TakeDamage()
        {
            Debug.Log("Take damage: " + gameObject);
        }
    }
}
