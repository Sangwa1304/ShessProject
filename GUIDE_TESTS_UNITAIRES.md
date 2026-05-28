# 📚 GUIDE COMPLET DES TESTS UNITAIRES EN C#

## 🎯 Qu'est-ce qu'un Test Unitaire ?

Un **test unitaire** est un petit programme qui vérifie qu'**une seule fonction/méthode** fonctionne correctement.

### Analogue avec Jupyter :
```python
# JUPYTER - Votre ancienne méthode
def pion_moves(pion_pos, camp):
    moves = calculate_moves(pion_pos, camp)
    print(moves)  # ✅ Vous vérifiez manuellement

# TEST UNITAIRE - La bonne méthode
def test_pion_moves_white_correctly():
    moves = calculate_moves((4, 2), "White")
    assert (4, 3) in moves  # ✅ Vérification automatique
```

### Avantages :
✅ **Automatisé** : Lance tous les tests en 1 seconde  
✅ **Répétable** : Mêmes résultats à chaque fois  
✅ **Rapide** : Détecte les bugs immédiatement  
✅ **Documentation** : Montre comment utiliser le code  

---

## 🏗️ Structure Basique d'un Test

```csharp
// Format standard : Arrange → Act → Assert (AAA)

[Fact]  // "Fact" = test sans paramètres
public void PionMoves_WhiteAdvancesTwoSquares_FromStartPosition()
{
    // 📍 ARRANGE : Préparer les données
    var pion = new Chess(new ChessPosition(4, 2), TypeChess.Pion);
    var expectedMoves = new List<ChessPosition>
    {
        new(4, 3),  // Une case
        new(4, 4)   // Deux cases (premier coup)
    };
    
    // 🎬 ACT : Exécuter la méthode à tester
    var actualMoves = Moving.RunFonc(TypeChess.Pion, TypeCamp.W, pion.Position);
    
    // ✅ ASSERT : Vérifier le résultat
    Assert.Equal(expectedMoves.Count, actualMoves.Count);
    Assert.Contains(new(4, 3), actualMoves);
    Assert.Contains(new(4, 4), actualMoves);
}
```

### Explication de chaque partie :

| Partie | Rôle | Exemple |
|--------|------|---------|
| **ARRANGE** | Créer les données d'entrée | Créer une pièce de départ |
| **ACT** | Appeler la méthode à tester | `Moving.RunFonc(...)` |
| **ASSERT** | Vérifier le résultat | `Assert.Equal(...)` |

---

## 🎓 Les Assertions les Plus Utiles

```csharp
// 1️⃣ ÉGALITÉ
Assert.Equal(4, pion.Position.X);           // Valeur exacte
Assert.NotEqual(5, pion.Position.Y);        // N'est pas égal

// 2️⃣ VRAI/FAUX
Assert.True(chess.Enabled);                 // Vrai
Assert.False(chess.Enabled);                // Faux

// 3️⃣ COLLECTIONS
Assert.Contains(item, list);                // Item dans la liste
Assert.DoesNotContain(item, list);          // Item absent
Assert.Empty(list);                         // Liste vide
Assert.NotEmpty(list);                      // Liste non vide
Assert.Single(list);                        // Exactement 1 élément

// 4️⃣ OBJETS NULL
Assert.Null(chess.Camp);                    // Est null
Assert.NotNull(chess.Camp);                 // N'est pas null

// 5️⃣ EXCEPTIONS
Assert.Throws<ArgumentException>(() => 
    new ChessPosition(-1, 5)                // Doit lever une exception
);

// 6️⃣ TOUTES LES CONDITIONS
Assert.All(list, item => Assert.True(item.Enabled));  // Tous respectent la condition
```

---

## 📊 Types de Tests : [Fact] vs [Theory]

### 1️⃣ **[Fact]** = Un seul test
```csharp
[Fact]
public void CavalierMoves_EightDirections()
{
    // Test UN CAS spécifique
    var moves = Moving.RunFonc(TypeChess.Cavalier, TypeCamp.W, new(4, 4));
    Assert.Equal(8, moves.Count);
}
```

### 2️⃣ **[Theory]** = Plusieurs tests avec différentes données
```csharp
[Theory]
[InlineData(4, 2, TypeCamp.W)]      // Cas 1
[InlineData(4, 7, TypeCamp.B)]      // Cas 2
[InlineData(1, 2, TypeCamp.W)]      // Cas 3
public void PionMoves_AlwaysAdvanceInDirection(int x, int y, TypeCamp camp)
{
    // Même test, mais avec 3 ensembles de données différentes !
    var moves = Moving.RunFonc(TypeChess.Pion, camp, new(x, y));
    Assert.NotEmpty(moves);
}
```

**Avantage** : 1 ligne de code = 3 tests ! 🚀

---

## 🔄 Tests Paramétrés - Cas Réels du Jeu d'Échecs

```csharp
[Theory]
[InlineData(TypeChess.Pion, 1)]         // Pion = 1 point
[InlineData(TypeChess.Cavalier, 3)]     // Cavalier = 3 points
[InlineData(TypeChess.Tour, 5)]         // Tour = 5 points
[InlineData(TypeChess.Fou, 3)]          // Fou = 3 points
[InlineData(TypeChess.Reine, 9)]        // Reine = 9 points
public void ChessPieceValue_IsCorrect(TypeChess type, int expectedValue)
{
    var piece = new Chess(new(4, 4), type);
    var value = piece.GetValue();
    Assert.Equal(expectedValue, value);
}
```

---

## ⚙️ Setup et Teardown (Préparation et Nettoyage)

```csharp
public class ChessMovingTests
{
    // Les données BEFORE chaque test
    [SetUp]
    public void Setup()
    {
        // Créé une position vierge
        this.position = new ChessPosition(4, 4);
        this.camp = TypeCamp.W;
    }
    
    // Les données AFTER chaque test
    [TearDown]
    public void Teardown()
    {
        // Nettoyage (optionnel)
        position = null;
        camp = null;
    }
    
    [Fact]
    public void Test1() { /* position et camp préparés */ }
    
    [Fact]
    public void Test2() { /* position et camp préparés ENCORE */ }
}
```

---

## 🎯 Structure Réaliste : Votre Projet d'Échecs

### Hiérarchie des tests :
```
Tests/
├── ChessLogical/
│   ├── ChessTests.cs              // Tests de Chess.cs
│   ├── ChessPositionTests.cs      // Tests de ChessPosition.cs
│   └── ChessCampTests.cs          // Tests de ChessCamp.cs
├── ChessMoving/
│   ├── MovingTests.cs             // Tests de Moving.cs
│   ├── PionMovementTests.cs       // Tests spécifiques Pion
│   ├── KnightMovementTests.cs     // Tests spécifiques Cavalier
│   └── ...
└── Integration/
    └── GameFlowTests.cs           // Tests complets (plusieurs modules)
```

---

## 🧪 Exemple Réel : Tests pour Moving.cs

```csharp
namespace ChessTeam.Tests.ChessMoving
{
    public class MovingTests
    {
        // ==================== PION TESTS ====================
        
        [Fact]
        public void Pion_White_FromStartPosition_CanMove2Squares()
        {
            // ARRANGE
            var startPosition = new ChessPosition(4, 2);
            var camp = TypeCamp.W;
            
            // ACT
            var moves = Moving.RunFonc(TypeChess.Pion, camp, startPosition);
            
            // ASSERT
            Assert.Contains(new(4, 3), moves);
            Assert.Contains(new(4, 4), moves);
        }
        
        [Fact]
        public void Pion_White_CanCaptureOnDiagonals()
        {
            var moves = Moving.RunFonc(TypeChess.Pion, TypeCamp.W, new(4, 4));
            
            Assert.Contains(new(3, 5), moves);  // Gauche-haut
            Assert.Contains(new(5, 5), moves);  // Droite-haut
        }
        
        [Theory]
        [InlineData(TypeCamp.W)]
        [InlineData(TypeCamp.B)]
        public void Pion_ThrowsException_IfCampIsNull(TypeCamp camp)
        {
            // Le Pion DOIT avoir un camp !
            Assert.Throws<ArgumentException>(() =>
                Moving.RunFonc(TypeChess.Pion, null, new(4, 4))
            );
        }
        
        // ==================== CAVALIER TESTS ====================
        
        [Fact]
        public void Cavalier_MakesLShapedMove()
        {
            var moves = Moving.RunFonc(TypeChess.Cavalier, TypeCamp.W, new(4, 4));
            
            // Doit avoir 8 mouvements possibles depuis le centre
            Assert.Equal(8, moves.Count);
        }
        
        [Theory]
        [InlineData(1, 1)]      // Coin
        [InlineData(1, 8)]      // Coin
        [InlineData(8, 1)]      // Coin
        [InlineData(8, 8)]      // Coin
        public void Cavalier_FromCorner_HasLessOptions(int x, int y)
        {
            var moves = Moving.RunFonc(TypeChess.Cavalier, TypeCamp.W, new(x, y));
            
            // Un cavalier aux coins a moins de mouvements
            Assert.True(moves.Count < 8);
        }
        
        // ==================== TOUR TESTS ====================
        
        [Fact]
        public void Tour_MovesInStraightLines()
        {
            var moves = Moving.RunFonc(TypeChess.Tour, TypeCamp.W, new(4, 4));
            
            // Doit couvrir toute la ligne et colonne
            for (int i = 1; i <= 8; i++)
            {
                if (i != 4)  // Sauf sa position actuelle
                {
                    Assert.Contains(new(4, i), moves);  // Verticalement
                    Assert.Contains(new(i, 4), moves);  // Horizontalement
                }
            }
        }
        
        // ==================== POSITION TESTS ====================
        
        [Theory]
        [InlineData(0, 0)]      // Invalide
        [InlineData(-1, 5)]     // Invalide
        [InlineData(9, 5)]      // Invalide
        [InlineData(5, 10)]     // Invalide
        public void ChessPosition_ThrowsException_IfOutOfBounds(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => new ChessPosition(x, y));
        }
        
        [Theory]
        [InlineData(1, 1)]      // Valide
        [InlineData(4, 4)]      // Valide
        [InlineData(8, 8)]      // Valide
        public void ChessPosition_IsValid_IfInBounds(int x, int y)
        {
            var pos = new ChessPosition(x, y);
            Assert.Equal(x, pos.X);
            Assert.Equal(y, pos.Y);
        }
    }
}
```

---

## 🔗 Comparaison : Jupyter vs Tests Unitaires

### ❌ JUPYTER (Ancien)
```python
# IdentifyInteractive.ipynb
def test_pion():
    moves = calculate_pion_moves(4, 2, "White")
    print("Mouvements du pion :", moves)
    # ❌ Vous vérifiez manuellement par les yeux
    # ❌ À refaire à chaque modification
    # ❌ Pas d'historique des tests
```

### ✅ TESTS UNITAIRES (Nouveau)
```csharp
// ChessTeam.Tests/MovingTests.cs
[Fact]
public void Pion_White_CanMoveTwo()
{
    var moves = Moving.RunFonc(TypeChess.Pion, TypeCamp.W, new(4, 2));
    
    Assert.Contains(new(4, 3), moves);
    Assert.Contains(new(4, 4), moves);
    // ✅ Automatique = 100% fiable
    // ✅ Refait à chaque `dotnet test`
    // ✅ Historique git des tests
}
```

---

## 🚀 Lancer les Tests

```bash
# Installer la dépendance (une seule fois)
dotnet add ChessTeam.Tests package xunit
dotnet add ChessTeam.Tests package xunit.runner.visualstudio

# Lancer TOUS les tests
dotnet test

# Lancer un test spécifique
dotnet test --filter "NameOfTest"

# Voir le détail
dotnet test --verbosity detailed

# Voir la couverture de code (combien % du code est testé)
dotnet add ChessTeam.Tests package coverlet.collector
dotnet test /p:CollectCoverage=true
```

---

## 📈 Bonnes Pratiques

### ✅ BON
```csharp
[Fact]
public void PionMoves_White_FromStartPosition()  // Nom clair
{
    // UNE seule chose testée
    var moves = Moving.RunFonc(TypeChess.Pion, TypeCamp.W, new(4, 2));
    Assert.Contains(new(4, 4), moves);
}
```

### ❌ MAUVAIS
```csharp
[Fact]
public void Test1()  // Nom vague
{
    // PLUSIEURS choses testées
    var chess = new Chess(new(4, 4), TypeChess.Pion);
    Assert.NotNull(chess);
    Assert.Equal(TypeChess.Pion, chess.Type);
    chess.Move(new(4, 5));
    Assert.NotEqual(new(4, 4), chess.Position);
    // ❌ 4 assertions = 4 tests à la fois !
}
```

---

## 🎓 Exemple Complet : Votre Premier Test

Fichier : `ChessTeam.Tests/ChessLogical/ChessPositionTests.cs`

```csharp
using Xunit;
using ChessTeam.ChessLogical;

namespace ChessTeam.Tests.ChessLogical
{
    public class ChessPositionTests
    {
        // 1️⃣ Test simple
        [Fact]
        public void Constructor_ValidCoordinates_SetsXY()
        {
            // Arrange
            int expectedX = 4;
            int expectedY = 4;
            
            // Act
            var pos = new ChessPosition(expectedX, expectedY);
            
            // Assert
            Assert.Equal(expectedX, pos.X);
            Assert.Equal(expectedY, pos.Y);
        }
        
        // 2️⃣ Test d'exception
        [Fact]
        public void Constructor_InvalidX_ThrowsArgumentException()
        {
            // Assert + Act (ensemble car on attend une exception)
            Assert.Throws<ArgumentException>(() => 
                new ChessPosition(0, 4)
            );
        }
        
        // 3️⃣ Test paramétré
        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(8)]
        public void Constructor_ValidX_Succeeds(int x)
        {
            var pos = new ChessPosition(x, 4);
            Assert.Equal(x, pos.X);
        }
        
        // 4️⃣ Test d'égalité
        [Fact]
        public void Equals_SameCoordinates_ReturnsTrue()
        {
            var pos1 = new ChessPosition(4, 4);
            var pos2 = new ChessPosition(4, 4);
            
            Assert.Equal(pos1, pos2);
        }
        
        // 5️⃣ Test d'opérateur
        [Fact]
        public void Operator_Equals_Works()
        {
            var pos1 = new ChessPosition(4, 4);
            var pos2 = new ChessPosition(4, 4);
            
            Assert.True(pos1 == pos2);
        }
    }
}
```

**À lancer :**
```bash
dotnet test ChessTeam.Tests
```

---

## 📚 Résumé des Concepts

| Concept | Signification | Exemple |
|---------|---------------|---------|
| **[Fact]** | Test sans paramètres | `public void Test()` |
| **[Theory]** | Test avec paramètres | `public void Test(int x)` |
| **[InlineData]** | Fournit les paramètres | `[InlineData(5)]` |
| **Arrange** | Préparer les données | `var chess = new(...)` |
| **Act** | Appeler la méthode | `var result = Moving.RunFonc(...)` |
| **Assert** | Vérifier le résultat | `Assert.Equal(5, result)` |
| **Mock** | Objet fictif pour tester | Plus tard ! 🚀 |

---

## 🎬 Prochaines Étapes

1. ✅ Créer le projet `ChessTeam.Tests`
2. ✅ Écrire les tests simples (ChessPosition)
3. ✅ Écrire les tests complexes (Moving)
4. ✅ Lancer `dotnet test` régulièrement
5. ✅ Atteindre 80%+ de couverture de code

**Vous êtes prêt !** 🚀
