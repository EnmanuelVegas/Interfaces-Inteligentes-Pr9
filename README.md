# Interfaces Inteligentes. Práctica 9: Interfaces multimodales - Sensores

- **Enmanuel Vegas Acosta** (alu0101281698)
- **Práctica 9**: Interfaces multimodales - Sensores

## **Ejercicios propuestos**

_1. Crear una aplicación en Unity que muestre valores de los sensores disponibles en el móvil._

Primeramente, debimos activar todos los sensores presentes en el dispositivo con [este script](./scripts/EnableSensors.cs). Posteriormente, accedemos a los valores de los mismos aplicando [este script](./scripts/SensorsValues.cs) que se muestran en la UI del juego.

Las mediciones en el centro de cálculo son:
![lectura_cc](./images/lectura_cc.png)

Las mediciones en el jardin son:
![lectura_jardin](./images/lectura_jardin.png)

_2. Hacer que el guerrero siempre esté orientado hacia el norte y utilice el acelerómetro para moverse hacia delante y detrás._

[Este script](./scripts/NorthOrientation.cs) permite asegurar que el guerrero se oriente siempre hacia el norte, usando el sensor de campo magnético para ello. Por otro lado, este [otro script](./scripts/Movement.cs) gestiona el movimiento del guerrero con respecto a lo captado por el acelerómetro.

![movimiento_guerrero](./images/movimiento.gif)