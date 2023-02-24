namespace LearnUnity.Inventory
{
    using System;
    using System.Collections.Generic;

    public class Inventory
    {
        public List<InventoryItem> Items { get; }

        public event Action OnChange;

        public Inventory(List<InventoryItem> init)
        {
            Items = init;
        }

        public bool HasItem(InventoryItem item)
        {
            return Items.Contains(item);
        }

        public void AddItem(InventoryItem item)
        {
            Items.Add(item);
            OnChange?.Invoke();
        }

        public void RemoveItem(InventoryItem item)
        {
            Items.Remove(item);
            OnChange?.Invoke();
        }
    }
}
