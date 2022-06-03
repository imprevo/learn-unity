using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    TextMesh hpLabel;
    int hp = 3;

    void Start()
    {
        hpLabel.text = hp.ToString();
    }

    public void TakeDamage()
    {
        hp--;
        hpLabel.text = hp.ToString();

        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
