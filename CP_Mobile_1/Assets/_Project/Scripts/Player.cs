using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float stepSpeed;
    [SerializeField] private float currentLanex = 0;
    [SerializeField] private float currentLanez = 0;
    [SerializeField] private float laneLimit = 1;


    [Header("Controller Settings")]
    private Vector3 currentPosition;

    [Header("Score Settings")]
    public int score = 0;
    public float time = 10f;
    private float timeCount;

    void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        currentPosition = new Vector3(currentLanex, currentPosition.y, currentLanez);
        transform.position = Vector3.MoveTowards(transform.position, currentPosition, stepSpeed * Time.deltaTime);

        TimeCount();
    }
    public void ChangeLaneX(int direction)
    {
        if (direction < 0)
        {
            if (currentLanex > -laneLimit)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                currentLanex += direction;
            }
        }
        else if (direction > 0)
        {
            if (currentLanex < laneLimit)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                currentLanex += direction;
            }
        }
    }
    public void ChangeLaneZ(int direction)
    {
        if (direction < 0)
        {
            if (currentLanez > -laneLimit)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
                currentLanez += direction;
            }
        }
        else if (direction > 0)
        {
            if (currentLanez < laneLimit)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
                currentLanez += direction;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            AddScore(250);
            AddTime(3.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Emerald"))
        {
            AddScore(450);
            AddTime(5.0f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Ametist"))
        {
            AddScore(700);
            AddTime(8.0f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Spike"))
        {
            AddScore(-500);
            AddTime(-10.0f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("KABUM"))
        {
            AddScore(-1000);
            AddTime(-20.0f);
            Destroy(other.gameObject);
        }


    }


    void AddScore(int value)
    {
        score += value;
    }
    void AddTime(float timeAdded)
    {
        time += timeAdded;
    }

    void TimeCount()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= 1f)
        {
            time--;
            timeCount -= 1f;
        }
    }
}
