namespace LearnUnity.PointAndClick
{
    using UnityEngine;

    public class Computer : Interactible
    {
        [SerializeField]
        protected Renderer renderer;

        [SerializeField]
        private Light light;

        public override void Interact()
        {
            Toggle();
            light.enabled = IsActive;
        }

        public void OnMouseEnter()
        {
            renderer.material.color = Color.yellow;
        }

        public void OnMouseExit()
        {
            renderer.material.color = Color.white;
        }
    }
}
