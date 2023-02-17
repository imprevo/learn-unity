namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    public class WeaponUpgrade : MonoBehaviour, IInteractible
    {
        public void Use(GameObject actor)
        {
            var weapon = actor.GetComponent<WeaponController>();
            if (weapon)
            {
                weapon.Upgrade();
                Destroy(gameObject);
            }
        }
    }
}
