using UnityEngine;
using UnityEngine.InputSystem;

public class NorthOrientation : MonoBehaviour
{
  private float rotationSpeed = 3f;
  
  void Update()
  {
    if (MagneticFieldSensor.current != null)
    {
      Vector3 north = MagneticFieldSensor.current.magneticField.ReadValue();

      Quaternion lookNorth = Quaternion.LookRotation(new Vector3(-north.x, 0, north.y));

      transform.rotation = Quaternion.Slerp(
        transform.rotation,
        lookNorth,
        rotationSpeed * Time.deltaTime
      );
    }
  }
}