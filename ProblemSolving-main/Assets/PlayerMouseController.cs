using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public Camera mainCamera;
    public ScoreController scoreController;
    // bool facingRight = true;

    // Header
    [Header("Ball Movement")]
    // public Vector2 ballAngle = new Vector2(100, 100);
    public float speed;
    public float rotaionOffset;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // private void Update()
    // {
    //     Vector3 target = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    //     Vector3 moveAngle = target - transform.position;

    //     if (Vector3.Distance(target, transform.position) > 0.5)
    //         transform.Translate(moveAngle.normalized * speed * Time.deltaTime);

    //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //     if (mousePos.x > transform.position.x && !facingRight)
    //     {
    //         flip();
    //     }
    //     else if (mousePos.x < transform.position.x && facingRight)
    //     {
    //         flip();
    //     }
    // }

    // void flip()
    // {
    //     facingRight = !facingRight;
    //     transform.Rotate(0f, 180f, 0f);
    // }

    private void Update() 
    {

     Vector3 mousePos = Input.mousePosition;
     mousePos.z = 0;
     Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

     mousePos.x = mousePos.x - objectPos.x;
     mousePos.y = mousePos.y - objectPos.y;  

     float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotaionOffset));

     Vector3 targerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     targerPos.z = 0;
     transform.position = Vector3.MoveTowards(transform.position, targerPos, speed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            scoreController.IncreaseCurrentScore(1);
            Destroy(collision.gameObject);
        }
    }
}
