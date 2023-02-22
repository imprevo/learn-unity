namespace LearnUnity.InteractWithObjects
{
    using UnityEngine;

    public class InventoryPickup : Interactible
    {
        [SerializeField]
        private InventoryItem itemType;

        public override void Interact(GameObject actor)
        {
            var inventory = actor.GetComponent<Inventory>();
            if (inventory)
            {
                if (!inventory.HasItem(itemType))
                {
                    inventory.AddItem(itemType);
                }
                else
                {
                    inventory.RemoveItem(itemType);
                }
                Debug.Log(string.Join(", ", inventory.list));
            }
        }
    }
}
