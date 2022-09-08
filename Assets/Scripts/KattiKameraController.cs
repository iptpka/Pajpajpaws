using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KattiKameraController : MonoBehaviour
{

	[SerializeField] CinemachineFreeLook vc;
	[SerializeField] GameObject cursor;
	private CursorBehaviour cb;
	bool drag;


    // Start is called before the first frame update
    void Start()
    {
        cb = cursor.GetComponent<CursorBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			drag = false;
		}
 
		if (Input.GetMouseButtonUp(0))
		{
			drag = false;
		}
		if (vc.m_Priority == 1 && !cb.onKatti) {
	 
			if (Input.GetMouseButton(0))
			{
				drag = true;
			}
			
		}
		if (drag)
		{
			vc.m_YAxis.m_MaxSpeed = 12f;
			vc.m_XAxis.m_MaxSpeed = 600f;
		}
		else
		{
			vc.m_YAxis.m_MaxSpeed = 0f;
			vc.m_XAxis.m_MaxSpeed = 0f;
		}
    }
}
