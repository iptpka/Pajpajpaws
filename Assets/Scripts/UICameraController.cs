using UnityEngine;
using Cinemachine;

public class UICameraController : MonoBehaviour
{
	public CinemachineVirtualCamera vc;
	private CinemachineTrackedDolly td;
	
	void Start()
	{
		td = vc.GetCinemachineComponent<CinemachineTrackedDolly>();
	}

    void Update()
    {
        td.m_PathPosition += 0.1f * Time.deltaTime;
    }
}
