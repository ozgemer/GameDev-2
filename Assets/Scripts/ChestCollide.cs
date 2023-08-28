using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChestCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        // End game successfully
        SceneManager.LoadScene(3);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
