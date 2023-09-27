using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
      public void restartGame(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }

}
