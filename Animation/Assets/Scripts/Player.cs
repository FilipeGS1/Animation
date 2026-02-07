using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Entrada A e D
        move = Input.GetAxisRaw("Horizontal");

        // Animação
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Virar a face
        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);   // direita
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);  // esquerda
        }
    }

    void FixedUpdate()
    {
        // Movimento físico
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }
}