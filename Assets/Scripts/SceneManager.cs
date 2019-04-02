using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
	public Transform InputParent;
	public Transform InputChild11;
	public Transform InputChild7;
	public FunnelController funnelController;

	// Start is called before the first frame update
	void Start()
    {
		StartCoroutine(translateFunnelTo(InputChild11));
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public IEnumerator translateFunnelTo(Transform location, int stayForSecond = 5)
	{
		funnelController.translateTo(location);
		yield return new WaitForSeconds(5);
		funnelController.resetPosition();

	}
}
