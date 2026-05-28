# 🚀 GUIDE RAPIDE : Lancer et Comprendre vos Tests

## 📦 Installation (Une seule fois)

```bash
# Ouvrir le dossier du projet
cd C:\YourPath\ShessProject

# Restaurer les dépendances
dotnet restore

# Compiler le projet
dotnet build
```

## ▶️ Lancer les Tests

### 1️⃣ Lancer TOUS les tests
```bash
dotnet test
```

**Résultat attendu :**
```
Building...
Test project: ChessTeam.Tests
  Discovering tests...
  Starting test execution...

ChessTeam.Tests.ChessLogical.ChessPositionTests.Constructor_ValidCoordinates_SetsXAndY PASSED
ChessTeam.Tests.ChessLogical.ChessPositionTests.Constructor_ValidCorners_Succeeds PASSED
ChessTeam.Tests.ChessMoving.MovingTests.King_FromCenter_HasEightMoves PASSED
...

Test Run Successful.
Total tests: 25
Passed: 25
Failed: 0
```

### 2️⃣ Lancer UN SEUL test
```bash
dotnet test --filter "ChessPositionTests"
```

### 3️⃣ Voir les détails
```bash
dotnet test --verbosity detailed
```

### 4️⃣ Arrêter au premier échec
```bash
dotnet test --no-build -- RunConfiguration.StopOnFirstFailure=true
```

## 🔧 Depuis Visual Studio

### Via Test Explorer
1. Ouvrir **Test Explorer** : `Test` → `Test Explorer` (ou `Ctrl+E, T`)
2. Cliquer sur **Run All** pour exécuter tous les tests
3. Les tests passés apparaissent en ✅ vert
4. Les tests échoués apparaissent en ❌ rouge

### Déboguer un test
1. Clic droit sur un test
2. Sélectionner **Debug** pour l'exécuter avec breakpoints

## 📊 Vérifier la Couverture de Code

La couverture de code = pourcentage du code testé

```bash
# Générer le rapport de couverture
dotnet test /p:CollectCoverage=true

# Voir le détail
dotnet test /p:CollectCoverage=true /p:CoverageFormat=opencover
```

## ❌ Quand un Test Échoue

**Exemple d'erreur :**
```
ChessTeam.Tests.ChessLogical.ChessPositionTests.Constructor_InvalidXLessThanOne_ThrowsArgumentException FAILED

Expected: ArgumentException
Actual: No exception thrown
```

### Comment Corriger ?

1. **Lire le message** : Qu'est-ce qui était attendu vs ce qui s'est produit ?
2. **Ajouter des logs** :
```csharp
// Avant le test
Console.WriteLine($"Position: {position}");
```

3. **Déboguer** : Mettre un breakpoint et exécuter en debug

## 📝 Écrire un NOUVEAU Test

### Modèle Simple (Copier-Coller)

```csharp
[Fact]
public void MethodName_Condition_ExpectedBehavior()
{
    // ARRANGE
    var input = new Chess(new ChessPosition(4, 4), TypeChess.Pion, TypeCamp.W);
    
    // ACT
    var result = input.Move(new ChessPosition(4, 5));
    
    // ASSERT
    Assert.Equal(new ChessPosition(4, 5), input.Position);
}
```

### Avec Plusieurs Cas ([Theory])

```csharp
[Theory]
[InlineData(1)]
[InlineData(4)]
[InlineData(8)]
public void ChessPosition_ValidX_Succeeds(int x)
{
    var pos = new ChessPosition(x, 4);
    Assert.Equal(x, pos.X);
}
```

## 🐛 Débogage Pas à Pas

### Ajouter des Points d'Arrêt
1. Cliquer à gauche du numéro de ligne
2. Un point rouge apparaît
3. Lancer le test en mode Debug
4. Le code s'arrête au breakpoint

### Inspecter des Variables
- Hover sur une variable pour voir sa valeur
- Ouvrir **Debug Console** pour voir tous les objets
- Utiliser **Watch** pour suivre une variable

## 📚 Assertions Courantes

```csharp
// Égalité
Assert.Equal(5, result);
Assert.NotEqual(5, result);

// Vrai/Faux
Assert.True(condition);
Assert.False(condition);

// Collections
Assert.Empty(list);
Assert.NotEmpty(list);
Assert.Contains(item, list);
Assert.Single(list);

// Null
Assert.Null(obj);
Assert.NotNull(obj);

// Exceptions
Assert.Throws<ArgumentException>(() => BadMethod());

// Plage
Assert.InRange(5, 1, 10);
```

## 🎯 Bonnes Pratiques

### ✅ BON
```csharp
[Fact]
public void Pion_White_AdvancesCorrectly()
{
    var pion = new Chess(new(4, 2), TypeChess.Pion, TypeCamp.W);
    var moves = pion.NextPositions;
    
    Assert.Contains(new(4, 3), moves);
}
```

### ❌ MAUVAIS
```csharp
[Fact]
public void Test()
{
    var x = new Chess(new(4, 2), TypeChess.Pion, TypeCamp.W);
    var y = x.NextPositions;
    Assert.NotEmpty(y);
    var z = new Chess(new(5, 5), TypeChess.Roi);
    Assert.NotNull(z);
}
```

## 🚀 Workflow Recommandé

### Pour chaque nouvelle fonctionnalité :

1. **Écrire le test** (Il échoue d'abord)
```csharp
[Fact]
public void NewFeature_DoesExpectedThing()
{
    Assert.Equal(expected, actual);
}
```

2. **Lancer le test** : `dotnet test`
   - ❌ Doit échouer

3. **Implémenter la fonctionnalité** dans le code principal

4. **Relancer le test** : `dotnet test`
   - ✅ Doit réussir

5. **Refactoriser** si nécessaire

6. **Relancer les tests** : `dotnet test`
   - ✅ Tous doivent passer

## 📞 Commandes Utiles

```bash
# Lancer les tests avec filtrage par classe
dotnet test --filter "ClassName"

# Lancer un test spécifique
dotnet test --filter "ChessPositionTests.Constructor_ValidCoordinates_SetsXAndY"

# Lancer avec niveau de détail
dotnet test --verbosity normal|minimal|detailed|diagnostic

# Générer un rapport XML
dotnet test --logger "trx;LogFileName=TestResults.xml"

# Écouter les changements (relancer auto)
dotnet watch test
```

## 💡 Conseils Importants

1. **Un test = une chose** à tester
2. **Noms clairs** : `Method_Condition_ExpectedBehavior`
3. **Tests rapides** : < 100ms par test
4. **Tests indépendants** : Pas de dépendance entre tests
5. **Isolation** : Préparer ses données dans ARRANGE

## 🎓 Résumé

| Concept | Commande |
|---------|----------|
| Lancer tous les tests | `dotnet test` |
| Lancer un test | `dotnet test --filter "NomDuTest"` |
| Voir détails | `dotnet test --verbosity detailed` |
| Couverture | `dotnet test /p:CollectCoverage=true` |
| Déboguer | Clic droit → Debug dans Test Explorer |

**C'est tout ! Vous êtes maintenant prêt à écrire et lancer des tests ! 🚀**
