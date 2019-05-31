using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamp : MonoBehaviour
{
	[SerializeField] private CogManagers m_CogManagers;
	[SerializeField] private SpriteRenderer m_Lamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (m_CogManagers.victory)
		{
			m_Lamp.color = Color.yellow;
		}
		else
		{
			m_Lamp.color = Color.white;
		}
    }
}
