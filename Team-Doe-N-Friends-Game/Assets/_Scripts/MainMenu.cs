using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
      Debug.Log("play game");
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void Exit()
   {
      Debug.Log("Quit");
      Application.Quit();
   } 
}
