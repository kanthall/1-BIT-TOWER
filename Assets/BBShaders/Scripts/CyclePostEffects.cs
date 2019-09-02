using UnityEngine;

public class CyclePostEffects : MonoBehaviour
{
	public PostEffect postEffect;

	public Material[] materials;
	
	private float timer = 0f;
	private int counter = 0;


	void Start()
	{
	timer = 0f;
	counter = 0;	
	postEffect.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		timer += Time.deltaTime;

		if (timer > 5f)
		{

			if (counter == 0)
			{
				postEffect.enabled = false;
				timer = 0f;
			}
			else
			{
				postEffect.enabled = true;
				postEffect.mat = materials[counter];

				timer = 0f;
			}
			
			counter++;

			if (counter == 4)
			{
				counter = 0;
			}
		}

	}
}
