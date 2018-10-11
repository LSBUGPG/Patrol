using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.matrix = Matrix4x4.identity;
		//Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawCube(transform.position, Vector3.one * 2.0f);
		//Gizmos.DrawFrustum(transform.position, 45.0f, 2.0f, 0.5f, 1.0f);
	}
}
