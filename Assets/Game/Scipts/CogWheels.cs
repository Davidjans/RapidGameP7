using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogWheels : MonoBehaviour
{
	public float m_CogSize;
	public bool m_CurrentlyHeld;
	public bool m_ExampleCog;
	private PolygonCollider2D m_Collider;
	public Grabable m_Grabbable;

    // Start is called before the first frame update
    void Start()
    {
		m_Collider = GetComponent<PolygonCollider2D>();
		m_Grabbable = GetComponent<Grabable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CurrentlyHeld || m_Grabbable.m_PickedUp)
		{
			m_Collider.isTrigger = true;
		}
		else
		{
			m_Collider.isTrigger = false;
		}
	}
}
