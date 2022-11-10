namespace LearnUnity.PointAndClick
{
    using UnityEngine;

    public class Portal : Interactible
    {
        [SerializeField]
        protected Renderer renderer;
        [SerializeField]
        private Light light;
        [SerializeField]
        private Collider collider;
        [SerializeField]
        public Transform target;

        public void Start()
        {
            Disable();
        }

        public override void Enable()
        {
            base.Enable();
            light.enabled = true;
            collider.enabled = true;
        }

        public override void Disable()
        {
            base.Disable();
            light.enabled = false;
            collider.enabled = false;
        }

        public void OnMouseEnter()
        {
            renderer.materials[1].color = Color.yellow;
        }

        public void OnMouseExit()
        {
            renderer.materials[1].color = Color.white;
        }

        public override void Interact()
        {
            var pos = Camera.main.transform.position;
            pos.x = target.position.x;
            Camera.main.transform.position = pos;
            Disable();
        }
    }
}
