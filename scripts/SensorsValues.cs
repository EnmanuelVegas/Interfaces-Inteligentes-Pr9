using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using TMPro;

public class SensorsValues : MonoBehaviour
{
  public TMP_Text output;
  
  void Update()
  {
    string text = "";
    ReadOnlyArray<InputDevice> devices = InputSystem.devices;
    
    foreach(InputDevice device in devices)
    {
      switch (device)
      {
        case Accelerometer accelerometer:
          var accel = accelerometer.acceleration.ReadValue();
          text += $"Accelerometer:\n  -> X:{accel.x:F2}  Y:{accel.y:F2}  Z:{accel.z:F2}\n";
          break;
          
        case UnityEngine.InputSystem.Gyroscope gyroscope:
          var gyro = gyroscope.angularVelocity.ReadValue();
          text += $"Gyroscope:\n  -> X:{gyro.x:F2}  Y:{gyro.y:F2}  Z:{gyro.z:F2}\n";
          break;
          
        case GravitySensor gravitySensor:
          var grav = gravitySensor.gravity.ReadValue();
          text += $"Gravity:\n  -> X:{grav.x:F2}  Y:{grav.y:F2}  Z:{grav.z:F2}\n";
          break;
          
        case AttitudeSensor attitudeSensor:
          var att = attitudeSensor.attitude.ReadValue();
          text += $"Attitude:\n  -> X:{att.x:F2} Y:{att.y:F2} Z:{att.z:F2} W:{att.w:F2}\n";
          break;
          
        case LinearAccelerationSensor linearAccelerationSensor:
          var lin = linearAccelerationSensor.acceleration.ReadValue();
          text += $"Lineal Acceleration:\n  -> X:{lin.x:F2}  Y:{lin.y:F2}  Z:{lin.z:F2}\n";
          break;
          
        case MagneticFieldSensor magneticFieldSensor:
          var mag = magneticFieldSensor.magneticField.ReadValue();
          text += $"Magnetic Field:\n  -> X:{mag.x:F2}  Y:{mag.y:F2}  Z:{mag.z:F2}\n";
          break;
          
        case LightSensor lightSensor:
          text += $"Light: {lightSensor.lightLevel.ReadValue():F2} lux\n";
          break;
          
        case PressureSensor pressureSensor:
          text += $"Pressure: {pressureSensor.atmosphericPressure.ReadValue():F2} hPa\n";
          break;
          
        case ProximitySensor proximitySensor:
          text += $"Proximity: {proximitySensor.distance.ReadValue():F2} cm\n";
          break;
                    
        case StepCounter stepCounter:
          text += $"Step Counter: {stepCounter.stepCounter.ReadValue()}\n";
          break;
      }
    }
    switch (Input.location.status)
    {
      case LocationServiceStatus.Running:
        var location = Input.location.lastData;
        text += $"GPS:\n  -> Lat: {location.latitude:F6}, Lon: {location.longitude:F6}\n  -> Alt: {location.altitude:F2}m\n";
        break;
      case LocationServiceStatus.Initializing:
        text += "GPS: Initializing...\n";
        break;
      case LocationServiceStatus.Failed:
        text += "GPS: Failed to start\n";
        break;
      case LocationServiceStatus.Stopped:
        text += "GPS: Stopped\n";
        break;
    }
    output.text = text;
  }
}