const suits = ["spades", "hearts", "clubs", "diams"];
const ranks = ["A", 2, 3, 4, 5, 6, 7, 8, 9, 10, "J", "Q", "K"];
const score = [0, 0];

//Created base class
class JackPlayer {
	constructor() {
		this.wins = 0;
		this.score = 0;
		this.hand;
		this.cards;
	}
}
//created dealer and extended the base class
class Dealer extends JackPlayer {
	constructor() {//called super on the base constructor
		super();
	}
}
//created player and extended the base class Jack player
class Player extends JackPlayer {
	constructor() {//called super on the base constructor
		super();//added the cash and bet properties to player
		this.cash = 100;
		this.bet = 0;
	}
}

class BlackJack {

	constructor() {}
// I initialized all of my functions within this function
	initialize() {
		/// console.log('initialize ready');
		this.player = new Player();
		this.dealer = new Dealer();
		this.roundEnded = true;
		this.buildGameBoard();
		this.turnOff(this.btnHit);
		this.turnOff(this.btnStand);
		this.buildDeck();
		this.addClicker();
		this.scoreBoard();
		this.updateCash();
	}

	updateCash() {
		console.log(isNaN(this.inputBet.value));
		if (isNaN(this.inputBet.value) || this.inputBet.value.length < 1) {
			this.inputBet.value = 0;
		}
		if (this.inputBet.value > this.player.cash) {
			this.inputBet.value = this.player.cash;
		}
		this.player.bet = Number(this.inputBet.value);
		this.playerCash.textContent = "Player Cash $" + (this.player.cash - this.player.bet);
	}

	lockWager(tog) {
		this.inputBet.disabled = tog;
		this.betButton.disabled = tog;
		if (tog) {
			this.betButton.style.backgroundColor = "#ddd";
			this.inputBet.style.backgroundColor = "#ddd";
		} else {
			this.betButton.style.backgroundColor = "#000";
			this.inputBet.style.backgroundColor = "#fff";
		}
	}

	setBet() {
		this.status.textContent = "You bet $" + this.player.bet;
		this.player.cash = this.player.cash - this.player.bet;
		this.playerCash.textContent = "Player Cash $" + this.player.cash;
		this.lockWager(true);
	}

	scoreBoard() {
		this.scoreboard.textContent = `Dealer ${this.dealer.wins} vs Player ${this.player.wins}`;
	}

	addClicker() {
		// saved instance of this to use in the scope of the
		// event listener functions
		let _this = this;
		this.btnDeal.addEventListener('click', () => {
			_this.deal();
		});
		this.btnStand.addEventListener('click', () => {
			_this.playerStand();
		});
		this.btnHit.addEventListener('click', () => {
			_this.nextCard();
		});
		this.betButton.addEventListener('click', () => {
			_this.setBet();
		});
		this.inputBet.addEventListener('change', () => {
			_this.updateCash();
		});
	}

	deal() {
		this.roundEnded = false;
		this.dealer.hand = [];
		this.player.hand = [];
		this.dealerScore.textContent = "*";
		this.start = true;
		this.lockWager(true);
		this.turnOff(this.btnDeal);
		this.player.cards.innerHTML = "";
		this.dealer.cards.innerHTML = "";
		this.takeCard(this.dealer.hand, this.dealer.cards, true);
		this.takeCard(this.dealer.hand, this.dealer.cards, false);
		this.takeCard(this.player.hand, this.player.cards, false);
		this.takeCard(this.player.hand, this.player.cards, false);
		this.updateCount();
	}

	playerStand() {
		this.dealerPlay();
		this.turnOff(this.btnHit);
		this.turnOff(this.btnStand);
	}

	nextCard() {
		this.takeCard(this.player.hand, this.player.cards, false);
		this.updateCount();
	}

	findWinner() {
		if (this.roundEnded) return;
		let player = this.scorer(this.player.hand);
		let dealer = this.scorer(this.dealer.hand);
		console.log(player, dealer);
		if (player > 21) {
			this.status.textContent = "You Busted with " + player + " ";
		}
		if (dealer > 21) {
			this.status.textContent = "Dealer Busted with " + dealer + " ";
		}
		//check winner
		if (player == dealer) {
			this.status.textContent = "Draw no winners " + player + " ";
			this.player.cash += this.player.bet;
		} else if ((player < 22 && player > dealer) || dealer > 21) {
			this.status.textContent += "You Win with " + player + " ";
			this.player.cash += this.player.bet * 2;
			this.player.wins++;
		} else {
			this.status.textContent += "Dealer wins with ";
			if (dealer != 21) {
				this.status.textContent += dealer + " ";
			} else {
				this.status.textContent += "BlackJack ";
			}
			this.dealer.wins++;
		}
		if (this.player.cash < 1) {
			this.player.cash = 0;
			this.player.bet = 0;
		}
		//this.updateCash();
		this.scoreBoard();
		this.playerCash.textContent = "Player Cash $" + this.player.cash;
		this.lockWager(false);
		this.turnOff(this.btnHit);
		this.turnOff(this.btnStand);
		this.turnOn(this.btnDeal);
		this.gameEnd();
	}

	dealerPlay() {
		let dealer = this.scorer(this.dealer.hand);
		this.cardBack.style.display = "none";
		/// console.log(dealer);
		this.status.textContent = "Dealer score " + dealer + " ";
		if (dealer >= 17) {
			this.dealerScore.textContent = dealer;
			this.findWinner();
		} else {
			this.takeCard(this.dealer.hand, this.dealer.cards, false);
			this.dealerScore.textContent = dealer;
			this.dealerPlay();
		}
	}

	scorer(hand) {
		let total = 0;
		let ace = 0;
		for (let card of hand) {
			/// console.log(card);
			if (card.rank == "A") {
				ace++;
			}
			total = total + Number(card.value);
		}
		if (ace > 0 && total > 21) {
			total = this.scoreAce(total, ace);
		}
		if (total > 21) {
			return Number(total);
		}
		/// console.log(hand);
		return Number(total);
	}

	updateCount() {
		let player = this.scorer(this.player.hand);
		let dealer = this.scorer(this.dealer.hand);
		/// console.log(player, dealer);
		this.playerScore.textContent = player;
		if (player < 21) {
			this.turnOn(this.btnHit);
			this.turnOn(this.btnStand);
			this.status.textContent = "Stand or take another card";
		} else if (player > 21) {
			this.findWinner();
		} else {
			this.status.textContent = "Dealer in Play to 17 minimum";
			this.dealerPlay(dealer);
		}
	}

	scoreAce(val, aces) {
		if (val < 21) {
			return val;
		} else if (aces > 0) {
			aces--;
			val = val - 10;
			return this.scoreAce(val, aces);
		} else {
			return val;
		}
	}

	gameEnd() {
		this.cardBack.style.display = "none";
		this.turnOff(this.btnHit);
		this.turnOff(this.btnStand);
		this.roundEnded = true;
		console.log('ended');
	}

	takeCard(hand, ele, h) {
		if (this.deck.length == 0) {
			this.buildDeck();
		}
		let temp = this.deck.shift();
		/// console.log(temp);
		hand.push(temp);
		/// console.log(this);
		this.showCard(temp, ele);
		if (h) {
			this.cardBack = document.createElement('div');
			this.cardBack.classList.add('cardB');
			ele.append(this.cardBack);
		}
	}

	showCard(card, el) {
		if (card != undefined) {
			//el.innerHTML = card.rank + "&" + card.suit + ";";
			el.style.backgroundColor = "white";
			let div = document.createElement("div");
			div.classList.add('card');
			if (card.suit === "hearts" || card.suit === "diams") {
				div.classList.add('red');
			}
			let span1 = document.createElement('div');
			span1.innerHTML = card.rank + "&" + card.suit + ";";
			span1.classList.add('tiny');
			div.appendChild(span1);
			let span2 = document.createElement('div');
			span2.innerHTML = card.rank;
			span2.classList.add('big');
			div.appendChild(span2);
			let span3 = document.createElement('div');
			span3.innerHTML = "&" + card.suit + ";";
			span3.classList.add('big');
			div.appendChild(span3);
			el.appendChild(div);
		}
	}

	turnOff(btn) {
		btn.disabled = true;
		btn.style.backgroundColor = "#ddd";
	}

	turnOn(btn) {
		btn.disabled = false;
		btn.style.backgroundColor = "#000";
	}
//I set the deck as an array
	buildDeck() {
		this.deck = [];
		//I used for loops to iterate through the deck to make the cards using the rank suit and value
		for (let i = 0; i < suits.length; i++) {
			for (let j = 0; j < ranks.length; j++) {
				let card = {};
				let tempValue = isNaN(ranks[j]) ? 10 : ranks[j];
				tempValue = (ranks[j] == "A") ? 11 : tempValue;
				card.suit = suits[i];
				card.rank = ranks[j];
				card.value = tempValue;
				///// console.log(suits[i],ranks[j],tempValue);
				this.deck.push(card);
			}
		}
		this.shuffle(this.deck);
		/// console.log(this.deck);
	}

	shuffle(cards) {
		cards.sort(function() {
			return .5 - Math.random();
		})
		return cards;
	}
// I created this function to style my gameboard along with the css
	buildGameBoard() {
		this.main = document.querySelector('#game');
		/// console.log(this);
		this.scoreboard = document.createElement('div');
		this.scoreboard.textContent = "Dealer 0 vs Player 0";
		this.scoreboard.style.fontSize = "2em";
		this.main.append(this.scoreboard);
		let table = document.createElement('div');
		let dealerDiv = document.createElement('div');
		this.dealer.cards = document.createElement('div');
		this.dealer.cards.textContent = "DEALER CARD";
		this.dealerScore = document.createElement('div');
		this.dealerScore.textContent = "-";
		this.dealerScore.classList.add('score');
		dealerDiv.append(this.dealerScore);
		dealerDiv.append(this.dealer.cards);
		table.append(dealerDiv);
		let playerDiv = document.createElement('div');
		this.player.cards = document.createElement('div');
		this.player.cards.textContent = "PLAYER CARD";
		this.playerScore = document.createElement('div');
		this.playerScore.textContent = "-";
		this.playerScore.classList.add('score');
		playerDiv.append(this.playerScore);
		playerDiv.append(this.player.cards);
		table.append(playerDiv);
		this.dashboard = document.createElement('div');
		this.status = document.createElement('div');
		this.status.classList.add('message');
		this.status.textContent = "Message for Player";
		this.dashboard.append(this.status);
		this.btnDeal = document.createElement('button');
		this.btnDeal.textContent = "DEAL";
		this.btnDeal.classList.add('btn');
		this.dashboard.append(this.btnDeal);
		this.btnHit = document.createElement('button');
		this.btnHit.textContent = "HIT";
		this.btnHit.classList.add('btn');
		this.dashboard.append(this.btnHit);
		this.btnStand = document.createElement('button');
		this.btnStand.textContent = "STAND";
		this.btnStand.classList.add('btn');
		this.dashboard.append(this.btnStand);
		this.playerCash = document.createElement('div');
		this.playerCash.classList.add('message');
		this.playerCash.textContent = "Player Cash $100";
		this.dashboard.append(this.playerCash);
		this.inputBet = document.createElement('input');
		this.inputBet.setAttribute('type', 'number');
		this.inputBet.style.width = "4em";
		this.inputBet.style.fontSize = "1.4em";
		this.inputBet.style.marginTop = "1em";
		this.inputBet.value = 0;
		this.dashboard.append(this.inputBet);
		this.betButton = document.createElement('button');
		this.betButton.textContent = "Bet Amount";
		this.betButton.classList.add('btn');
		this.dashboard.append(this.betButton);
		table.append(this.dashboard);
		this.main.append(table);
	}

}
