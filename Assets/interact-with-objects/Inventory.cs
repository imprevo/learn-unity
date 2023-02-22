namespace LearnUnity.InteractWithObjects
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public enum InventoryItem
    {
        KEY,
        MAP,
        POTION,
    }

    public class Inventory : MonoBehaviour
    {
        public readonly List<InventoryItem> list = new();

        public event Action OnChange;

        public bool HasItem(InventoryItem type)
        {
            return list.Contains(type);
        }

        public void AddItem(InventoryItem type)
        {
            list.Add(type);
            OnChange?.Invoke();
        }

        public void RemoveItem(InventoryItem type)
        {
            list.Remove(type);
            OnChange?.Invoke();
        }
    }
}
