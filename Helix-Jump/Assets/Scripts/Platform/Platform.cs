using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float bounceForce = 50f;
    [SerializeField] private float bounceRadius = 50f;

    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in platformSegments)
        {
            segment.Bounce(bounceForce, transform.position, bounceRadius);
        }
    }
}
