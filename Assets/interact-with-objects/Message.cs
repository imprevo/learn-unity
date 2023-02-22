namespace LearnUnity.InteractWithObjects
{
    using System.Collections;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TMP_Text))]
    public class Message : MonoBehaviour
    {
        private TMP_Text label;

        public void Start()
        {
            label = GetComponent<TMP_Text>();
            gameObject.SetActive(false);
        }

        public void ShowMessage(string text, float delay)
        {
            StopAllCoroutines();
            gameObject.SetActive(true);
            label.text = text;
            StartCoroutine(HideLabel(delay));
        }

        private IEnumerator HideLabel(float delay)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
        }
    }
}
