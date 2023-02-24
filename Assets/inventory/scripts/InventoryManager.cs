namespace LearnUnity.Inventory
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        public List<InventoryItem> items;

        private Inventory inventory1;
        private Inventory inventory2;

        public void Start()
        {
            inventory1 = new Inventory(new List<InventoryItem>(items));
            inventory2 = new Inventory(new List<InventoryItem>());
        }

        public void Move()
        {
            var item = inventory1.Items.First();
            inventory1.RemoveItem(item);
            inventory2.AddItem(item);
        }

    }
}
