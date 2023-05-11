import { Canvas } from './canvas.js'
export class Engine {
  constructor(player = 1, maxDepth = false) {
    this.player = player
    this.oppPlayer = player === 1 ? 2 : 1
    this.moves = []
    this.maxDepth = maxDepth
 }
  move(board) {
    this.moves = []

    // structuredClone will give us a copy of an
    // array that wont be referenced to the original
    // so we can make changes to the cloned array
    // without changing the original
    var dummyBoard = structuredClone(board);

    // At the start of the game, there are no moves that are better than the other
    // So use an opening book
    var playerPieces = dummyBoard.filter(piece => piece.player !== 0)
    if (playerPieces.length === 1 || playerPieces.length === 0) return this.openingBook(dummyBoard)

    // get best moves
    this.getBestMoves(undefined, dummyBoard, true)

    var bestMoves = this.moves.filter((data) => {
      return data.score === Math.max(...this.moves.map((move) => {
        return move.score
      }))
    })

    // if there are multiple best options, pick a random one
    var bestMove = bestMoves[Math.floor(Math.random() * bestMoves.length)]
    return bestMove.move
  }  
  /**
  * Generate a random legal move
  * @param board Array of the board
  * @returns Index of a random move
  */
  randomMove(board) {
    do var randomPos = Math.floor(Math.random() * board.length) 
    while(board[randomPos].player !== 0)
    return randomPos
  }
  /**
  * Usually it's better to play the middle piece, so if the game has
  * just started or if the user has played its first move then 
  * play the middle piece or a random move.
  * @param board Array of the board
  * @returns Opening book move
  */
  openingBook(board) {
    if (board[4].player === this.oppPlayer) {
      return this.randomMove(board)
    } else if (board[4].player === 0) return 4
  }
  /**
  * The minimax algoirthm with alpha-beta pruning. Searches all possible moves
  * evaulating each position with a score depending on who won and how far the 
  * depth of the search is. Positions may be pruned if a position in a branch is
  * worse than the previous branches best score.
  * https://media.geeksforgeeks.org/wp-content/uploads/MIN_MAX3.jpg
  * @param depth Int of How far the search is at
  * @param board Array of the board to evaluate 
  * @param isMax Boolean indicating if we want to maximise or minimise the best score
  * @param alpha Int of the alpha value. Defaults at -Infinity because we want the best score
  * @param beta Int of the beta value. Defaults at Infinity because we want the worst score
  * @returns The index of the best move to player
  */
  getBestMoves(depth = 0, board, isMax, alpha = -Infinity, beta = Infinity) {
    if (depth === this.maxDepth) return 0

    var winner = Canvas.checkWin(board)

    // At terminal state return score based on who won and how far ahead the state is
    if (winner === this.player) return 100 - depth
    if (winner === this.oppPlayer) return -100 + depth                                  
    if (winner === 3) return 0 // Draw

    if (isMax) {
      for (var i = 0; i < board.length; i++) {
        if (board[i].player === 0) {
          var newBoard = structuredClone(board)
          newBoard[i].player = this.player

          var score = this.getBestMoves(depth + 1, newBoard, false, alpha, beta)

          if (score > alpha) {
            alpha = score;
            if (depth === 0) this.moves.push({move: i, score})
          } else if (alpha >= beta) break
        }
      } 
      return alpha
    } else {
      for (var i = 0; i < board.length; i++) {
        if (board[i].player === 0) {
          var newBoard = structuredClone(board)
          newBoard[i].player = this.oppPlayer

          var score = this.getBestMoves(depth + 1, newBoard, true, alpha, beta)

          if (beta > score) {
            beta = score;
            if (depth === 0) this.moves.push({move: i, score})
          } else if (alpha >= beta) break
        }
      }
      return beta
    }
  }
}