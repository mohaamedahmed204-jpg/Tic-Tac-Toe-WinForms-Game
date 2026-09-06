# ❌⭕ Tic-Tac-Toe WinForms Game

A polished, modular Desktop Tic-Tac-Toe application engineered in **C#** using **Windows Forms** and **.NET**. Designed with a dynamic User Control (`UserControl`) architecture to deliver a seamless multi-screen gameplay experience, customizable match settings, and efficient backend win-checking logic.

---

## 📷 Screenshots

<img width="810" height="449" alt="Screenshot 2026-09-06 150053" src="https://github.com/user-attachments/assets/418e758e-af49-4e3e-891b-282eb97c6637" />

---

## 📝 Overview

The **Tic-Tac-Toe WinForms Game** transitions traditional classic gameplay into a component-driven desktop interface. Built using modern object-oriented principles, the application separates the application UI into modular components that dynamically load inside a primary parent form shell (`frmMainForm`). 

Users can configure player profiles, set total round limits, track real-time score updates, and view end-of-game screens without managing complex multi-window lifecycles.

---

## ⚙️ Core Operations

* **🎮 Turn-Based Logic Management:**
  Tracks current active turns between two customizable player entities (`Player1` vs `Player2`), updating static indicators dynamically across every valid interaction.

* **🔍 Algorithmic Matrix Validation:**
  Evaluates game state instantly following every turn using a lightweight $3 \times 3$ primitive character array (`char[,] a`). Evaluates rows, columns, and diagonal vectors in $\mathcal{O}(1)$ time.

* **🔄 Modular Screen Navigation:**
  Utilizes dynamic User Controls (`ucMainPage`, `ucNamePlayer`, `ucGameRounds`, `ucGameOver`) swapped programmatically inside the main form container to deliver single-page UI navigation.

* **📊 Multi-Round Session Tracking:**
  Maintains round counts, point totals, draw counters, and game completion states across customizable multi-round sessions.

* **🏷️ Metadata-Driven Control Tagging:**
  Uses UI control metadata (`PictureBox.Tag`) to store relative board coordinates $(i, j)$ and occupation states (`E` for Empty, `X`, `O`), eliminating hardcoded dynamic event binding overhead.

---

## 💡 Key Concepts Demonstrated

* **UserControl Modular Architecture:** Decoupling screens into independent component files for cleaner code maintenance and separation of concerns.
* **State Management & Data Persistence:** Passing player data, scores, and round configurations safely across control interfaces using custom constructors.
* **Event-Driven UI Programming:** Binding shared event handlers (`CurrRound`) to handle user clicks uniformly across interactive board elements.
* **Resource Optimization:** Loading dynamic graphic assets using managed image resources (`Properties.Resources`).
* **Matrix Array Manipulation:** Mapping UI grid elements to low-level 2D arrays for backend verification.

---

## 🏗️ Architecture & Design

The project is structured logically across modular `UserControl` views managed by a central window parent shell:

```text
Fifth_project/
├── Properties/
│   └── Resources.resx           # Game assets (Icons, Images)
├── Program.cs                   # Application Entry Point
├── frmMainForm.cs               # Host Window Container
├── ucMainPage.cs                # Landing / Main Menu View
├── ucNamePlayer.cs              # Game Setup & Round Configuration View
├── ucGameRounds.cs              # Core Gameplay & Dynamic Board View
└── ucGameOver.cs                # Round Results & Winner Screen View

```

---

## 🛠️ Technologies & Tools

* **Programming Language:** C#
* **Framework:** .NET Framework / .NET (Windows Forms)
* **IDE:** Microsoft Visual Studio
* **GUI Engine:** WinForms GDI+ Rendering Engine

---

## 🙏 Gratitude

Programming Advices Platform
Dr. Mohammed Abu-Hadhoud

[ https://programmingadvices.com ]

He was not just an instructor!!

He was:

    A mentor
    A coach
    A guide
    A motivator
    A teacher who understands timing

Because the real secret of success in programming is:

    Proper progression
    Correct guidance
    The right timing to learn each concept

And that is exactly what we experienced

