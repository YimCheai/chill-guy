using UnityEngine;

public class ColliderRange : MonoBehaviour
{
	[SerializeField]
	private PlayerMovement pm;
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			pm.Death();
		}
	}
}
