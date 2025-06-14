using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public int coinCount = 0;
    public Text coinText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            coinText.text = coinCount.ToString();
        }
    }
}