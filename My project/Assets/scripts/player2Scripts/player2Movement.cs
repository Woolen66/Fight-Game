using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player2Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private bool crouch = false;
    private bool isGrounded = true;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    private BoxCollider2D playerCollider;
    public Animator animator;
    [HideInInspector]
    public bool canMove = true;
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        if (playerCollider != null)
        {
            originalColliderSize = playerCollider.size;
            originalColliderOffset = playerCollider.offset;
        }

    }

    async Task Update()
    {

        // Basicamente esto es para que no se mueva cuando este agachado
        if (!crouch && canMove)
        {
            // Obtener la entrada del teclado solo para las teclas A y D
            float moveX = Input.GetKey(KeyCode.LeftArrow) ? -1f : (Input.GetKey(KeyCode.RightArrow) ? 1f : 0f);

            // Animacion de movimiento izq y der
            animator.SetFloat("movement", moveX);

            // Crear un vector de movimiento solo en el eje X
            Vector3 movement = new Vector3(moveX, 0f, 0f);

            // Aplicar movimiento al objeto
            transform.position += movement * speed * Time.deltaTime;
        }
        else
        {
            animator.SetFloat("movement", 0);
        }

        // Saltar con W
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, jumpForce);
            isGrounded = false;
            animator.SetBool("isGround", isGrounded);
            animator.SetBool("endJump", false);
            animator.SetFloat("movement", 0);
        }

        // Reducir hitbox al presionar S
        if (playerCollider != null && isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerCollider.size = new Vector2(originalColliderSize.x, originalColliderSize.y * 0.75f);
                playerCollider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - (originalColliderSize.y * 0.125f));
                animator.SetBool("crouch", true); // Animacion de agacharse
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                playerCollider.size = originalColliderSize;
                playerCollider.offset = originalColliderOffset;
                animator.SetBool("crouch", false); // Anulamos la animacion de agacharse
                animator.SetBool("unCrouch", true); // Ejecutamos la animacion de levantarse
                await unCrouchTime(150); // Llamamos a una funcion para que espere el tiempo de la animacion
                crouch = false;
            }
        }
    }

    // Funcion en la que esperamos x tiempo que es lo que dura la animacion para que haga una transicion
    async Task unCrouchTime(int milis)
    {
        await Task.Delay(milis);
        animator.SetBool("unCrouch", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isGround", isGrounded);
            animator.SetBool("endJump", true);
        }
    }
}


