using Xunit;
using ChessTeam.ChessLogical;

namespace ChessTeam.Tests.ChessLogical
{
    /// <summary>
    /// Tests pour la classe ChessPosition
    /// Vérifie que les positions sont correctement validées et créées
    /// </summary>
    public class ChessPositionTests
    {
        // ==================== TESTS DE CONSTRUCTION ====================
        
        /// <summary>
        /// TEST 1 : Vérifier qu'une position valide est créée correctement
        /// </summary>
        [Fact]
        public void Constructor_ValidCoordinates_SetsXAndY()
        {
            // 📍 ARRANGE : Préparer les données attendues
            int expectedX = 4;
            int expectedY = 4;
            
            // 🎬 ACT : Créer la position
            var position = new ChessPosition(expectedX, expectedY);
            
            // ✅ ASSERT : Vérifier que X et Y sont corrects
            Assert.Equal(expectedX, position.X);
            Assert.Equal(expectedY, position.Y);
        }
        
        /// <summary>
        /// TEST 2 : Vérifier que les coins de l'échiquier sont valides
        /// Utilise [Theory] pour tester tous les coins en une seule méthode
        /// </summary>
        [Theory]
        [InlineData(1, 1)]      // Coin bas-gauche
        [InlineData(1, 8)]      // Coin haut-gauche
        [InlineData(8, 1)]      // Coin bas-droit
        [InlineData(8, 8)]      // Coin haut-droit
        public void Constructor_ValidCorners_Succeeds(int x, int y)
        {
            // 🎬 ACT
            var position = new ChessPosition(x, y);
            
            // ✅ ASSERT
            Assert.NotNull(position);
            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
        }
        
        // ==================== TESTS D'EXCEPTION ====================
        
        /// <summary>
        /// TEST 3 : Vérifier que X < 1 lève une exception
        /// </summary>
        [Fact]
        public void Constructor_InvalidXLessThanOne_ThrowsArgumentException()
        {
            // Assert + Act ensemble (cas exception)
            Assert.Throws<ArgumentException>(() => 
                new ChessPosition(0, 4)
            );
        }
        
        /// <summary>
        /// TEST 4 : Vérifier que X > 8 lève une exception
        /// </summary>
        [Fact]
        public void Constructor_InvalidXGreaterThanEight_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => 
                new ChessPosition(9, 4)
            );
        }
        
        /// <summary>
        /// TEST 5 : Vérifier que Y < 1 lève une exception
        /// </summary>
        [Fact]
        public void Constructor_InvalidYLessThanOne_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => 
                new ChessPosition(4, 0)
            );
        }
        
        /// <summary>
        /// TEST 6 : Vérifier que Y > 8 lève une exception
        /// Teste plusieurs valeurs invalides
        /// </summary>
        [Theory]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(100)]
        public void Constructor_InvalidYGreaterThanEight_ThrowsArgumentException(int invalidY)
        {
            Assert.Throws<ArgumentException>(() => 
                new ChessPosition(4, invalidY)
            );
        }
        
        // ==================== TESTS D'ÉGALITÉ ====================
        
        /// <summary>
        /// TEST 7 : Deux positions avec les mêmes coordonnées sont égales
        /// </summary>
        [Fact]
        public void Equals_SameCoordinates_ReturnsTrue()
        {
            // ARRANGE
            var pos1 = new ChessPosition(4, 4);
            var pos2 = new ChessPosition(4, 4);
            
            // ACT & ASSERT
            Assert.Equal(pos1, pos2);
        }
        
        /// <summary>
        /// TEST 8 : Deux positions avec des coordonnées différentes ne sont pas égales
        /// </summary>
        [Fact]
        public void Equals_DifferentCoordinates_ReturnsFalse()
        {
            var pos1 = new ChessPosition(4, 4);
            var pos2 = new ChessPosition(5, 5);
            
            Assert.NotEqual(pos1, pos2);
        }
        
        /// <summary>
        /// TEST 9 : L'opérateur == fonctionne correctement
        /// </summary>
        [Fact]
        public void OperatorEquals_SameCoordinates_ReturnsTrue()
        {
            var pos1 = new ChessPosition(4, 4);
            var pos2 = new ChessPosition(4, 4);
            
            Assert.True(pos1 == pos2);
        }
        
        /// <summary>
        /// TEST 10 : L'opérateur != fonctionne correctement
        /// </summary>
        [Fact]
        public void OperatorNotEquals_DifferentCoordinates_ReturnsTrue()
        {
            var pos1 = new ChessPosition(4, 4);
            var pos2 = new ChessPosition(5, 5);
            
            Assert.True(pos1 != pos2);
        }
        
        // ==================== TESTS DE REPOSITIONNEMENT ====================
        
        /// <summary>
        /// TEST 11 : La méthode Reposition() change les coordonnées
        /// </summary>
        [Fact]
        public void Reposition_ChangesCoordinates()
        {
            // ARRANGE
            var position = new ChessPosition(4, 4);
            int newX = 5;
            int newY = 5;
            
            // ACT
            position.Reposition(newX, newY);
            
            // ASSERT
            Assert.Equal(newX, position.X);
            Assert.Equal(newY, position.Y);
        }
        
        /// <summary>
        /// TEST 12 : ToString() retourne une représentation correcte
        /// </summary>
        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            var position = new ChessPosition(4, 4);
            var result = position.ToString();
            
            Assert.Contains("4", result);
            Assert.NotEmpty(result);
        }
    }
}
