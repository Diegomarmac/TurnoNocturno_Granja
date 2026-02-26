# Turno Nocturno: La Granja 🌽🌑

![Unity](https://img.shields.io/badge/Unity-2022.3+-black?style=for-the-badge&logo=unity)

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

![ZBrush](https://img.shields.io/badge/ZBrush-000000?style=for-the-badge&logo=zbrush&logoColor=white)

![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Turno Nocturno: La Granja** es un MVP (*Minimum Viable Product*) de terror folclórico mexicano desarrollado como proyecto final para el Diplomado de Desarrollo de Videojuegos. El proyecto destaca por la integración de un pipeline artístico de alta fidelidad y una arquitectura de software modular y escalable.

---

## 📖 Resumen del Proyecto
Ambientado en el México rural de los años 90, el jugador toma el rol de un guardia de seguridad novato en su primer turno nocturno. Sin armas y con recursos limitados, debe sobrevivir mientras una entidad acecha desde las sombras. El juego explora la **vulnerabilidad** y la **asimetría de poder** a través de una atmósfera inspirada en el cine de serie B mexicano.

## 🛠️ Stack Tecnológico
* **Engine:** Unity (URP - Universal Render Pipeline).
* **Programación:** C# desarrollado en **JetBrains Rider**.
* **Arte 3D:** ZBrush (Esculpido), Blender (Retopología), Substance Painter (Texturizado PBR).
* **Audio:** Audacity (Procesamiento de audio orgánico y diegético).

---

## 🏗️ Arquitectura y Mecánicas (Vista Técnica)
El proyecto prioriza un código limpio para evitar la deuda técnica y permitir la escalabilidad:

* **Sistema de Interacción Desacoplado:** Implementación de la interfaz `IInteractable`. Permite gestionar notas, puertas y transformadores sin dependencias rígidas ni uso excesivo de *tags*.
* **Arquitectura Data-Driven:** Uso de **Scriptable Objects** para el sistema de inventario y narrativa, facilitando cambios de diseño sin modificar el código base.
* **Visual Signposting:** Uso de materiales emisivos y Shaders personalizados para guiar al jugador y delimitar el área de juego de forma narrativa.
* **Audio Inmersivo:** Diseño sonoro basado en audio diegético para la detección de amenazas, utilizando sonidos orgánicos procesados (ronquidos de perro editados).

## 🎨 Pipeline de Arte 3D
El 90% de los assets son de autoría propia, siguiendo un flujo de trabajo profesional de alta fidelidad:
1.  **High Poly:** Esculpido de detalle orgánico en **ZBrush**.
2.  **Low Poly:** Retopología optimizada en **Blender** para el ejecutable final.
3.  **Baking & Texturing:** Creación de mapas PBR en **Substance Painter**.

---

## 👤 Autor
**Diego Mtz**
* *Project Manager de IA | Artista 3D | Desarrollador de Videojuegos*
