using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSneak : MonoBehaviour
{
    GameObject sneak;
    bool state = false;
    [SerializeField] Image cooldown;
    [SerializeField] GameObject mask;
    [SerializeField] TMPro.TextMeshProUGUI timer;

    private void Awake()
    {
        cooldown.color = new Color32(32, 255, 0, 255);
        sneak = new GameObject("Sneak");
        timer.text = "5";
        mask.SetActive(false);
    }

    void Update()
    {
        if (!state && Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(SneakState());
    }

    IEnumerator SneakState()
    {
        GameObject sneakClone = Instantiate(sneak, transform.position, Quaternion.identity, transform);
        Debug.Log("sneaking");
        mask.SetActive(true);
        state = true;
        cooldown.color = new Color32(255, 5, 0, 255);
        yield return new WaitForSeconds(1);
        timer.text = "4";
        yield return new WaitForSeconds(1);
        timer.text = "3";
        yield return new WaitForSeconds(1);
        timer.text = "2";
        yield return new WaitForSeconds(1);
        timer.text = "1";
        yield return new WaitForSeconds(1);
        mask.SetActive(false);
        timer.text = "-";
        Debug.Log("stopped sneaking");
        Destroy(sneakClone);
        yield return new WaitForSeconds(5);
        cooldown.color = new Color32(255, 230, 0, 255);
        yield return new WaitForSeconds(2);
        state = false;
        cooldown.color = new Color32(32, 255, 0, 255);
        timer.text = "5";
    }
}
