using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    private void Start()
    {
        _menuPanel.SetActive(true);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}


