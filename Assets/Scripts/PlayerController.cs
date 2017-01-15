using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;

    public Text count_text;
    public Text win_text;

    private int count_elements = 0;

    private void Update() //called every frame
    {

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ShowScore();
        win_text.text = "";
    }

    private void FixedUpdate() //called every phisical operation
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count_elements++;
            ShowScore();
        }
    }

    void ShowScore()
    {
        count_text.text = "Score: " + count_elements.ToString();
        if (count_elements >= 8)
        {
            win_text.text = "You win!!!";
        }
    }
}
