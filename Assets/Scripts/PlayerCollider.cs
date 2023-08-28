using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI counter;
    public int coins = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Collected Coin");
            coins++;
            counter.text = coins.ToString();
        }
    }
}
