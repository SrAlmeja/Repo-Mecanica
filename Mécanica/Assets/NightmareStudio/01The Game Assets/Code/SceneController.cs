using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
   public string SceneToLoad;

   public void LoadScene(){
    SceneManager.LoadScene(SceneToLoad);
   }

   public void ExitGame(){
      Application.Quit();
   }
}
