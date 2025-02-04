# Lonely-Tower

## 📜 Description
**Lonely-Tower** est un jeu de type *Tower Defense* en vue isométrique, développé sous Unity. Le joueur doit défendre une tour centrale contre des vagues d'ennemis en améliorant ses capacités et en affrontant des boss toutes les 10 vagues.

---

## 🎮 Fonctionnalités Principales
- **Vue isométrique** avec graphismes Sci-Fi.
- **Système de vagues dynamiques** où la difficulté augmente progressivement.
- **Différents types d'ennemis**, y compris des unités de mêlée et des unités à distance.
- **Système d'améliorations** pour la tour, influençant attaque, défense et régénération.
- **Effets visuels et sonores avancés**, notamment des explosions lors de la destruction des ennemis.

---

## 🏗️ Structure des Scènes

Le projet utilise plusieurs scènes pour organiser le jeu de manière claire et efficace :

| 🎬 **Nom de la Scène** | 📝 **Description** |
|--------------------|-------------------|
| `MainMenuScene`   | Écran d'accueil avec les boutons *Jouer* et *Options*. |
| `OptionsScene`    | Menu de configuration (audio, graphismes, contrôles, etc.). |
| `GameScene`       | Scène principale où le joueur affronte les vagues d'ennemis. |

---

## 🏗️ Hiérarchie des Objets

Dans **GameScene**, voici l’organisation des objets :

```
GameScene
├── Main Camera (Vue isométrique)
├── Directional Light (Lumière de la scène)
├── UI (Canvas)
│   ├── HealthBar
│   ├── WaveCounter
│   ├── UpgradeButtons
│   └── PauseButton
├── Game Manager (Scripts qui gèrent la partie)
│   ├── Game Manager (Gère les statistiques de la partie)
│   └── Enemy Spawner (Gère les vagues l'apparition des ennemis)
├── Ground (Plan texturé, le sol de la map)
├── Tower (Tour centrale)
│   └── Tower Controller (Gestion des améliorations)
│       ├── Combat Entity (Script hérité gérant les unités de combat tour ou ennemis)
│       └── Statistics (Script contenant les stats)
├── PostProcess (Scipt pemettant d'ajouter des effets de post processing à l'image)
├── Enemies (Parent dynamique des ennemis spawnés)
│   ├── EnemyType1 (Faible)
│   ├── EnemyType2 (Intermédiaire)
│   ├── EnemyType3 (Fort)
│   ├── Shooter (Tire des projectiles)
│   └── Boss (Apparaît toutes les 10 vagues)
└── EventSystem (Gère les inputs du joueur)
```

---

## 🛠️ Systèmes Principaux

### 🎯 **Système de Combat**
- **Tour** : Attaque automatiquement les ennemis à portée.
- **Critiques** : Les attaques ont une chance de critique augmentant les dégâts.
- **Blockage** : Les attaques ont une chance de blocker les dégâts.
- **Projectiles** : Gérés via un système sans physique pour optimiser les performances.
- **Ennemis** : Différents comportements (corps-à-corps, tir à distance, boss).

### 🌊 **Système de Vagues**
- **Augmentation progressive de la difficulté** :
  - Ennemis plus résistants et plus nombreux.
  - Boss toutes les 10 vagues.
  - Spawn en *packs* pour éviter un rythme trop régulier et ennuyeux.

### 🏗 **Système d’Améliorations**
- **Améliorations de la tour** :
  - Augmentation des dégâts, vitesse d’attaque, portée.
  - Amélioration de la défense (bouclier, régénération, points de vie max).
  - Augmentation du nombre et de la vitesse des projectiles.

---

## 📲 Déploiement sur Android

### 🔹 **Builder le jeu**
1. Aller dans `File` → `Build Settings`.
2. Sélectionner `Android` et cliquer sur `Switch Platform`.
3. Ajouter `GameScene` et `MainMenu` aux scènes à inclure.
4. Configurer `Player Settings` :
   - Définir un `Package Name` unique (`com.korobetski.lonelytower`).
   - Choisir l’orientation `Portrait`.
5. Cliquer sur `Build and Run`.

### 🔹 **Tester sur un téléphone Android**
1. Activer le mode développeur et le débogage USB sur ton téléphone.
2. Connecter le téléphone via USB.
3. Dans Unity, aller dans `Edit > Preferences > External Tools` et s’assurer que le SDK Android est bien configuré.
4. Lancer `Build and Run`.

---

## 🚀 TODO & Améliorations Futures
✅ Système de vagues dynamique et équilibré.  
✅ Amélioration de la tour avec gestion des statistiques.  
✅ Effets visuels et sonores pour les impacts et destructions.  
🟡 Ajout de nouveaux types d'ennemis avec IA plus avancée.  
🟡 Système de talents / compétences spéciales pour la tour.  
🟡 Plus d’effets graphiques (post-processing, particules améliorées).  

---

## 🏆 Crédits
Développé par **[Korobetski / Moebius Core]**  
Propulsé par **Unity** 🎮

*Moebius Core* © 2025 - Tous droits réservés.

