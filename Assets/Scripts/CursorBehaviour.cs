using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CursorBehaviour : MonoBehaviour
{
	private Rect screenRect = new Rect(0,0, Screen.width, Screen.height);
	[SerializeField] private Camera uicamera;
	[SerializeField] private Sprite[] cursorSprites;
	[SerializeField] private Texture2D pokeMap;
	Vector3 worldPosition;
	private Image image;
	public bool onKatti = false;
	public bool punished = false;
	private Animator m_Animator;
	private int pokeable = 0;
    // Start is called before the first frame update
    void Start()
    {
		Cursor.visible = false;
		image = GetComponent<Image>();
		m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitData;
		if (!punished)
			{
				if (Input.GetMouseButtonUp(0))
			{
				if (onKatti)
				{
					SetActiveCursor(2);
				}
				else 
				{
					SetActiveCursor(0);
				}
				m_Animator.Play("Stop");
			}
			
			if (Input.GetMouseButtonDown(0)) 
			{
				if (!onKatti)
				{
					SetActiveCursor(3);
				}
				else
				{
					if (pokeable == 1) SetActiveCursor(1);
					m_Animator.Play("CursorAnimationPet");
				}

			}
			else 
			{
				if(Physics.Raycast(ray, out hitData, 1000) && hitData.transform.tag == "Player")
				{
					Vector2 pixelUV = hitData.textureCoord;
					pixelUV.x *= pokeMap.width;
					pixelUV.y *= pokeMap.height;
					pokeable = (int) pokeMap.GetPixel((int)pixelUV.x, (int)pixelUV.y).r;
					if (!onKatti)
					{

						if (pokeable == 1) 
						{
							SetActiveCursor(0);
						}
						else 
						{
							pokeable = 0;
							SetActiveCursor(2);
						}
						onKatti = true;
					}
				}
				else if (onKatti)
				{
					pokeable = 0;
					m_Animator.Play("Stop");
					SetActiveCursor(0);
					onKatti = false;
				}
			}
		} 
		else 
		{
			m_Animator.Play("Stop");
		}

        transform.position = Input.mousePosition;

    }
	
	public void SetActiveCursor (int cursor)
	{
		image.sprite = cursorSprites[cursor];
	}
}
