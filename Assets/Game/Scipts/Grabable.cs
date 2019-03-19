using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
	public bool m_PickedUp;
	private Rigidbody2D m_ObjectRigidBody;


	private void Start()
	{
		m_ObjectRigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
