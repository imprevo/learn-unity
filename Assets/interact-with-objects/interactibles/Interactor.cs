namespace LearnUnity.InteractWithObjects
{
    using UnityEngine;

    [RequireComponent(typeof(CursorController))]
    public class Interactor : MonoBehaviour
    {
        [SerializeField]
        private LayerMask interactibleLayer;

        private Camera mainCamera;

        private CursorController cursor;

        private RaycastHit mouseHit;

        private Interactible interactible;

        public void Start()
        {
            mainCamera = Camera.main;
            cursor = GetComponent<CursorController>();
        }

        public void Update()
        {
            CheckObjects();

            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }

        private void CheckObjects()
        {
            interactible = null;
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out mouseHit, interactibleLayer))
            {
                Debug.DrawLine(ray.origin, mouseHit.point, Color.green);
                var obj = mouseHit.collider.gameObject.GetComponent<Interactible>();
                if (obj && obj.canInteract)
                {
                    cursor.SetHover();
                    interactible = obj;
                }
                else
                {
                    cursor.SetDisable();
                }
            }
            else
            {
                cursor.SetDefault();
            }
        }

        private void Interact()
        {
            interactible?.Interact(gameObject);
        }
    }
}
