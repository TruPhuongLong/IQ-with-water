using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleController : MonoBehaviour
{

	public enum Contain
	{
		none = 0,
		infinity = 100,
		eleven = 11,
		seven = 7
	}

	public Contain volumetricSource;

	public float realyVolumetricSource;

	BottleController target;

	bool isCollider;

	Vector3 start;

	public GameObject liquid = null;

	public SceneManager sceneManager;

	private void Start()
	{
		
	}


	private void Update()
	{
		//var _y = unit * (int)realyVolumetricSource;
		//var realWater = transform.GetChild(0).GetComponent<RectTransform>();
		//realWater.sizeDelta = new Vector2(realWater.sizeDelta.x, _y);
	}


	private void OnMouseDown()
	{
		if (liquid != null)
		{
			liquid.transform.parent = transform;
		}
		start = transform.position;
	}
	private void OnMouseUp()
	{
		if (isCollider)
		{
			// allow water fall
			if (target.realyVolumetricSource < (float)target.volumetricSource)
			{
				var deltaTarget = (float)target.volumetricSource - target.realyVolumetricSource;
				var trans = Mathf.Min(deltaTarget, realyVolumetricSource);

				//set realy volumetric for both source and target:
				target.realyVolumetricSource += trans;
				realyVolumetricSource -= trans;

				print("===" + target.transform.parent);
				
				StartCoroutine(sceneManager.translateFunnelTo(target.transform.parent));
				//transform.parent.Rotate();
			}
		}

		// location back:
		transform.position = start;
		if (liquid != null)
		{
			liquid.transform.parent = null;
		}
	}
	void OnMouseDrag()
	{
		float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
		transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "bgCollider")
		{
			isCollider = true;
			target = collision.GetComponent<BottleController>();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "bgCollider")
		{
			isCollider = false;
		}
	}

}
