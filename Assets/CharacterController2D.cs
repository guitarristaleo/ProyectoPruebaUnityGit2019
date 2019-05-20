using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; // How much to smooth out the movement

    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public float runSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
    }

    void FixedUpdate()
    {
        this.MoveHorizontal(horizontalMove * Time.fixedDeltaTime);
        this.MoveVertical(verticalMove * Time.fixedDeltaTime);
    }

    public void MoveHorizontal(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

    }

    public void MoveVertical(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, move * 10f);

        Debug.Log("hola");

        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

    }
}
