using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public Text textScoreNumber;
    public Text textTimeNumber;
    Player player;


    void Start()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
       textScoreNumber.text = player.score.ToString();
       textTimeNumber.text = player.time.ToString();
    }
}
