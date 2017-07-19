title: Lunch & Learn: Unity to Arduino
class: animation-fade
layout: true

<!-- This slide will serve as the base layout for all your slides -->
.bottom-bar[
  {{title}}
]

---

class: middle, center, impact

# Lunch & Learn

## Unity to Arduino

---

## Goal
Create an Unity scene that changes the lighting of the scene according to brightness values from a photocell attached to an Arduino, and triggers an LED to flash when a target is hit within the scene.

---

## 0. Getting Started

### Goals

- Inventory
- Introduce Unity
- Introduce Arduino

---

#### Required Parts

1. [Arduino Nano (From Elegoo)](https://smile.amazon.com/dp/B0713XK923/ref=cm_sw_r_cp_dp_T1_KBMBzbMMASFV6)
1. LED
1. photocell
1. 150 Ω Resistor
1. 10K Ω Resistor
1. Mini Breadboard

---

#### Get the Project Files

1. Download the files from: []()
1. Unzip the package

---

#### Set up the Unity Project

1. Open Unity
1. Create a new Project
1. Explore all the tabs/panels
1. Create new folders within the **Project** panel for **Scenes**, **Scripts**, **Prefabs**, and **Materials**
1. Save the current scene into the **Scenes** folder

---

#### Install the Arduino Driver

1. Unzip the `CH340Driver.zip`
1. Install the driver for your OS
1. Restart your computer

---

#### Test your Arduino

1. Open Arduino IDE
1. Plug your Ardino Nano into your computer
1. Watch the LED next to the *L* on the board blink
1. Change the Board type to **Arduino Nano** under `Tools > Board`
1. Change the Port to the board's port under `Tools > Port`. It should look like **COM4** on Windows, or **/dev/cu.wchusbserial20** on OSX.

---

1. Open `File > Examples > 01.Basics > AnalogReadSerial`
1. Upload it to the Arduino
1. Open the Serial Monitor
1. Watch the noise scroll in

---

## 1. Shooting

### Goals

- Create dude with gun
- Create target
- Shoot gun at target and check for collisions

---

#### Move the Camera

1. Select the *Main Camera* in the hierarchy
1. Set *Main Camera*'s **Position** to (10.0, 5.0, 5.0)
1. Set *Main Camera*'s **Rotation** to (30, -90, 0)

---

#### Make the Player GameObject

1. Create a new Capsule primitive GameObject
1. Rename the new GameObject to "*Player*"

---

#### Make the Visor

1. Create a new Cube primitive GameObject as a child of *Player*
1. Rename the new GameObject to "*Visor*"
1. Set *Visor*'s **Scale** to (0.95, 0.25, 0.5)
1. Set *Visor*'s **Position** to (0.0, 0.5, 0.24)
1. Create a new Material within the **Materials** folder and name it "*Black*"
1. Change the **Albedo** color of *Black* to black
1. Set *Visor*'s **Material** to *Black*
1. Create a new Cylinder primitive as a child of *Player*

---

#### Make the Gun

1. Rename the new GameObject to "*Gun*"
1. Remove the **Capsule Collider** from *Gun*
1. Set *Gun*'s **Position** to (0.5, 0.0, 0.5)
1. Set *Gun*'s **Rotation** to (90.0, 0.0, 0.0)
1. Set *Gun*'s **Scale** to (0.25, 0.5, 0.25)
1. Set *Gun*'s **Material** to *Black*

---

#### Make the Bullet Spawner

1. Create a new empty GameObject
1. Rename the new GameObject to *Bullet Spawn*
1. Set *Bullet Spawn*'s **Position** to (0.5, 0.0, 1.0)

---

#### Make the Bullet Prefab

1. Create a new Sphere primitive GameObject
1. Rename the Sphere GameObject "*Bullet*"
1. Change *Bullet*'s **Scale** to (0.2, 0.2, 0.2)
1. Find and add the component: **Physics > Rigidbody** to *Bullet*
1. On *Bullet*'s **Rigidbody** component, set the **Use Gravity** checkbox to **false**
1. Drag *Bullet* into the **Prefabs** folder to turn it into a Prefab asset
1. Delete *Bullet* from the **Hierarchy**

---

#### Make the Target GameObject

1. Create a new Cube primitive GameObject
1. Rename the new GameObject to "*Target*"
1. Set *Target*'s **Position** to (0.0, 0.0, 10.0)
1. Set *Target*'s **Scale** to (5.0, 5.0, 0.1)
1. Set *Target*'s **Material** to *Black*
1. Give the *Target* a new **Rigidbody** component
1. Under **Contraints**, check **Freeze Position** X, Y, and Z, and **Freeze Rotation** X and Z

---

#### Make the Player Controller

1. Drag the `PlayerController.cs` script from the downloaded Project Files into the **Scripts** folder within Unity
1. Drag the `PlayerController` script onto *Player*
1. Drag *Bullet Spawn* into the **Player Controller (Script)** component, into the **Bullet Spawn** variable box
1. Do the same for the *Bullet* prefab
1. Play the scene to test it all!

---

#### Create Bullet Collisions

1. Drag the `TargetController.cs` script from the Project Files into the **Scripts** folder within Unity
1. Drag the `BulletController` script onto *Target*
1. Play the scene again, and watch as the *Target* changes color when you hit it!

---

## 2. Let's Talk

### Goals

- Get Unity to support talking over Serial
- Do the same for Arduino

---

#### Get Set Up
1. In Unity, go to **Edit > Player Settings**
1. Change the `Api Compatability Level` to `.NET 2.0`
1. Save the Unity Project and Scene
1. Unzip the `ArduinoSerialCommand-master.zip` from the Project Files, and place it within `C:\Users\<username>\Documents\Arduino\` on Windows, or `/Users/<username>/Documents/Arduino/` on OSX
1. Restart the Arduino IDE
1. Check to make sure the library was correctly added, by looking under **File > Sketchbook > SerialCommand**

---

1. Drag the `ArduinoManager.cs` script from the downloaded Project Files into the **Scripts** folder within Unity
1. Create a new GameObject named *Arduino Manager* and attach the `ArduinoManager` script to it
1. Set the **Port** on the new **ArduinoManager** component to the same port you found for your Arduino at the beginning of the workshop

---

1. Create a new folder at the root of your Unity project called `Arduino`
1. Copy the `unity2arduino` folder from the Project Files into that folder
1. Open the file within that folder in the Arduino IDE


---

## 3. Blink

### Goals

- Create circuit for LED
- Make Arduino blink when target is hit

---

#### Make it happen
1. Connect the LED and 150 Ω resistor to the Arduino like this: .center[![diagram](images/photocell.png)]

---

1. Drag the *Arduino Manager* to the **Arduino Manager** variable box in *Target*
1. Play the scene again, and watch as the LED lights up when you hit the target!

---

## 4. Read a Sensor

### Goals

- Create circuit for photocell
- Allow the sensor to control something in the scene

---

#### Make it happen
1. Connect the photocell and 10K Ω like this: .center[![diagram](images/led.png)]

---

1. Drag the *Directional Light* to the **Light** variable box in *Arduino Manager*
1. Play the scene again, and watch as the scene lighting changes as you block, unblock, and light up the photocell!