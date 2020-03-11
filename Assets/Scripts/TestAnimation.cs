using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
	public float timer_delay = 10;
	private float timer = 0;
	bool is_idle = false;
	Animator ani;
	// Start is called before the first frame update
	void Start()
	{
		ani = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		
		if (timer > timer_delay)
		{
			is_idle = !is_idle;
			timer = 0;
			if (is_idle)
			{
				ani.SetTrigger("runTransition");
			}
			else if (!is_idle)
			{
				ani.SetTrigger("idleTransition");
			}
		}
	}
}
