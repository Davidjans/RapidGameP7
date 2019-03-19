using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Holding : MonoBehaviour
{
	[SerializeField] private PlayerController m_PlayerController;
	[SerializeField] private float m_ForwardForce;
	[SerializeField] private Transform m_HoldPosition;
	private Grabable m_CurrentlyHeld;
	private bool m_CurrentlyHolding;
	private Rigidbody2D m_ObjectRigidBody;
	private Transform m_ObjectPosition;
	private Collider2D m_ObjectCollision;

	private void Update()
	{
		if (m_CurrentlyHolding == true)
		{
			m_ObjectPosition.position = m_HoldPosition.position;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (XCI.GetButtonDown(XboxButton.RightBumper, m_PlayerController.m_ThisController))
		{
			if (collision.gameObject.CompareTag("Grabbable") || collision.gameObject.CompareTag("Cog"))
			{
				m_CurrentlyHeld = collision.gameObject.GetComponent<Grabable>();

				if (m_CurrentlyHeld.m_PickedUp == false && m_CurrentlyHolding == false)
				{
					PickUp();
				}
				else if (m_CurrentlyHeld != null)
				{
					if (m_CurrentlyHeld.m_PickedUp == true && m_CurrentlyHolding == true)
					{
						LetGo();
					}
				}
			}
		}
		else if (XCI.GetButtonDown(XboxButton.RightBumper, m_PlayerController.m_ThisController) && m_CurrentlyHeld != null)
		{
			LetGo();
		}
	}

	private void PickUp()
	{
		m_ObjectRigidBody = m_CurrentlyHeld.GetComponent<Rigidbody2D>();
		m_ObjectRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
		m_ObjectPosition = m_CurrentlyHeld.GetComponent<Transform>();
		m_ObjectPosition.parent = transform.parent;
		m_ObjectCollision = m_ObjectPosition.GetComponent<PolygonCollider2D>();
		m_ObjectCollision.isTrigger = true;
		m_CurrentlyHeld.m_PickedUp = true;
		m_CurrentlyHolding = true;
		m_ObjectRigidBody.velocity = Vector3.zero;
		m_ObjectRigidBody.angularVelocity = 0;
	}

	private void LetGo()
	{
		m_ObjectRigidBody.constraints = RigidbodyConstraints2D.None;
		m_ObjectRigidBody.velocity = Vector3.zero;
		m_ObjectRigidBody.angularVelocity = 0;
		m_ObjectRigidBody.AddForce(transform.right * m_ForwardForce, ForceMode2D.Impulse);
		m_CurrentlyHolding = false;
		m_CurrentlyHeld.m_PickedUp = false;
		m_ObjectCollision.isTrigger = false;
		m_ObjectPosition.parent = null;
		m_ObjectPosition = null;
		m_ObjectCollision = null;
		m_CurrentlyHeld = null;
		m_ObjectRigidBody = null;
	}
}
