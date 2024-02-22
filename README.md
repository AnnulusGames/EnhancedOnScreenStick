# Enhanced On-Screen Stick
 Provides an advanced virtual joystick compatible with Unity Input System/uGUI.

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/header.png" width="800">

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)
![unity-version](https://img.shields.io/badge/unity-2020.1+-000.svg)
[![releases](https://img.shields.io/github/release/AnnulusGames/EnhancedOnScreenStick.svg)](https://github.com/AnnulusGames/EnhancedOnScreenStick/releases)

[日本語版READMEはこちら](README_JA.md)

Enhanced On-Screen Stick is a library that provides a highly functional virtual stick compatible with Unity's Input System. It simulates joystick input on touch devices such as mobile using Unity's Input System [On-screen Controls](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.7/manual/OnScreen.html). It also allows advanced customization such as touch position tracking, dead zones, and adjustable operational areas.

## Setup

### Requirements

* Unity 2020.1 or later
* Input System 1.0.0 or later

### Installation

1. Open the Package Manager from Window > Package Manager.
2. Click the "+" button > Add package from git URL.
3. Enter the following URL:

```
https://github.com/AnnulusGames/EnhancedOnScreenStick.git?path=Assets/EnhancedOnScreenStick
```

Alternatively, open Packages/manifest.json and add the following to the dependencies block:

```json
{
    "dependencies": {
        "com.annulusgames.enhanced-on-screen-stick": "https://github.com/AnnulusGames/EnhancedOnScreenStick.git?path=Assets/EnhancedOnScreenStick"
    }
}
```

## Quick Start

By integrating Enhanced On-Screen Stick, you can create a virtual stick from `Create > Enhanced On-Screen Controls > On-Screen Stick`.

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/img-create-menu.png" width="500">

Once created, place it on the Canvas and adjust its size and appearance. The RectTransform range of the object with the attached components will become the operable area.

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/img-scene-view.png" width="600">

Next, set the Control Path from the Inspector. This allows you to simulate input from any device.

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/img-inspector.png" width="600">

Setup is now complete. You can process input using the Input System as usual. Below is a sample of using Enhanced On-Screen Stick and InputAction for movement processing.

```cs
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] InputAction inputAction;
    [SerializeField] float movementSpeed = 5f;

    void Start()
    {
        inputAction.Enable();
    }

    void Update()
    {
        transform.position += movementSpeed * Time.deltaTime * (Vector3)inputAction.ReadValue<Vector2>();
    }
}
```

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/img-sample-1.gif" width="800">

## Customization

### Object Configuration

`Enhanced On-Screen Stick` consists of the following objects:

```
- Enhanced On-Screen Stick
  - Background
    - Handle
```

Attach the `Enhanced On-Screen Stick` component to the top-level object and attach some kind of Graphic component (such as Image) so that touch events can be detected. The RectTransform of this object will become the operable area for the stick.

Background and Handle are objects for visually representing the position of the stick. You can freely change their size and appearance, but Handle must be a child of Background.

### StickType

StickType allows you to change the behavior when the stick is manipulated.

| StickType | Description |
| - | - |
| Fixed     | The stick is always fixed to its initial position. |
| Floating  | The stick moves to the touched position and remains fixed there until the drag ends. |
| Dynamic   | The stick moves to the touched position and follows the drag movement. |

### Other Settings

| Property | Description |
| - | - |
| Movement Range | Specifies the distance from the center of the Handle for movement. |
| Dead Zone | Sets the threshold for input from 0 to 1. Input values below the Dead Zone are corrected to 0. |
| Show Only When Pressed | If true, Background and Handle are inactive when not touched. |

## License

[MIT License](LICENSE)