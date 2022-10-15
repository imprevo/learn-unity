namespace LearnUnity
{
    using UnityEngine;

    public class Door : MonoBehaviour
    {
        [SerializeField]
        private Animation animation;

        private bool isOpen = true;

        public void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }

        private void Open()
        {
            animation.Play("DoorOpenAnimation");
            isOpen = true;
        }

        private void Close()
        {
            animation.Play("DoorCloseAnimation");
            isOpen = false;
        }
    }
}
