using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText();
        SetScoreText();
        winText.text = "";
    }


    void Update ()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();
        }

       else if (other.gameObject.CompareTag("Evil"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetScoreText();
        }

        if (count == 12)
        {
            transform.position = new Vector3(27.5f, 0.2f, -8.0f);
        }

    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();           
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 34)
        {
            winText.text = "You Win with a score of " + score.ToString();
        }
    }
}
