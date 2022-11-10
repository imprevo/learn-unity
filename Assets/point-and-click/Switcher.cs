namespace LearnUnity.PointAndClick
{
    using UnityEngine;

    public class Switcher : MonoBehaviour
    {
        [SerializeField]
        private Interactible[] list;
        [SerializeField]
        private Interactible target;

        public void Start()
        {
            foreach (var item in list)
            {
                item.OnChange += Check;
            }
            Check();
        }

        public void OnDestroy()
        {
            foreach (var item in list)
            {
                item.OnChange -= Check;
            }
        }

        private void Check()
        {
            var shouldActivate = ShouldActivate();
            target.SetIsActive(shouldActivate);
        }

        private bool ShouldActivate()
        {
            foreach (var item in list)
            {
                if (!item.IsActive)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
