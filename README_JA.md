# Enhanced On-Screen Stick
 Provides an advanced virtual joystick compatible with Unity Input System/uGUI.

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/header.png" width="800">

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)
![unity-version](https://img.shields.io/badge/unity-2020.1+-000.svg)
[![releases](https://img.shields.io/github/release/AnnulusGames/EnhancedOnScreenStick.svg)](https://github.com/AnnulusGames/EnhancedOnScreenStick/releases)

[English README is here.](README.md)

Enhanced On-Screen Stickは、UnityのInput Systemに対応した高機能な仮想スティックを提供するライブラリです。Input Systemの[On-screen Controls](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.7/manual/OnScreen.html)を用いて、モバイルなどのタッチデバイス上でジョイスティックの入力をシミュレートします。また、タッチ位置の追従やデッドゾーン、操作可能な領域の設定などの高度なカスタマイズも可能となっています。

## セットアップ

### 要件

* Unity 2020.1 以上
* Input System 1.0.0 以上

### インストール

1. Window > Package ManagerからPackage Managerを開く
2. 「+」ボタン > Add package from git URL
3. 以下のURLを入力する

```
https://github.com/AnnulusGames/EnhancedOnScreenStick.git?path=Assets/EnhancedOnScreenStick
```

またはPackages/manifest.jsonを開き、dependenciesブロックに以下を追記

```json
{
    "dependencies": {
        "com.annulusgames.enhanced-on-screen-stick": "https://github.com/AnnulusGames/EnhancedOnScreenStick.git?path=Assets/EnhancedOnScreenStick"
    }
}
```

## クイックスタート

Enhanced On-Screen Stickを導入することで、`Create > Enhanced On-Screen Controls > On-Screen Stick`から仮想スティックを作成可能になります。

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/img-create-menu.png" width="500">

作成したらCanvas上に配置し大きさや見た目を調整しましょう。コンポーネントがアタッチされているオブジェクトのRectTransformの範囲が操作可能な領域になります。

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/img-scene-view.png" width="600">

次にInspectorからControl Pathの設定を行います。これを設定することで任意のデバイスの入力をシミュレートすることが可能です。

<img src="https://github.com/AnnulusGames/EnhancedOnScreenStick/blob/main/docs/images/img-inspector.png" width="600">

以上でセットアップは完了です。後は通常通りInput Systemを用いて入力を処理することが可能になります。以下はEnhanced On-Screen StickとInputActionを用いて移動の処理を行うサンプルです。

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

## カスタマイズ

### オブジェクトの構成

`Enhanced On-Screen Stick`は以下のオブジェクトで構成されます。

```
- Enhanced On-Screen Stick
  - Background
    - Handle
```

最上位のオブジェクトに`Enhanced On-Screen Stick`コンポーネントと、タッチイベントを検知できるように何らかのGraphicコンポーネント(Imageなど)をアタッチします。このオブジェクトのRectがそのままスティックを操作可能な領域になります。

Background、Handleはスティックの位置を視覚的に表現するためのオブジェクトです。サイズや見た目は自由に変更できますが、HandleはBackgroundの子オブジェクトである必要があります。

### StickType

StickTypeからスティックが操作された時の動作を変更できます。

| StickType | 説明 |
| - | - |
| Fixed | スティックは常に最初の位置に固定されます。 |
| Floating | スティックはタッチされた位置に移動し、ドラッグが終了するまでその位置に固定されます。 |
| Dynamic | スティックはタッチされた位置に移動し、ドラッグの動きに追従します。 |

### その他の設定

| プロパティ | 説明 |
| - | - |
| Movement Range | Handleの中心からの移動距離を指定します。 |
| Dead Zone | 0〜1の値で入力の閾値を指定します。Dead Zone以下の入力値は0に補正されます。 |
| Show Only When Pressed | これがtrueの場合、タッチされていない間はBackgroundとHandleが非アクティブになります。 |

## ライセンス

[MIT License](LICENSE)