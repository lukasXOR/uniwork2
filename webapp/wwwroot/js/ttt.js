/******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ 182:
/***/ ((module) => {

                module.exports.D = {
                    DIMENSION: 3,
                    CANVAS_SIZE: 750,
                    WINNING_COMBINATIONS: [
                        [0, 3, 6],
                        [1, 4, 7],
                        [2, 5, 8],
                        [0, 1, 2],
                        [3, 4, 5],
                        [6, 7, 8],
                        [2, 4, 6],
                        [0, 4, 8]
                    ],
                }


                /***/
})

        /******/
});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
            /******/
}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
            /******/
};
/******/
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
        /******/
}
    /******/
    /************************************************************************/
    var __webpack_exports__ = {};
    // This entry need to be wrapped in an IIFE because it need to be in strict mode.
    (() => {
        "use strict";

        // EXTERNAL MODULE: ./src/config.js
        var config = __webpack_require__(182);
        ;// CONCATENATED MODULE: ./src/board.js

        class Board {
            constructor() {
                this.dimension = config/* Config.DIMENSION */.D.DIMENSION
                this.sectionSize = config/* Config.CANVAS_SIZE */.D.CANVAS_SIZE / this.dimension
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

        ;// CONCATENATED MODULE: ./src/canvas.js



        class Canvas {
            constructor(canvas, board = new Board()) {
                this.dimension = config/* Config.DIMENSION */.D.DIMENSION

                this.canvas = canvas
                this.canvasSize = config/* Config.CANVAS_SIZE */.D.CANVAS_SIZE

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
                for (var y = 1; y < this.dimension; y++) {
                    this.context.moveTo(lineStart, y * this.sectionSize);
                    this.context.lineTo(lineLength, y * this.sectionSize);
                }

                /*
                 * Vertical lines 
                */
                for (var x = 1; x < this.dimension; x++) {
                    this.context.moveTo(x * this.sectionSize, lineStart);
                    this.context.lineTo(x * this.sectionSize, lineLength);
                }

                this.context.stroke();
            }
            addPlayingPiece(mouse, player) {
                var xCordinate;
                var yCordinate;
                for (var i = 0; i < this.board.length; i++) {
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
            drawO(xCordinate, yCordinate) {
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
            drawX(xCordinate, yCordinate) {
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
                for (var i = 0; i < config/* Config.WINNING_COMBINATIONS.length */.D.WINNING_COMBINATIONS.length; i++) {
                    const comboData = config/* Config.WINNING_COMBINATIONS */.D.WINNING_COMBINATIONS[i]
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
        ;// CONCATENATED MODULE: ./src/engine.js

        class Engine {
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
                while (board[randomPos].player !== 0)
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
                                if (depth === 0) this.moves.push({ move: i, score })
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
                                if (depth === 0) this.moves.push({ move: i, score })
                            } else if (alpha >= beta) break
                        }
                    }
                    return beta
                }
            }
        }
        ;// CONCATENATED MODULE: ./src/index.js



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
    })();

    /******/
})()
    ;