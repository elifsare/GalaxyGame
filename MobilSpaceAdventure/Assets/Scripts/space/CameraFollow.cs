using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	
	void Start()
    {
		StartCoroutine(enumerator());
	}

	IEnumerator enumerator()
	{
		yield return new WaitForSeconds(0.02f);

		if (target == null)
		{
			target = GameObject.FindWithTag("Spaceship");
		}
	}

	void LateUpdate()
	{
		if (target == null) 
			return;
		Vector3 desiredPosition = target.transform.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}
}
