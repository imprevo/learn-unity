namespace LearnUnity.PointAndClick
{
    using System;
    using UnityEngine;

    public abstract class Interactible : MonoBehaviour
    {
        public bool IsActive { get; private set; }

        public event Action OnChange;

        public virtual void Enable()
        {
            IsActive = true;
            OnChange?.Invoke();
        }

        public virtual void Disable()
        {
            IsActive = false;
            OnChange?.Invoke();
        }

        public void Toggle()
        {
            if (IsActive)
            {
                Disable();
            }
            else
            {
                Enable();
            }
        }

        public void SetIsActive(bool value)
        {
            if (value == IsActive)
            {
                return;
            }

            if (value)
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }

        public abstract void Interact();
    }
}
