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
    private int score = 0;
    private float time = 10f;
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
        print(score);
        print(time);
    }
    public void ChangeLaneX(int direction)
    {
        if (direction < 0)
        {
            if (currentLanex > -laneLimit)
            {
                currentLanex += direction;
            }
        }
        else if (direction > 0)
        {
            if (currentLanex < laneLimit)
            {
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
                currentLanez += direction;
            }
        }
        else if (direction > 0)
        {
            if (currentLanez < laneLimit)
            {
                currentLanez += direction;
            }
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Diamond"))
        {
            AddScore(100);
            AddTime(2.0f);
            Destroy(trigger.gameObject);

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
