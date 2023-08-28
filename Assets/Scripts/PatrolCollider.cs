using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PatrolCollider : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !player.transform.Find("Sneak(Clone)"))
        {
            StartCoroutine(CatchPlayer());
        }
    }

    IEnumerator CatchPlayer()
    {
        Debug.Log("Lost!");
        yield return new WaitForSeconds(1);
        // End Game
        SceneManager.LoadScene(2);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
