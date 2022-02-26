using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{

   public void StartLoadScene(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
