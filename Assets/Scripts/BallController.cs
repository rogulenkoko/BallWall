using UnityEngine;
using UnityEngine.SceneManagement;
public enum State { MoveToLeft, MoveToRight, Left, Right };

public enum BallType { Left,Right};

public class BallController : MonoBehaviour {
    
    private State state;
    public BallType type;
    public GameObject barrier;
    public float left;
    public float right;
    public GameObject menu;

    private Random random = new Random();

	void Start () {
        if (type == BallType.Left)
            state = State.Left;
        if (type == BallType.Right)
            state = State.Right;
        Vector3 deltaPosition = Vector3.down * Random.Range(3f,8f);
        Vector3 previousPosition = Vector3.zero;
        Vector3 currentPosition = Vector3.zero;
        for (int i = 1; i < 100; i++)
        {

            currentPosition = previousPosition + deltaPosition;
            var boolChoice = Random.Range(0, 2);

            if (boolChoice == 1)
            {
                currentPosition = new Vector3(left + 0.15f, currentPosition.y + Random.Range(-2f, 2f), 0);
                Instantiate(barrier, currentPosition, Quaternion.Euler(0, 0, 90));
            }
            else
            {
                currentPosition = new Vector3(right - 0.15f, currentPosition.y + Random.Range(-2f, 2f), 0);
                Instantiate(barrier, currentPosition, Quaternion.Euler(0, 0, -90));
            }
            
   
            previousPosition = new Vector3(0, currentPosition.y);
            
        }
	}
	
	void Update () {
        MoveBall();
       if(state==State.Left)
            transform.Rotate(0, 0, -5);
        if (state == State.Right)
            transform.Rotate(0, 0, 5);

    }

    private bool CheckScreenSide(BallType type)
    {
        if (type == BallType.Left && Input.mousePosition.x > Screen.width / 2)
            return true;
        if (type == BallType.Right && Input.mousePosition.x < Screen.width / 2)
            return true;
        return false;
    }

    public void MoveBall()
    {
       
        if (Input.GetMouseButton(0))
        {
            if (CheckScreenSide(type))
                return;
            if (state == State.Left)
                state = State.MoveToRight;
            if (state == State.Right)
                state = State.MoveToLeft;
        }

        if (state == State.MoveToRight)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(left, transform.position.y, transform.position.z),
                        Time.deltaTime * 8);
        }
        if (state == State.MoveToLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(right, transform.position.y, transform.position.z),
                        Time.deltaTime * 8);
        }

        if (transform.position.x == left)
            state = State.Right;
        if (transform.position.x == right)
            state = State.Left;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Rigidbody2D>().gravityScale = -1;
        PlayerPrefs.SetInt("Score", Camera.main.GetComponent<Score>().score);
        if(PlayerPrefs.GetInt("Record") <=Camera.main.GetComponent<Score>().score)
            PlayerPrefs.SetInt("Record", Camera.main.GetComponent<Score>().score);
        SceneManager.LoadScene("gameMenu");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Camera.main.GetComponent<Score>().score++;
        Camera.main.GetComponent<Score>().GameScore.text = Camera.main.GetComponent<Score>().score.ToString();
        col.enabled = false;
    }
}


