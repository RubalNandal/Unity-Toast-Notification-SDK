# Toast Notification Unity SDK

A lightweight Unity **Package (SDK)** that provides a **clickable GameObject**
to show Toast / Snackbar-style notifications with clean platform abstraction.

---

## 1. Installation

### Unity Package Manager (Recommended)

1. Open Unity Editor
2. Go to **Window > Package Manager**
3. Click the **+** button in the top-left corner
4. Select **Add package from git URL**
5. Paste the Git URL: `https://github.com/RubalNandal/Unity-Toast-Notification-SDK.git`
6. Click **Add**



## 2. How to Use

### Option A — GameObject 
1. Install the package via Unity Package Manager 
2. Import the sample from `Samples`
3. Drag `ToastButton.prefab` into the scene
4. Play and click the GameObject

**Result**
- Editor → Console log
- Android → Native Android Toast

---

### Option B — Public API

```csharp
using ToastSDK;

ToastNotifier.Show("Hello from Toast SDK");
```

No scene setup required.

---


## 3. File Structure

```
Runtime/
├── Core/
│   ├── IToastService.cs        // Internal toast contract
│   ├── ToastService.cs         // Platform resolver (internal)
│   └── ToastNotifier.cs        // Public SDK API
│
├── Platform/
│   ├── Android/
│   │   └── AndroidToastService.cs // Native Android Toast
│   ├── Editor/
│   │   └── EditorToastService.cs  // Editor fallback
│   └── Fallback/
│       └── UnityToastService.cs   // Non-native fallback (iOS)
│
├── UI/
│   └── ToastGameObject.cs      // Clickable GameObject logic
│
├── AssemblyInfo.cs              // Grants InternalsVisibleTo for test assembly
└── ToastSDK.Runtime.asmdef     // Runtime assembly definition
```

```
Tests/
└── Runtime/
    ├── Core/
    │   └── ToastNotifierTests.cs   // Public API safety tests
    │   └── ToastServiceTests.cs  // Tests internal service resolution logic
    ├── UI/
    │   └── ToastGameObjectTests.cs // Tests GameObject click behavior
    └── ToastSDK.Tests.asmdef       // Test assembly
```

```
Samples/
└── Toast Sample/
    └── ToastButton.prefab      // Ready-to-use GameObject
```

---

## 4. Architecture

```
GameObject Click
      ↓
ToastGameObject
      ↓
ToastNotifier (Public API)
      ↓
ToastService (Resolver)
      ↓
IToastService
      ↓
Platform Implementation
```

### Design Highlights
- Minimal public API
- Platform logic fully encapsulated
- Stateless services
- Assembly-based isolation
- No scene dependency

---

## 5. Platform Support

| Platform | Behavior |
|--------|----------|
| Android | Native Android Toast |
| iOS | Debug log |
| Editor | Debug log |

> iOS does not provide a native Toast API.
> The SDK degrades gracefully without native plugins.

---

## 6. Testing

- Unity Test Framework 
- Tests focus on:
  - Public API safety
  - GameObject interaction
- Native OS rendering is verified via device testing


---

## Author

Rubal Nandal
