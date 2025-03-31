using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private bool isGrounded = true;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private BoxCollider2D playerCollider;
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        if (playerCollider != null)
        {
            originalColliderSize = playerCollider.size;
            originalColliderOffset = playerCollider.offset;
        }
    }

    void Update()
    {
        // Obtener la entrada del teclado solo para las teclas A y D
        float moveX = Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f);

        // Crear un vector de movimiento solo en el eje X
        Vector3 movement = new Vector3(moveX, 0f, 0f);

        // Aplicar movimiento al objeto
        transform.position += movement * speed * Time.deltaTime;

        // Saltar con W
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, jumpForce);
            isGrounded = false;
        }

        // Reducir hitbox al presionar S
        if (playerCollider != null)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                playerCollider.size = new Vector2(originalColliderSize.x, originalColliderSize.y * 0.5f);
                playerCollider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - (originalColliderSize.y * 0.25f));
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                playerCollider.size = originalColliderSize;
                playerCollider.offset = originalColliderOffset;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
