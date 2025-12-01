using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
  [Header("Movement Settings")]
  public float accelerationMultiplier = 0.4f;
  private Vector3 velocity = Vector3.zero;

  [Header("GPS Boundaries")]
  public float maxLatitudeDiff = 0.001f;
  public float maxLongitudeDiff = 0.001f;

  private bool isInBounds = true;
  private LocationInfo initialLocation;

  void Start()
  {
    if (Input.location.status == LocationServiceStatus.Running)
    {
      initialLocation = Input.location.lastData;
    }
  }

  void Update()
  {
    CheckGPSBounds();
    if (isInBounds)
    {
      MoveWithAccelerometer();
    }
    else
    {
      StopMovement();
    }
    transform.position += velocity * Time.deltaTime;
  }

  void CheckGPSBounds()
  {
    if (Input.location.status == LocationServiceStatus.Running)
    {
      var location = Input.location.lastData;
      isInBounds = Mathf.Abs(location.latitude - initialLocation.latitude) <= maxLatitudeDiff &&
                   Mathf.Abs(location.longitude - initialLocation.longitude) <= maxLatitudeDiff;
    }
  }

  void StopMovement()
  {
    velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * 5f);
  }

  void MoveWithAccelerometer()
  {
    if (Accelerometer.current != null)
    {
      Vector3 accel = Accelerometer.current.acceleration.ReadValue();
      Vector3 localMovement = new Vector3(0, 0, -accel.z);
      if (Mathf.Abs(localMovement.z) >= 0.2f)
      {
        Vector3 worldMovement = transform.TransformDirection(localMovement);
        velocity += worldMovement * accelerationMultiplier * Time.deltaTime;
        velocity *= 0.95f;
      }
      else
      {
        velocity *= 0.9f;
      }
    }
  }
}