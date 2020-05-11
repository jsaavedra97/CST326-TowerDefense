using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void StartNextScene()
    {
        //Application.LoadLevel("Part2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
