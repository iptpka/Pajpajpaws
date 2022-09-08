using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private int mouseOverCursor;
	[SerializeField] private int clickCursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	public void OnPointerEnter(PointerEventData pointerEventData) 
	{
		Debug.Log("pois");
	}
	
	public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
