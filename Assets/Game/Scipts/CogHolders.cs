using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogHolders : MonoBehaviour
{
	public float m_CorrectSize;
	public CogWheels m_HeldCogWheel;
	private bool m_CurrentlyHolding;
	private Rigidbody2D m_CogRigidbody;
	private void Update()
	{
		if (m_CurrentlyHolding == true && m_HeldCogWheel.m_Grabbable.m_PickedUp == false && m_HeldCogWheel.m_CurrentlyHeld == false)
		{
			m_HeldCogWheel.gameObject.transform.position = transform.position;
			m_HeldCogWheel.m_CurrentlyHeld = true;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Cog"))
		{
			if (m_CurrentlyHolding == false)
			{
				m_HeldCogWheel = collision.gameObject.GetComponent<CogWheels>();
				m_CogRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
				if (m_HeldCogWheel.m_Grabbable.m_PickedUp == false)
				{
					Freeze();
					m_CurrentlyHolding = true;
				}
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Cog"))
		{
			if (m_CurrentlyHolding == true)
			{
				UnFreeze();
				m_HeldCogWheel.m_CurrentlyHeld = false;
				m_HeldCogWheel = null;
				m_CogRigidbody = null;
				m_CurrentlyHolding = false;
			}
		}
	}

	private void Freeze()
	{
		m_CogRigidbody.velocity = Vector2.zero;
		m_CogRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
		m_CogRigidbody.transform.parent = transform;
		m_CogRigidbody.gravityScale = 0;
	}

	private void UnFreeze()
	{
		m_CogRigidbody.velocity = Vector2.zero;
		m_CogRigidbody.constraints = RigidbodyConstraints2D.None;
		m_CogRigidbody.transform.parent = null;
		m_CogRigidbody.gravityScale = 1;
	}
}
