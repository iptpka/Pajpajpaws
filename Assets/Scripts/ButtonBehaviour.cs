using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ButtonBehaviour : MonoBehaviour
{
	public CinemachineVirtualCamera UICamera;
	public CinemachineFreeLook KattiKamera;
	public GameObject mainMenu;
	//public GameObject buttonDisabler;
	[SerializeField] private GameObject katti;
	bool menuView;
	
    // Start is called before the first frame update
    void Start()
    {
        menuView = true;
    }
	
	
	public void ToggleCamera()
	{
		if (menuView)
		{
			UICamera.m_Priority = 0;
			KattiKamera.m_Priority = 1;
			katti.GetComponent<MeshCollider>().enabled = true;
			katti.transform.parent.GetComponent<KattiBehaviour>().Init();
			//buttonDisabler.SetActive(true);
		}
		else
		{
			UICamera.m_Priority = 1;
			KattiKamera.m_Priority = 0;
			//buttonDisabler.SetActive(false);
		}
		menuView = !menuView;
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
