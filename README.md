# Real-Time XR Command Suite  
*Immersive Alert & Monitoring System*

## Overview  
The **Real-Time XR Command Suite** is a cutting-edge surveillance system developed in Unity for **military operations**. It leverages **UDP networking** for real-time communication and monitoring of operator conditions via **EOG** (electrooculography) and **blink rate** data. The system is designed to enhance operational readiness by providing critical visual and auditory feedback for operators, ensuring that they remain alert and focused during extended mission durations.

## Features  
1. **Real-Time Monitoring**:  
   - Utilizes **UDP networking** to stream EOG and blink rate data to monitor the operator's condition.  
   - Displays real-time notifications for eye redness, headache, and seizure risks based on operator data.
  
2. **Adaptive Alerts**:  
   - Alerts are triggered based on real-time data and can be enabled/disabled using manual controls.  
   - Visual feedback includes **Field of View (FOV) adjustments** and **thermal tint overlays** activated under "slow" conditions to enhance the operator's focus.  
   
3. **FOV Adjustment for Mission Optimization**:  
   - In **"slow"** or **"abnormal"** status, the **FOV narrows from 60 to 40** gradually, providing the operator with a focused view to reduce distractions and improve performance.  
   
4. **Interactive Control Panel**:  
   - Provides intuitive controls for managing **FOV**, **warmth tint**, and **alert status**.  
   - A dedicated UI updates operator status and shows current condition feedback (e.g., "Alert ON", "Warm Tint: OFF", etc.).

## Technologies Used  
- **Unity** (Game Engine)  
- **C#** (Programming Language)  
- **UDP Networking** (For real-time data transfer)  
- **TextMeshPro** (For UI text rendering)  
- **AudioSource** (For alert sounds)  
- **Custom Shader Effects** (For thermal tint overlays)

## How It Works  
- **EOG and Blink Rate Data**: Operator data is collected using EOG and blink rate sensors, transmitted via **UDP** to the Unity application.  
- **Alert System**: Alerts are triggered based on predefined thresholds (eye redness, headache, seizure), with real-time updates shown on a customizable UI.  
- **Field of View (FOV) Adjustments**: When the operator's condition is "slow" or "abnormal", the FOV narrows gradually to aid focus, ensuring improved situational awareness.  
- **Manual Overrides**: The operator can enable/disable alerts, adjust FOV, and modify the thermal tint via intuitive keyboard controls (A, F, T keys).

## Usage  
1. **Start the System**: Launch the Unity application and ensure that the UDP receiver is connected to the EOG and blink rate sensors.
2. **Monitor Conditions**: Observe the operator's condition status and receive alerts for any issues such as eye redness or headaches.
3. **Adjust Settings**: Use the keyboard controls to toggle the alert system, adjust FOV, or enable/disable warmth tint.
4. **Respond to Alerts**: Follow the visual feedback and auditory cues to take necessary actions based on the operator's condition.

## Controls  
- **A**: Toggle Alert System ON/OFF (Works in "slow" status, shows UI in other statuses).  
- **F**: Toggle Field of View (FOV) feature.  
- **T**: Toggle Warm Tint feature.  
- **N**: Enable Alerts.  
- **M**: Disable Alerts.  

## Installation  
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/real-time-xr-command-suite.git
