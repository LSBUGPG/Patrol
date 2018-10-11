using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawFrustum(Vector3.zero, 90.0f, 10.0f, 0.5f, 1.0f);
	}

    void Update()
    {
        
    }
}
