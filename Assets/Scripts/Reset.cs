using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.G))
            {
                SceneManager.LoadScene("Alina");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 1;
            }
    }
}
