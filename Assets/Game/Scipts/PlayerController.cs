using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{
	public XboxController m_ThisController;
	[SerializeField] private float m_MovementSpeed;
	[SerializeField] private Transform m_Arms;
	[SerializeField] private Transform m_LookTarget;
	private Vector2 m_NewPosition;

	private Rigidbody2D m_PlayerRigidbody;

    void Start()
    {
		m_PlayerRigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		m_NewPosition = new Vector2(transform.position.x + XCI.GetAxis(XboxAxis.LeftStickX, m_ThisController) * m_MovementSpeed, transform.position.y);
		m_PlayerRigidbody.MovePosition(m_NewPosition);
		float rightStickX = XCI.GetAxis(XboxAxis.RightStickX, m_ThisController);
		float rightStickY = XCI.GetAxis(XboxAxis.RightStickY, m_ThisController);
		m_LookTarget.localPosition = new Vector2(rightStickX, Mathf.Clamp(rightStickY,0 , 100));
		//m_Arms.transform.LookAt(m_LookTarget);
		Vector2 direction = new Vector2(m_LookTarget.position.x - m_Arms.position.x, m_LookTarget.position.y - m_Arms.position.y);
		m_Arms.right = direction;
	}
}
