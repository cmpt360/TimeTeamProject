using UnityEngine;
using System.Collections;

public static class CustomFunctions {
	// Sets the velocity of the RigidBody2D
	public static void SetVel(Rigidbody2D rBody, float velocity) {
		rBody.velocity = new Vector2 (Mathf.Cos (rBody.rotation * Mathf.Deg2Rad), Mathf.Sin (rBody.rotation * Mathf.Deg2Rad)) * velocity;
	}

	// Stops all movement and rotation in the RigidBody2D
	public static void Stop(Rigidbody2D rBody) {
		rBody.velocity = new Vector2 (0f,0f);
		rBody.angularVelocity = 0f;
	}	
}
