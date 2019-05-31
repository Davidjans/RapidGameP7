using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogManagers : MonoBehaviour
{
	public bool victory;
	[SerializeField] private float m_RotateBy;
	[SerializeField] List<CogHolders> m_CogHolders;
	private float m_CorrectPlace;


    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < m_CogHolders.Count; i++)
		{
			if (m_CogHolders[i].m_HeldCogWheel != null)
			{
				m_CogHolders[i].m_HeldCogWheel.transform.Rotate(0, 0, m_RotateBy);
			}
			if (m_CogHolders[i].m_Correct)
			{
					m_CorrectPlace++;
			}
		}
		Debug.Log(m_CorrectPlace);
		if (m_CorrectPlace >= m_CogHolders.Count)
		{
			victory = true;
			m_CorrectPlace = 0;
		}
		else
		{
			m_CorrectPlace = 0;
			victory = false;
		}
    }
}
