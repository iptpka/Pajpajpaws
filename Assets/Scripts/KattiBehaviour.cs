using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KattiBehaviour : MonoBehaviour
{
	[SerializeField] private Texture2D annoyMap;
	[SerializeField] private Image moodIndicator;
	[SerializeField] private GameObject menu;
	[SerializeField] GameObject scoreboard;
	[SerializeField] private Button buttonwhy;
	[SerializeField] private GameObject cursor;
	[SerializeField] private ParticleSystem[] particles;
	private float moodScore = 0.0f;
	private bool petting = false;
	private bool canpet = false;
	private Animator menuAnimator;
	private float startTime;
	private CursorBehaviour cb;

    // Start is called before the first frame update
	
	void Start()
	{
		menuAnimator = menu.GetComponent<Animator>();
		cb = cursor.GetComponent<CursorBehaviour>();

	}
	
    public void Init()
    {
        moodScore = 0.0f;
		petting = true;
		startTime = Time.time;
		cb.punished = false;
		canpet = false;

    }

    // Update is called once per frame
    void Update()
    {


		if (!petting) return;
		
		if (moodScore <= -375)
		{
			petting = false;
			menuAnimator.Play("ScoreSlide");
			foreach (ParticleSystem ps in particles)
			{
				ps.Play(false);
			}
			cb.punished = true;
			cb.SetActiveCursor(5);
			buttonwhy.GetComponent<ButtonBehaviour>().ToggleCamera();
			return;
		}
		else if (moodScore > 375)
		{
			moodScore = 375;
		}
		
		if (Input.GetMouseButtonDown(0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitData;
			if(Physics.Raycast(ray, out hitData, 1000) && hitData.transform.tag == "Player")
			{
				canpet = true;
			}
			else
			{
				canpet = false;
			}
		}
		
		if (Input.GetMouseButton(0) && canpet)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitData;
			if(Physics.Raycast(ray, out hitData, 1000) && hitData.transform.tag == "Player")
			{
				Vector2 pixelUV = hitData.textureCoord;
				pixelUV.x *= annoyMap.width;
				pixelUV.y *= annoyMap.height;

				float annoyment = (((0.1f + annoyMap.GetPixel((int)pixelUV.x, (int)pixelUV.y).r * 500f) * 0.1f) - 30f) * Time.deltaTime * - 1;

				moodScore += annoyment;
			}
		}
		
		moodScore += -0.01f * Time.deltaTime * Mathf.Pow(Time.time-startTime, 1.8f);
		moodIndicator.transform.localPosition = new Vector3(moodScore, moodIndicator.transform.localPosition.y, 0.0f);	
		

    }
	
}
