namespace LearnUnity
{
    using UnityEngine;

    public class CursorController : MonoBehaviour
    {
        [SerializeField]
        private Texture2D cursorDefault;
        [SerializeField]
        private Texture2D cursorHover;

        public void Start()
        {
            SetDefault();
        }

        public void SetDefault()
        {
            SetCursor(cursorDefault);
        }

        public void SetHover()
        {
            SetCursor(cursorHover);
        }

        private void SetCursor(Texture2D cursor)
        {
            var hotspot = new Vector2(14, 14);
            Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
        }
    }
}
