# A.O.F. Refactor - Project Structure

## Overview
A.O.F. Refactor là một dự án Unity sử dụng kiến trúc hệ thống module hóa (Systems Architecture). Dự án tổ chức theo các hệ thống độc lập nhưng có thể giao tiếp với nhau.

---

## 📁 Project Root Structure

```
A.O.F.refactor/
├── A.O.F.refactor.sln                    # Solution file (C# project)
├── A.O.F.refactor.slnx                   # Solution extension file
├── Assembly-CSharp.csproj                # Main assembly project
├── Assembly-CSharp-Editor.csproj         # Editor assembly project
│
├── 📂 Assets/                            # Unity Assets folder (main game content)
├── 📂 Library/                           # Unity engine cache & compiled data
├── 📂 Logs/                              # Application logs
├── 📂 obj/                               # Build output objects
├── 📂 Packages/                          # Package dependencies
├── 📂 ProjectSettings/                   # Unity project settings
├── 📂 Temp/                              # Temporary files
└── 📂 UserSettings/                      # User-specific settings
```

---

## 📂 Assets Folder Structure

### Main Directories

```
Assets/
├── Designer System.docx                  # Design documentation
├── _Recovery/                            # Recovery/backup files
│
├── 📂 Packages/                          # Local packages (if any)
├── 📂 Resources/                         # Empty - for additional resources
├── 📂 Settings/                          # Project settings & configurations
│
└── 📂 UnityProject/                      # Main game code & systems
    ├── Attack System/                    # Attack/damage system
    ├── Audio System/                     # Audio & music management
    ├── Character System/                 # Character data & management
    ├── Player System/                    # Player input & control
    ├── Skill System/                     # Skill definitions & mechanics
    ├── UI System/                        # User interface
    └── _Scene System/                    # Scene management
```

---

## 🎮 Game Systems Breakdown

### 1. **Attack System** (`Assets/UnityProject/Attack System/`)
Quản lý hệ thống tấn công của trò chơi.

```
Attack System/
└── Bullet/
    ├── [Bullet scripts & prefabs]
    └── [Bullet mechanics]
```

**Chức năng:**
- Xử lý logic đạn
- Collision detection
- Damage calculation

---

### 2. **Audio System** (`Assets/UnityProject/Audio System/`)
Quản lý âm thanh và nhạc nền của trò chơi.

```
Audio System/
├── Boom Bap Flick - Quincas Moreira.mp3  # Background music
├── MusicManager.cs                       # Audio management script
```

**Chức năng:**
- Phát nhạc nền
- Quản lý âm thanh hiệu ứng
- Control volume

---

### 3. **Character System** (`Assets/UnityProject/Character System/`)
Quản lý dữ liệu và hành vi của các nhân vật.

```
Character System/
├── Character1/
├── Character2/
├── Character3/
├── Character4/
├── Character5/
├── Character6/
├── Character7/
├── Character8/
├── Character9/
├── Character10/
│   ├── [Character-specific scripts]
│   ├── [Character prefabs]
│   └── [Character animations/sprites]
│
└── _DataHandler/
    ├── [Character data scripts]
    └── [Character stat management]
```

**Chức năng:**
- Lưu trữ dữ liệu 10 nhân vật khác nhau
- Quản lý stats (HP, mana, speed, damage, v.v.)
- Xử lý character initialization

---

### 4. **Player System** (`Assets/UnityProject/Player System/`)
Quản lý Player input và điều khiển nhân vật Player.

```
Player System/
├── PlayerController.cs                   # Main player control script
├── SkillController.cs                    # Player skill activation
├── PlayerPrefab.prefab                   # Player game object prefab
```

**Chức năng:**
- Xử lý input từ bàn phím/controller
- Di chuyển player
- Tương tác với skill system
- Player state management

---

### 5. **Skill System** (`Assets/UnityProject/Skill System/`)
Quản lý kỹ năng và cơ chế chiến đấu.

```
Skill System/
├── Dash/
│   ├── [Dash skill scripts]
│   └── [Dash effects/animations]
│
├── Radial Shot/
│   ├── [Radial Shot skill scripts]
│   └── [Radial Shot effects]
│
├── Shield/
│   ├── [Shield skill scripts]
│   └── [Shield mechanics]
│
└── _SkillDataHandler/
    ├── [Skill data management]
    ├── [Skill stat storage]
    └── [Skill activation logic]
```

**Chức năng:**
- Định nghĩa 3 kỹ năng chính: Dash, Radial Shot, Shield
- Quản lý cooldown kỹ năng
- Tính toán damage/effect của kỹ năng
- Skill upgrade system

---

### 6. **UI System** (`Assets/UnityProject/UI System/`)
Quản lý giao diện người dùng.

```
UI System/
├── ChooseCharacter Anim UI/
│   ├── [Character selection UI scripts]
│   └── [Selection animations]
│
├── UI_Prefabs/
│   ├── [Reusable UI element prefabs]
│   ├── [Buttons, panels, displays]
│   └── [Dialog windows]
│
├── UI_Sprites/
│   ├── [UI button sprites]
│   ├── [Icons]
│   └── [Background images]
│
└── _UI_Handler/
    ├── [Main UI manager script]
    ├── [Screen transitions]
    └── [UI event handling]
```

**Chức năng:**
- Hiển thị menu chính
- Character selection screen
- HUD (Health, Mana, Skills)
- Game over/Win screens

---

### 7. **Scene System** (`Assets/UnityProject/_Scene System/`)
Quản lý cảnh (scenes) trong trò chơi.

```
_Scene System/
├── MainMenu.unity                        # Main menu scene
├── TestUI.unity                          # UI testing scene
├── WinGame.unity                         # Victory scene
├── World.unity                           # Main gameplay scene
│
└── _SceneHandler/
    ├── [Scene loading scripts]
    ├── [Scene transitions]
    └── [Scene initialization]
```

**Chức năng:**
- Quản lý các scene khác nhau
- Loading scene
- Transition effects giữa scenes
- Scene persistence

---

## ⚙️ Settings Folder (`Assets/Settings/`)

Chứa các file cấu hình và asset settings của Unity.

```
Settings/
├── DefaultVolumeProfile.asset            # Post-processing volume
├── InputSystem_Actions.inputactions      # Input system configuration
├── Lit2DSceneTemplate.scenetemplate      # Scene template
├── Renderer2D.asset                      # 2D renderer settings
├── UniversalRenderPipelineGlobalSettings.asset
├── UniversalRP.asset                     # URP render pipeline settings
│
├── TextMesh Pro/
│   ├── [Font assets]
│   └── [Text configuration]
│
└── Scenes/
    └── URP2DSceneTemplate.unity          # Template scene
```

**Chức năng:**
- Cấu hình Universal Render Pipeline (URP)
- Input system settings
- Post-processing effects
- TextMesh Pro configuration

---

## 📦 Packages & Dependencies (`Packages/`)

```
Packages/
├── manifest.json                         # Unity package dependencies
└── packages-lock.json                    # Locked versions
```

**Các package có thể bao gồm:**
- TextMesh Pro
- Universal Render Pipeline (URP)
- Input System
- Các plugin khác từ Unity Asset Store

---

## 📚 Library Folder (`Library/`)

**Lưu ý:** Đây là thư mục tự động sinh bởi Unity, không nên commit vào version control.

```
Library/
├── ScriptAssemblies/                     # Compiled C# scripts
├── ArtifactDB/                           # Asset database
├── Bee/                                  # IL2CPP build cache
├── PackageCache/                         # Downloaded packages
├── ShaderCache/                          # Compiled shaders
├── BurstCache/                           # Burst compilation cache
└── [Nhiều file cache khác]
```

---

## 🔧 Build & Configuration Files

| File | Mục đích |
|------|---------|
| `A.O.F.refactor.sln` | Visual Studio Solution file |
| `Assembly-CSharp.csproj` | C# Project file (runtime scripts) |
| `Assembly-CSharp-Editor.csproj` | C# Project file (editor scripts) |
| `ProjectVersion.txt` | Unity version info |
| `ProjectSettings.asset` | Main project settings |

---

## 📋 Project Configuration Summary

| Aspect | Details |
|--------|---------|
| **Engine** | Unity (version in ProjectVersion.txt) |
| **Graphics Pipeline** | Universal Render Pipeline (URP) - 2D |
| **Input System** | Unity's new Input System |
| **Scripting** | C# |
| **Architecture** | Systems-based modular design |
| **Target Platform** | 2D game (based on URP 2D) |

---

## 🎯 Main Scenes

| Scene | Mục đích |
|-------|---------|
| **MainMenu.unity** | Menu chính của trò chơi |
| **World.unity** | Cảnh gameplay chính |
| **ChooseCharacter** | Màn hình chọn nhân vật (UI Test) |
| **WinGame.unity** | Màn hình kết thúc/chiến thắng |
| **TestUI.unity** | Cảnh test UI |

---

## 🚀 Key Game Features (Based on Structure)

1. **10 Playable Characters** - Mỗi character có dữ liệu riêng
2. **3 Main Skills**:
   - Dash (di chuyển nhanh)
   - Radial Shot (tấn công từ nhiều hướng)
   - Shield (phòng thủ)
3. **Character Selection System** - Chọn nhân vật trước khi chơi
4. **Bullet/Attack System** - Combat mechanics
5. **Audio System** - Background music & sound effects
6. **UI System** - HUD, menus, dialogs
7. **Scene Management** - Multiple game states

---

## 💾 Ignored Folders (Git)

Những folder này **không nên** commit vào version control:
- `Library/` - Unity engine cache
- `obj/` - Build artifacts
- `Temp/` - Temporary files
- `UserSettings/` - User-specific settings
- `Logs/` - Application logs

**.gitignore** nên bao gồm:
```
Library/
obj/
Temp/
Logs/
UserSettings/
*.csproj
*.sln
```

---

## 📝 Notes

- Dự án sử dụng **Systems Architecture** - mỗi hệ thống độc lập nhưng tương tác với nhau
- Folder bắt đầu bằng `_` thường chứa handler/manager scripts
- Các `.meta` files là Unity metadata files, cần để giữ nguyên trong version control
- Project sử dụng **2D URP** pipeline cho graphics

---

## 📞 Quick Navigation

- **Game Logic**: `Assets/UnityProject/` (tất cả các system)
- **Visual Settings**: `Assets/Settings/`
- **Scenes**: `Assets/UnityProject/_Scene System/` & `Assets/Settings/Scenes/`
- **Audio**: `Assets/UnityProject/Audio System/`
- **UI**: `Assets/UnityProject/UI System/`
- **Project Config**: `ProjectSettings/`

---

# 🔍 Phân Tích Chi Tiết Code Architecture

## Design Patterns Sử Dụng

### 1. **Singleton Pattern** (GameManager)
```csharp
public static GameManager Instance;

void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
}
```
- **Mục đích**: Quản lý trạng thái game toàn cục
- **Tính chất**: Persistent across scenes (DontDestroyOnLoad)
- **Dữ liệu lưu trữ**:
  - `selectedCharacter` (CharacterDataSO)
  - `selectedSkills[]` (SkillDataSO array)

---

### 2. **ScriptableObject (Data-Driven Design)**

#### CharacterDataSO (Character System)
```csharp
[CreateAssetMenu(fileName = "Character ", menuName="Stats/CharacterData")]
public class CharacterDataSO : ScriptableObject
{
    public string characterName;
    public Sprite sprite;
    public RuntimeAnimatorController animator;
    public List<StatValue> stats;
}
```

**Ưu điểm**:
- Dễ dàng tạo 10 character khác nhau mà không cần edit code
- Inspector-friendly
- Reusable

#### SkillDataSO (Skill System)
```csharp
[CreateAssetMenu(fileName = "Skill ", menuName="Stats/SkillData")]
public abstract class SkillDataSO : ScriptableObject
{
    public string skillName;
    public float manaCost;
    public float cooldown;
    public float damage;
    public float range;
    public float speed;
    public float duration;
    public GameObject Prefab;
    
    public abstract void Execute(GameObject user, Vector3 targetPos, SkillDataSO data);
}
```

**Polymorphism**: DashSkill, RadialShotSkill, ShieldSkill kế thừa từ SkillDataSO

---

### 3. **Command Pattern** (SkillController)
```csharp
public void CastSkill(int index)
{
    // Validate -> Execute -> Set Cooldown
    skill.Execute(gameObject, inputDir, skill);
    skillCooldowns[index] = skill.cooldown;
}
```

---

## 📊 Data Flow Architecture

```
┌─────────────────┐
│  GameManager    │  (Singleton - trung tâm quản lý)
├─────────────────┤
│ selectedChar    │
│ selectedSkills[]│
└────────┬────────┘
         │
         ├──────────────────────────┬──────────────────┐
         │                          │                  │
    ┌────▼─────┐            ┌──────▼───────┐   ┌─────▼─────┐
    │PlayerCtrl │            │SkillCtrl     │   │    UI     │
    └────┬─────┘            └──────┬───────┘   └──────────┘
         │                         │
    ┌────▼──────────┐     ┌───────▼────────┐
    │Rigidbody2D    │     │SkillDataSO     │
    │Movement       │     │(DashSkill,     │
    │Animation      │     │RadialShot,     │
    │Stats Display  │     │Shield)         │
    └───────────────┘     └────────────────┘
```

---

## 🎮 Core Scripts Analysis

### **PlayerController.cs**
**Trách nhiệm**: Điều khiển nhân vật player

**Main Components**:
```csharp
private Rigidbody2D rb;           // Physics 2D
private SpriteRenderer sprite;    // Visual
private Animator animator;        // Animation
private Vector2 movement;         // Movement direction
private bool isDashing;           // Dash state flag
```

**Key Methods**:
| Method | Purpose |
|--------|---------|
| `Init()` | Load character data từ GameManager |
| `HandleMovement()` | Xử lý input từ joystick |
| `RefreshStatsDisplay()` | Cập nhật stats từ CharacterDataSO |
| `FaceDirection()` | Quay mặt về hướng di chuyển |
| `SetDashing()` | Flag để block movement khi dash |

**Stats được sử dụng**:
```csharp
public float HP => GetStatValue(StatType.maxHP);
public float MP => GetStatValue(StatType.maxMP);
public float ATK => GetStatValue(StatType.ATK);
public float DEF => GetStatValue(StatType.DEF);
public float SPD => GetStatValue(StatType.SPD);
```

---

### **SkillController.cs**
**Trách nhiệm**: Quản lý skills, cooldown, UI buttons

**Cooldown System**:
```csharp
private Dictionary<int, float> skillCooldowns = new Dictionary<int, float>();

private void UpdateCooldowns()
{
    for (int i = 0; i < skills.Length; i++)
    {
        if (skillCooldowns[i] > 0)
        {
            skillCooldowns[i] -= Time.deltaTime;
        }
    }
}

private void UpdateUI()
{
    // Disable button nếu chưa cooldown
    bool isReady = skillCooldowns[i] <= 0;
    skillButtons[i].interactable = isReady;
}
```

**Skill Execution Flow**:
1. Button được click → `OnSkillButtonClicked(index)`
2. Validate skill & cooldown
3. Lấy direction từ joystick (nếu không có → dùng `lastNonZeroMovement`)
4. Gọi `skill.Execute()`
5. Set cooldown

---

### **DashSkill.cs** (Skill Implementation)
**Trách nhiệm**: Thực thi skill Dash

```csharp
public override void Execute(GameObject user, Vector3 direction, SkillDataSO data)
{
    // Fallback nếu không có input
    if (dashDirection == Vector2.zero)
    {
        dashDirection = sr.flipX ? Vector2.left : Vector2.right;
    }
    
    // Coroutine để smooth dash movement
    mono.StartCoroutine(PerformDash(user, dashDirection));
}

private IEnumerator PerformDash(GameObject user, Vector2 dashDirection)
{
    PlayerController player = user.GetComponent<PlayerController>();
    player.SetDashing(true);  // Block normal movement
    
    Rigidbody2D rb = user.GetComponent<Rigidbody2D>();
    
    float startTime = Time.time;
    
    while (Time.time < startTime + duration)
    {
        rb.MovePosition(rb.position + dashDirection.normalized * speed * Time.fixedDeltaTime);
        yield return new WaitForFixedUpdate();
    }
    
    player.SetDashing(false);  // Re-enable movement
}
```

**Tính năng**:
- ✅ Smooth movement (fixed timestep)
- ✅ Auto-direction fallback
- ✅ Block movement during dash
- ✅ Duration-based (không dùng distance)

---

### **RadialShotSkill.cs** (In Progress)
**Trách nhiệm**: Phát shot theo vòng tròn

```csharp
[SerializeField] private int bulletCount = 12;

public override void Execute(GameObject user, Vector3 targetPos, SkillDataSO data)
{
    CastRadialShot(user, data);
}

private void CastRadialShot(GameObject user, SkillDataSO data)
{
    // TODO: Implement bullet spawning in circular pattern
}
```

**Status**: ⚠️ Incomplete (implementation TODO)

---

### **GameManager.cs**
**Trách nhiệm**: Scene management + Selection validation

**Key Features**:
```csharp
// Validation
private bool ValidateSelection()
{
    bool hasCharacter = selectedCharacter != null;
    bool hasAllSkills = selectedSkills[0] != null && 
                        selectedSkills[1] != null && 
                        selectedSkills[2] != null;
    
    if (!hasCharacter && !hasAllSkills)
        ShowWarning(noBothObj);
    else if (!hasCharacter)
        ShowWarning(noCharacterObj);
    else if (!hasAllSkills)
        ShowWarning(noSkillsObj);
    else
        return true;
        
    return false;
}

// Scene transitions
public void StartGame()
{
    if (ValidateSelection())
        LoadScene("World");
}
```

**Scene Flow**:
```
MainMenu
  ├→ StartGame (nếu selection valid) → World
  ├→ ChooseCharacter → (set selectedCharacter) → MainMenu
  └→ ChooseSpecialSkill → (set selectedSkills[]) → MainMenu
```

---

### **ChooseCharacterUI.cs**
**Trách nhiệm**: Character selection UI

```csharp
// 10 Character buttons
public Button characterBtn1, characterBtn2, ..., characterBtn10;
public CharacterDataSO character1, character2, ..., character10;

void Start()
{
    // Lambda expressions để bind buttons
    characterBtn1.onClick.AddListener(() => SelectCharacter(character1));
    characterBtn2.onClick.AddListener(() => SelectCharacter(character2));
    // ... x8 more
}

void SelectCharacter(CharacterDataSO character)
{
    GameManager.Instance.selectedCharacter = character;
    ShowStats(character);
}
```

**UI Display**:
- Hiển thị stats của character được chọn:
  - HP, MP, ATK, DEF, SPD, Cooldown
- Text format:
  ```
  HP: 100
  MP: 50
  ATK: 10
  DEF: 5
  SPD: 6
  CLD: 1
  ```

---

## 📈 Stat System

### StatType Enum
```csharp
enum StatType
{
    maxHP,
    maxMP,
    ATK,
    DEF,
    SPD,
    attackCooldown,
    detectRange
}
```

### StatValue Structure
```csharp
public struct StatValue
{
    public StatType type;
    public float value;
}
```

### Stats Flow
```
CharacterDataSO (Scriptable Object)
    ↓
List<StatValue> stats
    ↓
PlayerController.RefreshStatsDisplay()
    ↓
currentHP, currentMP, currentATK, currentDEF, currentSPD
    ↓
Display on UI
```

---

## 🎯 Game Flow Diagram

```
┌──────────────┐
│  Main Menu   │
└──────┬───────┘
       │
       ├─→ Choose Character ───┐
       │                       │
       ├─→ Choose Skills ──────┤
       │                       │
       ↓                       ↓
┌──────────────────────────────────────┐
│    Validation in GameManager         │
│  (Has Character? Has 3 Skills?)      │
└──────────────┬───────────────────────┘
               │
      ┌────────┴─────────┐
      │ Valid?           │ Invalid?
      ↓                  ↓
   ┌──────┐         ┌─────────┐
   │World │         │Warning  │
   │(Game)│         │Return   │
   └──────┘         └─────────┘
      ↓
   ┌──────────────────┐
   │Player Joins World│
   │Scripts Init:     │
   │- PlayerInit()    │
   │- CharData Load   │
   │- Skills Load     │
   └──────┬───────────┘
          │
   ┌──────▼──────────────┐
   │ Gameplay Loop:      │
   │ - Movement Input    │
   │ - Skill Cast        │
   │ - Combat           │
   └─────────────────────┘
```

---

## 🔗 Script Dependencies

```
GameManager (Singleton)
    ↑
    ├── PlayerController (reads selectedCharacter, selectedSkills)
    ├── SkillController (reads selectedSkills)
    ├── MainMenuUI (calls GameManager methods)
    ├── ChooseCharacterUI (sets selectedCharacter)
    └── ChooseSpecialSkillUI (sets selectedSkills[])

PlayerController
    ├── CharacterDataSO (reads)
    ├── Joystick (input)
    ├── Rigidbody2D (movement)
    └── Animator (animation)

SkillController
    ├── SkillDataSO[] (reads)
    ├── PlayerController (reads direction)
    └── UI.Button[] (controls)

SkillDataSO (Abstract Base)
    ├── DashSkill
    ├── RadialShotSkill
    └── ShieldSkill
```

---

## ⚙️ Input System

### Joystick Input (Mobile/Gamepad)
```csharp
public Joystick joystick;  // Assigned in inspector

float moveHorizontal = joystick.Horizontal;  // -1 to 1
float moveVertical = joystick.Vertical;      // -1 to 1
Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
```

**Source**: Joystick Pack (External package)
- Multiple joystick types: Fixed, Floating, Dynamic, Variable

---

## 🎬 Animation Integration

```csharp
public RuntimeAnimatorController animator;

// Set animation parameters
animator.SetBool("isRun", movement != Vector2.zero);
animator.SetFloat("lastDirectionX", lastNonZeroMovement.x);
animator.SetFloat("lastDirectionY", lastNonZeroMovement.y);
```

---

## 💾 Save/Load (Not Implemented)

⚠️ **Current State**: No persistence system
- Dữ liệu chỉ tồn tại trong session
- Suggestion: Implement PlayerPrefs hoặc JSON serialization

---

## ✅ Implemented Features

| Feature | Status | Details |
|---------|--------|---------|
| Character Selection | ✅ Complete | 10 characters, stat display |
| Player Movement | ✅ Complete | Joystick-based, sprite flip |
| Dash Skill | ✅ Complete | Smooth coroutine, duration-based |
| Radial Shot | ⚠️ Partial | Structure ready, Execute() TODO |
| Shield Skill | ❌ Not Found | Referenced but not implemented |
| Cooldown System | ✅ Complete | Dictionary-based tracking |
| UI System | ✅ Complete | Main menu, character selection |
| Scene Management | ✅ Complete | 4 main scenes + loading |
| Audio System | ⚠️ Partial | MusicManager exists, incomplete |

---

## 🚨 Technical Debt / TODO

1. **RadialShotSkill** - Complete Execute() implementation
2. **ShieldSkill** - Implement completely
3. **Bullet System** - Not fully connected
4. **Audio System** - MusicManager exists but not integrated
5. **Save/Load System** - Missing
6. **Error Handling** - Minimal null checks
7. **Pooling** - No object pooling for bullets/skills
8. **UI Feedback** - Skill feedback animations missing
9. **Stat Modifiers** - No buffs/debuffs system
10. **Network** - No multiplayer support

---

## 🏗️ Architecture Quality

### Strengths ✅
- Clear separation of concerns (Systems)
- Data-driven design (ScriptableObject)
- Singleton pattern for global state
- Modular skill system
- Clean input handling

### Areas for Improvement 🔧
- Abstract base class usage (SkillDataSO is abstract, good!)
- Event system (could replace GameManager coupling)
- Dependency injection (currently manual)
- Unit testability (tight coupling to MonoBehaviour)
- Documentation (inline comments sparse)

---

**Last Updated**: May 28, 2026
**Project Name**: A.O.F. Refactor
**Engine**: Unity (URP 2D)
