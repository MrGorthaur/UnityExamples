using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelManager : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }

}
