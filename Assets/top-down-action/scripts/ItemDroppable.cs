namespace LearnUnity.TopDownAction
{
    using UnityEngine;

    public class ItemDroppable : MonoBehaviour
    {
        [SerializeField]
        private GameObject itemPrefab;

        public void SetItem(GameObject prefab)
        {
            itemPrefab = prefab;
        }

        public void DropItem()
        {
            if (itemPrefab)
            {
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
