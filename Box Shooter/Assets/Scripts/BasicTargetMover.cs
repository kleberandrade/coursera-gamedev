using UnityEngine;

public class BasicTargetMover : MonoBehaviour
{
    // define the possible states through an enumeration
    public enum MotionDirection
    {
        Spin,
        Horizontal,
        Vertical
    };

    // store the state
    public MotionDirection motionState = MotionDirection.Horizontal;

    // motion parameters
    public float spinSpeed = 180.0f;
    public float motionMagnitude = 0.1f;

    // reference to transform of the gameObject
    private Transform m_Transform;

	private void Awake ()
    {
        m_Transform = GetComponent<Transform>();
	}

    private void Update ()
    {
        switch (motionState)
        {
            case MotionDirection.Spin:
                // rotate around the up axis of the gameObject
                m_Transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
                break;

            case MotionDirection.Horizontal:
                // move left and right over time
                m_Transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;

            case MotionDirection.Vertical:
                // move up and down over time
                m_Transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
        }
	}
}
