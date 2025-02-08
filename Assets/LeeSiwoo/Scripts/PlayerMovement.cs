using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private MicInput micInput;
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private GameObject SaveEffect;

    private string PointName;

    private Vector3 RespawnPos;

    private Animator animator;

    float _ref = 0.05f;

    private bool isJump = false;

    [HideInInspector]
    public bool GameDone = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

	private void FixedUpdate()
	{
		if (GameDone) return;
		InputHandler();
	}
	void InputHandler()
    {
        float decibel = micInput.GetDecibel(_ref);
        if (decibel >= 7 && decibel < 15)
        {
            animator.SetBool("isMove", true);
            rigid.velocity = new Vector2(Speed, rigid.velocity.y); return;
        }
        else if(decibel >= 15 &&  decibel < 20 && !isJump)
        {
            rigid.AddForce(Vector3.up * 9, ForceMode2D.Impulse);
            isJump = true;
            return;
        }
        else if(decibel >= 20)
        {
            Death();
            return;
        }
		animator.SetBool("isMove", false);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("SavePoint"))
        {
            RespawnPos = collision.gameObject.transform.position;
            if(PointName != collision.gameObject.name)
            {
                GameObject clone = Instantiate(SaveEffect, RespawnPos, Quaternion.identity);
                Destroy(clone, 0.3f);
                PointName = collision.gameObject.name;
            }
        }
	}
	public void Death()
    {
        Debug.Log("Death");
        GameDone = true;
        cinemachine.Follow = null;
        Invoke("Respawn", 0.7f);
    }
    private void Respawn()
    {
        GameDone = false;
        cinemachine.Follow = this.gameObject.transform;
        transform.position = RespawnPos;
    }
}
