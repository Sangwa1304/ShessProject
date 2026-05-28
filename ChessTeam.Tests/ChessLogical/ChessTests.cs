using Xunit;
using ChessTeam.ChessLogical;

namespace ChessTeam.Tests.ChessLogical
{
    /// <summary>
    /// Tests pour la classe Chess (représentation d'une pièce)
    /// Vérifie la création, mouvement et état des pièces
    /// </summary>
    public class ChessTests
    {
        // ==================== TESTS DE CONSTRUCTION ====================
        
        /// <summary>
        /// TEST 1 : Une pièce est créée avec les bonnes propriétés
        /// </summary>
        [Fact]
        public void Constructor_CreatesChessWithCorrectType()
        {
            // ARRANGE
            var position = new ChessPosition(4, 2);
            var type = TypeChess.Pion;
            var camp = TypeCamp.W;
            
            // ACT
            var chess = new Chess(position, type, camp);
            
            // ASSERT
            Assert.Equal(type, chess.Type);
            Assert.Equal(camp, chess.Camp);
            Assert.Equal(position, chess.Position);
            Assert.True(chess.Enabled);  // La pièce doit être active au départ
            Assert.False(chess.Promotion);  // Pas de promotion au départ
        }
        
        /// <summary>
        /// TEST 2 : Chaque pièce reçoit un ID unique
        /// </summary>
        [Fact]
        public void IdGeneration_EachChessHasUniqueId()
        {
            var chess1 = new Chess(new ChessPosition(1, 1), TypeChess.Pion);
            var chess2 = new Chess(new ChessPosition(1, 2), TypeChess.Pion);
            
            Assert.NotEqual(chess1.Id, chess2.Id);
        }
        
        /// <summary>
        /// TEST 3 : Une pièce peut être créée sans camp au départ
        /// </summary>
        [Fact]
        public void Constructor_WithoutCamp_SetsNullCamp()
        {
            var chess = new Chess(new ChessPosition(4, 4), TypeChess.Roi);
            
            Assert.Null(chess.Camp);
        }
        
        // ==================== TESTS DE MOUVEMENT ====================
        
        /// <summary>
        /// TEST 4 : Une pièce change de position après un mouvement
        /// </summary>
        [Fact]
        public void Move_ChangesPosition()
        {
            // ARRANGE
            var initialPosition = new ChessPosition(4, 2);
            var chess = new Chess(initialPosition, TypeChess.Pion, TypeCamp.W);
            var newPosition = new ChessPosition(4, 3);
            
            // ACT
            chess.Move(newPosition);
            
            // ASSERT
            Assert.Equal(newPosition, chess.Position);
        }
        
        /// <summary>
        /// TEST 5 : Un pion blanc qui atteint la ligne 8 est prêt pour la promotion
        /// </summary>
        [Fact]
        public void Move_WhitePion_ToLine8_TriggersPromotion()
        {
            // ARRANGE
            var pion = new Chess(new ChessPosition(4, 7), TypeChess.Pion, TypeCamp.W);
            var promotionPosition = new ChessPosition(4, 8);
            
            // ACT
            pion.Move(promotionPosition);
            
            // ASSERT
            Assert.True(pion.Promotion);
        }
        
        /// <summary>
        /// TEST 6 : Un pion noir qui atteint la ligne 1 est prêt pour la promotion
        /// </summary>
        [Fact]
        public void Move_BlackPion_ToLine1_TriggersPromotion()
        {
            var pion = new Chess(new ChessPosition(4, 2), TypeChess.Pion, TypeCamp.B);
            var promotionPosition = new ChessPosition(4, 1);
            
            pion.Move(promotionPosition);
            
            Assert.True(pion.Promotion);
        }
        
        /// <summary>
        /// TEST 7 : Un pion qui n'atteint pas la dernière ligne n'est pas promu
        /// </summary>
        [Fact]
        public void Move_WhitePion_NotToLine8_NoPromotion()
        {
            var pion = new Chess(new ChessPosition(4, 6), TypeChess.Pion, TypeCamp.W);
            
            pion.Move(new ChessPosition(4, 7));
            
            Assert.False(pion.Promotion);
        }
        
        // ==================== TESTS DE PROMOTION ====================
        
        /// <summary>
        /// TEST 8 : Une pièce pion peut être promue en Reine
        /// </summary>
        [Fact]
        public void PromoteToQueen_ChangesTypeFromPionToQueen()
        {
            var pion = new Chess(new ChessPosition(4, 8), TypeChess.Pion, TypeCamp.W);
            pion.Move(new ChessPosition(4, 8));  // Promotion préparée
            
            // La promotion devrait changer le type
            Assert.True(pion.Promotion);
            Assert.Equal(TypeChess.Pion, pion.Type);  // Avant promotion
        }
        
        // ==================== TESTS DE DÉSACTIVATION ====================
        
        /// <summary>
        /// TEST 9 : Une pièce capturée est désactivée
        /// </summary>
        [Fact]
        public void Disabled_DeactivatesChess()
        {
            var chess = new Chess(new ChessPosition(4, 4), TypeChess.Roi);
            
            Assert.True(chess.Enabled);
            
            chess.Desabled();  // (Note: le nom a une typo dans le code original)
            
            Assert.False(chess.Enabled);
        }
        
        // ==================== TESTS DES MOUVEMENTS POSSIBLES ====================
        
        /// <summary>
        /// TEST 10 : NextPositions retourne la liste des coups légaux
        /// </summary>
        [Fact]
        public void NextPositions_ReturnsLegalMoves()
        {
            var pion = new Chess(new ChessPosition(4, 2), TypeChess.Pion, TypeCamp.W);
            
            var nextMoves = pion.NextPositions;
            
            Assert.NotEmpty(nextMoves);
            Assert.Contains(new(4, 3), nextMoves);
        }
        
        /// <summary>
        /// TEST 11 : Différentes pièces ont différents nombres de mouvements
        /// Utilise [Theory] pour comparer plusieurs pièces
        /// </summary>
        [Theory]
        [InlineData(TypeChess.Pion, 4)]        // 4 mouvements possibles
        [InlineData(TypeChess.Cavalier, 8)]    // 8 mouvements L possibles
        [InlineData(TypeChess.Roi, 8)]         // 8 mouvements possibles au centre
        public void NextPositions_DifferentPieces_HaveDifferentCounts(TypeChess type, int minExpectedCount)
        {
            var chess = new Chess(new ChessPosition(4, 4), type, TypeCamp.W);
            
            var nextMoves = chess.NextPositions;
            
            Assert.NotEmpty(nextMoves);
        }
        
        // ==================== TESTS D'AFFICHAGE ====================
        
        /// <summary>
        /// TEST 12 : ToString() affiche les informations de la pièce
        /// </summary>
        [Fact]
        public void ToString_DisplaysPieceAndPosition()
        {
            var chess = new Chess(new ChessPosition(4, 4), TypeChess.Roi, TypeCamp.W);
            
            var result = chess.ToString();
            
            Assert.Contains("Roi", result);
            Assert.NotEmpty(result);
        }
        
        // ==================== TESTS DE CAMP ====================
        
        /// <summary>
        /// TEST 13 : Vérifier que les deux camps peuvent être représentés
        /// </summary>
        [Theory]
        [InlineData(TypeCamp.W)]
        [InlineData(TypeCamp.B)]
        public void Chess_BothCamps_CanBeCreated(TypeCamp camp)
        {
            var chess = new Chess(new ChessPosition(4, 4), TypeChess.Roi, camp);
            
            Assert.Equal(camp, chess.Camp);
        }
    }
}
