import { Board } from './board'
import { Config } from './config'

export class Canvas {
    constructor(canvas, board = new Board()) {
      this.dimension = Config.DIMENSION

      this.canvas = canvas
      this.canvasSize = Config.CANVAS_SIZE

      this.canvas.width = this.canvasSize
      this.canvas.height = this.canvasSize
      
      this.sectionSize = this.canvasSize / this.dimension

      this.context = this.canvas.getContext('2d')
      
      this.board = board

      this.updateBoard()
  
    }
    /**
    * Clear board and redraw lines and current pieces played
    */
    updateBoard() {
      this.context.clearRect(0, 0, this.canvas.width, this.canvas.height);
      
      this.drawLines(10, "#ddd");
  
      var xCordinate;
      var yCordinate;
      var playerGo;
  
      for (var i = 0; i < this.board.length; i++) {
        const data = this.board[i]
        xCordinate = data.x;
        yCordinate = data.y;
        playerGo = data.player
        if (playerGo === 1) {
          this.drawX(xCordinate, yCordinate);
        }
        if (playerGo === 2) {
          this.drawO(xCordinate, yCordinate)
        }
      }
    }
    drawLines(lineWidth, strokeStyle) {
      const lineStart = 4;
      const lineLength = this.canvasSize - 5;
      this.context.lineWidth = lineWidth;
      this.context.lineCap = 'round';
      this.context.strokeStyle = strokeStyle;
      this.context.beginPath();
    
      /*
       * Horizontal lines 
      */
      for (var y = 1; y < this.dimension;y++) {  
        this.context.moveTo(lineStart, y * this.sectionSize);
        this.context.lineTo(lineLength, y * this.sectionSize);
      }
    
      /*
       * Vertical lines 
      */
      for (var x = 1; x < this.dimension;x++) {
        this.context.moveTo(x * this.sectionSize, lineStart);
        this.context.lineTo(x * this.sectionSize, lineLength);
      }
    
      this.context.stroke();
    }
    addPlayingPiece(mouse, player) {
      var xCordinate;
      var yCordinate;
      for (var i = 0;i < this.board.length;i++) {
        const data = this.board[i]
        xCordinate = data.x;
        yCordinate = data.y;
        // if coords fall into a sector update the player
        if (
            mouse.x >= xCordinate && mouse.x <= xCordinate + this.sectionSize &&
            mouse.y >= yCordinate && mouse.y <= yCordinate + this.sectionSize
          ) {
            if (data.player !== 0) return 0 // sector already been played
            data.player = player
        }
      }
      this.updateBoard()
    }
    drawO (xCordinate, yCordinate) {
      const halfSectionSize = (0.5 * this.sectionSize);
      const centerX = xCordinate + halfSectionSize;
      const centerY = yCordinate + halfSectionSize;
      const radius = (this.sectionSize - 100) / 2;
      const startAngle = 0 * Math.PI; 
      const endAngle = 2 * Math.PI;
    
      this.context.lineWidth = 10;
      this.context.strokeStyle = "#01bBC2";
      this.context.beginPath();
      this.context.arc(centerX, centerY, radius, startAngle, endAngle);
      this.context.stroke();
    }
    drawX (xCordinate, yCordinate) {
      this.context.strokeStyle = "#f1be32";
    
      this.context.beginPath();
      
      const offset = 50;
      this.context.moveTo(xCordinate + offset, yCordinate + offset);
      this.context.lineTo(xCordinate + this.sectionSize - offset, yCordinate + this.sectionSize - offset);
    
      this.context.moveTo(xCordinate + offset, yCordinate + this.sectionSize - offset);
      this.context.lineTo(xCordinate + this.sectionSize - offset, yCordinate + offset);
    
      this.context.stroke();
    }
    /**
    * Check for a winner.
    * @param matrix Matrix of the board to check
    * @param final Boolean to indicate whether we should update the winner message
    */
    static checkWin(matrix, final = false) {
      var isDraw = 3
      for (var i = 0; i < Config.WINNING_COMBINATIONS.length; i++) { 
        const comboData = Config.WINNING_COMBINATIONS[i]
        const firstPlayer = matrix[comboData[0]].player
        var allEqual = true
        for (var j = 0; j < comboData.length; j++) {
          if (matrix[comboData[j]].player !== firstPlayer) allEqual = false
          if (matrix[comboData[j]].player === 0) isDraw = 0
        }
        if (allEqual && firstPlayer !== 0) {
          if (final) {
            var winner = firstPlayer === 1 ? 'X' : 'O'
            document.getElementById('winner').innerText = winner + ' wins'
          }
          return firstPlayer
        }
      }
      if (isDraw === 3) {
        if (final) document.getElementById('winner').innerText = 'Draw'
        return isDraw 
      }
      return undefined
    }
  }