using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 directionOffset;
    [SerializeField] private float lenght;

    private Ball ball;
    private Beam beam;
    private Vector3 cameraPosition;
    private Vector3 minimumBallPosition;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        beam = FindObjectOfType<Beam>();

        cameraPosition = ball.transform.position;
        minimumBallPosition = ball.transform.position;

        TrackBall();
    }
    private void Update()
    {
        if (ball.transform.position.y < minimumBallPosition.y)
        {
            TrackBall();
            minimumBallPosition = ball.transform.position;
        }
    }

    private void TrackBall()
    {
        cameraPosition = ball.transform.position;
        Vector3 direction = (beam.transform.position - ball.transform.position).normalized + directionOffset;
        cameraPosition -= direction * lenght;
        transform.position = cameraPosition;
        transform.LookAt(ball.transform);
    }
}
