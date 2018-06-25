using System;
using UnityEngine;

public class DriftCamera : MonoBehaviour
{
	[Serializable]
	public class AdvancedOptions
	{
		public bool updateCameraInUpdate;
		public bool updateCameraInFixedUpdate = true;
		public bool updateCameraInLateUpdate;
		public KeyCode switchViewKey = KeyCode.Space;
	}

	public float smoothing = 15f;
	public Transform lookAtTarget;
	public Transform positionTarget;
	public AdvancedOptions advancedOptions;

	bool m_ShowingSideView;

	private void FixedUpdate ()
	{
		if (advancedOptions.updateCameraInFixedUpdate)
			UpdateCamera ();
	}

	private void LateUpdate ()
	{
		if (advancedOptions.updateCameraInLateUpdate)
			UpdateCamera ();
	}

	private void UpdateCamera ()
	{
		transform.position = Vector3.Lerp (transform.position, positionTarget.position, Time.deltaTime * smoothing);
		transform.LookAt (lookAtTarget);
	}
}
