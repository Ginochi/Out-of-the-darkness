using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private bool isMoving;

    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector2(mousePos.x, mousePos.y);
            isMoving = true;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);

            if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}