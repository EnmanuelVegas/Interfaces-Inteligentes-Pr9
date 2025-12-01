using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using TMPro;

public class EnableSensors : MonoBehaviour
{
  void OnEnable()
  {
    ReadOnlyArray<InputDevice> devices = InputSystem.devices;
    foreach (InputDevice device in devices)
    {
      if (device is Sensor sensor && !sensor.enabled)
      {
        InputSystem.EnableDevice(device);
      }
    }
    if (!Input.location.isEnabledByUser)
    {
      Input.location.Start();
    }
  }

  void OnDisable()
  {
    ReadOnlyArray<InputDevice> devices = InputSystem.devices;
    foreach (InputDevice device in devices)
    {
      if (device is Sensor sensor && sensor.enabled)
      {
        InputSystem.DisableDevice(device);
      }
    }
    if (Input.location.status == LocationServiceStatus.Running)
    {
      Input.location.Stop();
    }
  }
}