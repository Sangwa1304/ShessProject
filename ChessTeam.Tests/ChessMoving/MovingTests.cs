using Xunit;
using ChessTeam.ChessLogical;
using ChessTeam.ChessMoving;

namespace ChessTeam.Tests.ChessMoving
{
    /// <summary>
    /// Tests pour la classe Moving
    /// Vérifie que les mouvements de chaque pièce sont calculés correctement
    /// </summary>
    public class MovingTests
    {
        // ==================== TESTS DES POSITIONS VALIDES ====================
        
        /// <summary>
        /// TEST 1 : Le Roi peut se déplacer d'une case dans toutes les directions
        /// </summary>
        [Fact]
        public void King_FromCenter_HasEightMoves()
        {
            // ARRANGE
            var centerPosition = new ChessPosition(4, 4);
            
            // ACT
            var moves = Moving.RunFonc(TypeChess.Roi, TypeCamp.W, centerPosition);
            
            // ASSERT - Le roi au centre doit avoir 8 mouvements
            Assert.Equal(8, moves.Count);
        }
        
        /// <summary>
        /// TEST 2 : Le Cavalier fait un mouvement en L (2 cases + 1 case)
        /// </summary>
        [Fact]
        public void Knight_FromCenter_HasEightMoves()
        {
            var centerPosition = new ChessPosition(4, 4);
            
            var moves = Moving.RunFonc(TypeChess.Cavalier, TypeCamp.W, centerPosition);
            
            Assert.Equal(8, moves.Count);
        }
        
        /// <summary>
        /// TEST 3 : La Dame combine les mouvements du Roi, Fou et Tour
        /// </summary>
        [Fact]
        public void Queen_FromCenter_HasManyMoves()
        {
            var centerPosition = new ChessPosition(4, 4);
            
            var moves = Moving.RunFonc(TypeChess.Reine, TypeCamp.W, centerPosition);
            
            // La Reine peut se déplacer partout (sauf sortir du plateau)
            Assert.NotEmpty(moves);
        }
        
        /// <summary>
        /// TEST 4 : La Tour se déplace horizontalement et verticalement
        /// </summary>
        [Fact]
        public void Rook_FromCenter_MovesInStraightLines()
        {
            var centerPosition = new ChessPosition(4, 4);
            
            var moves = Moving.RunFonc(TypeChess.Tour, TypeCamp.W, centerPosition);
            
            // La tour couvre toute la ligne et colonne
            for (int i = 1; i <= 8; i++)
            {
                if (i != 4)
                {
                    Assert.Contains(new(4, i), moves);
                    Assert.Contains(new(i, 4), moves);
                }
            }
        }
        
        /// <summary>
        /// TEST 5 : Le Fou se déplace en diagonale
        /// </summary>
        [Fact]
        public void Bishop_FromCenter_MovesDiagonally()
        {
            var centerPosition = new ChessPosition(4, 4);
            
            var moves = Moving.RunFonc(TypeChess.Fou, TypeCamp.W, centerPosition);
            
            Assert.NotEmpty(moves);
        }
        
        // ==================== TESTS DU PION ====================
        
        /// <summary>
        /// TEST 6 : Le pion blanc peut se déplacer de 1 ou 2 cases depuis la position de départ
        /// </summary>
        [Fact]
        public void Pion_White_FromStartPosition_CanAdvanceTwoSquares()
        {
            var startPosition = new ChessPosition(4, 2);
            
            var moves = Moving.RunFonc(TypeChess.Pion, TypeCamp.W, startPosition);
            
            Assert.Contains(new(4, 3), moves);
            Assert.Contains(new(4, 4), moves);
        }
        
        /// <summary>
        /// TEST 7 : Le pion blanc capture en diagonale vers le haut
        /// </summary>
        [Fact]
        public void Pion_White_CanCaptureOnDiagonals()
        {
            var position = new ChessPosition(4, 4);
            
            var moves = Moving.RunFonc(TypeChess.Pion, TypeCamp.W, position);
            
            Assert.Contains(new(3, 5), moves);
            Assert.Contains(new(5, 5), moves);
        }
        
        /// <summary>
        /// TEST 8 : Le pion noir avance vers le bas (Y-)
        /// </summary>
        [Fact]
        public void Pion_Black_FromStartPosition_AdvancesDownward()
        {
            var startPosition = new ChessPosition(4, 7);
            
            var moves = Moving.RunFonc(TypeChess.Pion, TypeCamp.B, startPosition);
            
            Assert.Contains(new(4, 6), moves);
            Assert.Contains(new(4, 5), moves);
        }
        
        /// <summary>
        /// TEST 9 : Le pion requiert un camp (ne peut pas être null)
        /// </summary>
        [Fact]
        public void Pion_WithNullCamp_ThrowsArgumentException()
        {
            var position = new ChessPosition(4, 4);
            
            Assert.Throws<ArgumentException>(() =>
                Moving.RunFonc(TypeChess.Pion, null, position)
            );
        }
        
        // ==================== TESTS DE LIMITES (BORDS DU PLATEAU) ====================
        
        /// <summary>
        /// TEST 10 : Les pièces au coin ne sortent pas du plateau
        /// </summary>
        [Fact]
        public void King_AtCorner_OnlyHasThreeMoves()
        {
            var cornerPosition = new ChessPosition(1, 1);
            
            var moves = Moving.RunFonc(TypeChess.Roi, TypeCamp.W, cornerPosition);
            
            Assert.Equal(3, moves.Count);
        }
        
        /// <summary>
        /// TEST 11 : Vérifier qu'aucun mouvement ne sort du plateau
        /// Utilise [Theory] pour tester toutes les pièces
        /// </summary>
        [Theory]
        [InlineData(TypeChess.Roi)]
        [InlineData(TypeChess.Cavalier)]
        [InlineData(TypeChess.Tour)]
        [InlineData(TypeChess.Fou)]
        [InlineData(TypeChess.Reine)]
        public void AllPieces_AllMoves_AreWithinBoard(TypeChess pieceType)
        {
            var position = new ChessPosition(4, 4);
            
            var moves = Moving.RunFonc(pieceType, TypeCamp.W, position);
            
            foreach (var move in moves)
            {
                Assert.InRange(move.X, 1, 8);
                Assert.InRange(move.Y, 1, 8);
            }
        }
        
        // ==================== TESTS DE COMPARAISON ====================
        
        /// <summary>
        /// TEST 12 : Comparer les mouvements de deux pièces différentes
        /// </summary>
        [Fact]
        public void Knight_HasFewerMoves_ThanRook_FromSamePosition()
        {
            var position = new ChessPosition(4, 4);
            
            var knightMoves = Moving.RunFonc(TypeChess.Cavalier, TypeCamp.W, position);
            var rookMoves = Moving.RunFonc(TypeChess.Tour, TypeCamp.W, position);
            
            Assert.True(knightMoves.Count < rookMoves.Count);
        }
    }
}
