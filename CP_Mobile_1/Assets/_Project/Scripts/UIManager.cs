using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas Maincanvas;
    [SerializeField] GameObject losePanel;

    [SerializeField] Button[] buttons;
    public Text textScoreNumber;
    public Text textTimeNumber;
    Player player;


    void Start()
    {
        player = GetComponent<Player>();
       losePanel.SetActive(false);

        buttons[0].onClick.AddListener(ResetGame);
        buttons[1].onClick.AddListener(QuitGame);


        Time.timeScale = 1.0f;
    }
    void Update()
    {
        ShowLoseScreen();
        textScoreNumber.text = player.score.ToString();
        textTimeNumber.text = player.time.ToString();
     
    }

    private void QuitGame()
    {
       Application.Quit();
    }

    private void ResetGame()
    {
        Debug.Log("BOTÃO CLICADO");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
    }
    void ShowLoseScreen()
    {
        if (player.time <= 0)
        {
         losePanel.SetActive (true);  
            Time.timeScale = 0.0f;
        }
    }
}