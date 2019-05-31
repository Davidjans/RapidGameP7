using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
	public bool m_PickedUp;
	private Rigidbody2D m_ObjectRigidBody;
	private PolygonCollider2D m_Collider;


	private void Start()
	{
		m_ObjectRigidBody = GetComponent<Rigidbody2D>();
		m_Collider = GetComponent<PolygonCollider2D>();
	}
}
