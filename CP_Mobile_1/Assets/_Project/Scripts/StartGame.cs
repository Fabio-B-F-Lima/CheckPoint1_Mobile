using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartGame : MonoBehaviour
{
    [SerializeField] Button buttonStart;

    private void Start()
    {
        buttonStart.onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
}
