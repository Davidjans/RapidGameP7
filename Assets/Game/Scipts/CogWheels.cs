using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogWheels : MonoBehaviour
{
	public float m_CogSize;
	public bool m_CurrentlyHeld;
	public Grabable m_Grabbable;
    // Start is called before the first frame update
    void Start()
    {
		m_Grabbable = GetComponent<Grabable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
