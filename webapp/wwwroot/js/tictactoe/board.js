import { Config } from './config'
export class Board {
    constructor() {
      this.dimension = Config.DIMENSION
      this.sectionSize = Config.CANVAS_SIZE / this.dimension
      return this.newBoard()
    }
    /**
    * Create a new board with the coordinates of where the sectors
    * will be
    */
    newBoard() {
      var board = []
      for (var i = 0, colomn = 0, row = 0; i < this.dimension * this.dimension; i++) {
        if (i % this.dimension === 0) {
          row = 0
          colomn = this.sectionSize * (i / this.dimension)
        }
        board[i] = {
          x: row++ * this.sectionSize,
          y: colomn,
          player: 0,
        }
      }
      return board
    }
  }
