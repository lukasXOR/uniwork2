import { Canvas } from './canvas'
import { Board } from './board'
import { Engine } from './engine'
const canvas = new Canvas(document.getElementById('tic-tac-toe-board'), new Board(), 1)
const engine = new Engine(1)
const engine2 = new Engine(2)
const game = {
  turn: 0,
  players: [0, engine2],
  start() {
    document.getElementById('winner').innerText = 'Game started'
    this.turn = 0
    if (this.players.includes(0)) {

      if (this.players[0] instanceof Engine) { 
        this.turn ^= 1
        this.moved()
        canvas.updateBoard()
      }

      canvas.canvas.onmouseup = (event) => {
        const rect = canvas.canvas.getBoundingClientRect();
        const canvasMousePosition = {
            x: event.clientX - rect.left,
            y: event.clientY - rect.top
          }
        if (canvas.addPlayingPiece(canvasMousePosition, this.turn + 1) === 0) return
    
        if (Canvas.checkWin(canvas.board, true)) return // Someone already won / game drawn
        
        this.moved()
    
        canvas.updateBoard()
    
        Canvas.checkWin(canvas.board, true)
      };
    
    } else {
      var AIPlayers = setInterval(() => {
        this.moved()

        canvas.updateBoard()

        this.turn ^= 1

        if (Canvas.checkWin(canvas.board, true)) clearInterval(AIPlayers)
      }, 500);
    }
  },
  moved() {
    this.turn ^= 1

    var player = this.players[this.turn]
    if (player instanceof Engine) {
      canvas.board[player.move(canvas.board)].player = player.player
      this.turn ^= 1
    }
  }
}
document.getElementById('newGame').onclick = () => {
  canvas.board = new Board()
  canvas.updateBoard()
  
  var p1 = document.getElementById('player1')
  var player1 = p1.options[p1.selectedIndex].text
  if (player1 === 'Player') game.players[0] = 0
  if (player1 === 'AI') game.players[0] = engine

  var p2 = document.getElementById('player2')
  var player2 = p2.options[p2.selectedIndex].text
  if (player2 === 'Player') game.players[1] = 0
  if (player2 === 'AI') game.players[1] = engine2

  game.start()
}
game.start()