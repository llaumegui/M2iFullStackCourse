const TILE_SIZE = 64;
const MAP_NUM_ROWS = 13;
const MAP_NUM_COLS = 20;

const WINDOW_WIDTH = MAP_NUM_COLS * TILE_SIZE;
const WINDOW_HEIGHT = MAP_NUM_ROWS * TILE_SIZE;

const FOV_ANGLE = 60 * (Math.PI / 180);

const WALL_STRIP_WIDTH = 4; //thickness of the wall render
const NUM_RAYS = WINDOW_WIDTH / WALL_STRIP_WIDTH;

const MINIMAP_SCALE_FACTOR = 0.2;

const DEPTH_FACTOR = 2;

class Map {
	constructor() {
		this.grid = [
			[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
			[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1],
			[1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1],
			[1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1],
			[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1],
			[1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1],
			[1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1],
			[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
			[1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1],
			[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1],
			[1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1],
			[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
			[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
		];
	}

	render() {
		for (var i = 0; i < MAP_NUM_ROWS; i++) {
			for (var j = 0; j < MAP_NUM_COLS; j++) {
				var tileX = j * TILE_SIZE;
				var tileY = i * TILE_SIZE;
				var tileColor = this.grid[i][j] == 1 ? "#222" : "#fff";
				stroke("#222");
				fill(tileColor);
				rect(
					MINIMAP_SCALE_FACTOR * tileX,
					MINIMAP_SCALE_FACTOR * tileY,
					MINIMAP_SCALE_FACTOR * TILE_SIZE,
					MINIMAP_SCALE_FACTOR * TILE_SIZE
				);
			}
		}
	}

	hasWallAt(x, y) {
		if (x < 0 || x > WINDOW_WIDTH || y < 0 || y > WINDOW_HEIGHT) return true;

		var mapGridIndexX = Math.floor(x / TILE_SIZE);
		var mapGridIndexY = Math.floor(y / TILE_SIZE);

		return this.grid[mapGridIndexY][mapGridIndexX] != 0;
	}
}

class Player {
	constructor() {
		this.x = WINDOW_WIDTH / 2;
		this.y = WINDOW_HEIGHT / 2;
		this.radius = 5;
		this.turnDirection = 0; //-1 if left or +1 if right
		this.walkDirection = 0; //-1 if backward or +1 if forward
		this.rotationAngle = Math.PI / 2;
		this.moveSpeed = 2.0;
		this.rotationSpeed = 2 * (Math.PI / 180); //2 degrees per rotation
	}
	render() {
		noStroke();
		fill("red");
		circle(MINIMAP_SCALE_FACTOR * this.x, MINIMAP_SCALE_FACTOR * this.y, MINIMAP_SCALE_FACTOR * this.radius);

		stroke("blue");
		line(
			MINIMAP_SCALE_FACTOR * player.x,
			MINIMAP_SCALE_FACTOR * player.y,
			MINIMAP_SCALE_FACTOR * (player.x + Math.cos(this.rotationAngle) * 10),
			MINIMAP_SCALE_FACTOR * (player.y + Math.sin(this.rotationAngle) * 10)
		);
	}

	update() {
		this.rotationAngle += this.turnDirection * this.rotationSpeed;

		var moveStep = this.walkDirection * this.moveSpeed;
		var nextX = this.x + Math.cos(this.rotationAngle) * moveStep;
		var nextY = this.y + Math.sin(this.rotationAngle) * moveStep;

		if (!grid.hasWallAt(nextX, nextY)) {
			this.x = nextX;
			this.y = nextY;
		}
	}
}

class Ray {
	constructor(rayAngle) {
		this.rayAngle = normalizeAngle(rayAngle);
		this.wallHitX = 0;
		this.wallHitY = 0;
		this.distance = 0;
		this.wasHitVertical = false;

		this.isRayFacingDown = this.rayAngle > 0 && this.rayAngle < Math.PI;
		this.isRayFacingUp = !this.isRayFacingDown;

		this.isRayFacingRight = this.rayAngle < 0.5 * Math.PI || this.rayAngle > 1.5 * Math.PI;
		this.isRayFacingLeft = !this.isRayFacingRight;
	}

	cast(columnId) {
		var xIntercept, yIntercept;
		var xStep, yStep;

		///////////////////////////////////////////
		// HORIZONTAL RAY-GRID INTERSECTION CODE //
		///////////////////////////////////////////
		var foundHorzWallHit = false;
		var horzWallHitX = 0;
		var horzWallHitY = 0;

		// find the y-coordinate of the closest horizontal grid intersection
		yIntercept = Math.floor(player.y / TILE_SIZE) * TILE_SIZE;
		yIntercept += this.isRayFacingDown ? TILE_SIZE : 0;

		// find the x-coordinate of the closest horizontal grid intersection
		xIntercept = player.x + (yIntercept - player.y) / Math.tan(this.rayAngle);

		// calculate the increment xStep & yStep
		yStep = TILE_SIZE;
		yStep *= this.isRayFacingUp ? -1 : 1;

		xStep = TILE_SIZE / Math.tan(this.rayAngle);
		xStep *= this.isRayFacingLeft && xStep > 0 ? -1 : 1;
		xStep *= this.isRayFacingRight && xStep < 0 ? -1 : 1;

		var nextHorzTouchX = xIntercept;
		var nextHorzTouchY = yIntercept;

		// increment xstep & ystep until we find a wall
		while (
			nextHorzTouchX >= 0 &&
			nextHorzTouchX <= WINDOW_WIDTH &&
			nextHorzTouchY >= 0 &&
			nextHorzTouchY <= WINDOW_HEIGHT
		) {
			if (grid.hasWallAt(nextHorzTouchX, nextHorzTouchY - (this.isRayFacingUp ? 1 : 0))) {
				// WE FOUND A WALL HIT
				foundHorzWallHit = true;
				horzWallHitX = nextHorzTouchX;
				horzWallHitY = nextHorzTouchY;
				break;
			} else {
				nextHorzTouchX += xStep;
				nextHorzTouchY += yStep;
			}
		}

		/////////////////////////////////////////
		// VERTICAL RAY-GRID INTERSECTION CODE //
		/////////////////////////////////////////
		var foundVertWallHit = false;
		var vertWallHitX = 0;
		var vertWallHitY = 0;

		// find the x-coordinate of the closest vertical grid intersection
		xIntercept = Math.floor(player.x / TILE_SIZE) * TILE_SIZE;
		xIntercept += this.isRayFacingRight ? TILE_SIZE : 0;

		// find the y-coordinate of the closest vertical grid intersection
		yIntercept = player.y + (xIntercept - player.x) * Math.tan(this.rayAngle);

		// calculate the increment xStep & yStep
		xStep = TILE_SIZE;
		xStep *= this.isRayFacingLeft ? -1 : 1;

		yStep = TILE_SIZE * Math.tan(this.rayAngle);
		yStep *= this.isRayFacingUp && yStep > 0 ? -1 : 1;
		yStep *= this.isRayFacingDown && yStep < 0 ? -1 : 1;

		var nextVertTouchX = xIntercept;
		var nextVertTouchY = yIntercept;

		// increment xstep & ystep until we find a wall
		while (
			nextVertTouchX >= 0 &&
			nextVertTouchX <= WINDOW_WIDTH &&
			nextVertTouchY >= 0 &&
			nextVertTouchY <= WINDOW_HEIGHT
		) {
			if (grid.hasWallAt(nextVertTouchX - (this.isRayFacingLeft ? 1 : 0), nextVertTouchY)) {
				// WE FOUND A WALL HIT
				foundVertWallHit = true;
				vertWallHitX = nextVertTouchX;
				vertWallHitY = nextVertTouchY;
				break;
			} else {
				nextVertTouchX += xStep;
				nextVertTouchY += yStep;
			}
		}

		// Calculate both horizontal and vertical distances and choose the smallest one
		var horzHitDistance = foundHorzWallHit
			? distanceBetweenPoints(player.x, player.y, horzWallHitX, horzWallHitY)
			: Number.MAX_VALUE;
		var vertHitDistance = foundVertWallHit
			? distanceBetweenPoints(player.x, player.y, vertWallHitX, vertWallHitY)
			: Number.MAX_VALUE;

		// Only store the smallest values
		if (vertHitDistance < horzHitDistance) {
			this.wallHitX = vertWallHitX;
			this.wallHitY = vertWallHitY;
			this.distance = vertHitDistance;
			this.wasHitVertical = true;
		} else {
			this.wallHitX = horzWallHitX;
			this.wallHitY = horzWallHitY;
			this.distance = horzHitDistance;
			this.wasHitVertical = false;
		}
	}

	render() {
		stroke("rgba(255,0,0,0.3)");
		line(
			MINIMAP_SCALE_FACTOR * player.x,
			MINIMAP_SCALE_FACTOR * player.y,
			MINIMAP_SCALE_FACTOR * this.wallHitX,
			MINIMAP_SCALE_FACTOR * this.wallHitY
		);
	}
}

var grid = new Map();
var player = new Player();
var rays = [];

function keyPressed() {
	if (keyCode == UP_ARROW) {
		player.walkDirection = 1;
	} else if (keyCode == DOWN_ARROW) {
		player.walkDirection = -1;
	} else if (keyCode == RIGHT_ARROW) {
		player.turnDirection = 1;
	} else if (keyCode == LEFT_ARROW) {
		player.turnDirection = -1;
	}
}
function keyReleased() {
	if (keyCode == UP_ARROW) {
		player.walkDirection = 0;
	} else if (keyCode == DOWN_ARROW) {
		player.walkDirection = 0;
	} else if (keyCode == RIGHT_ARROW) {
		player.turnDirection = 0;
	} else if (keyCode == LEFT_ARROW) {
		player.turnDirection = 0;
	}
}

function castAllRays() {
	//start first ray substracting half of the FOV
	var rayAngle = player.rotationAngle - FOV_ANGLE / 2;
	rays = [];

	for (var column = 0; column < NUM_RAYS; column++) {
		var ray = new Ray(rayAngle);
		ray.cast(column);
		rays.push(ray);
		rayAngle += FOV_ANGLE / NUM_RAYS;
	}
}

function renderProjectedWalls() {
	// loop every ray in the array rays
	for (var i = 0; i < NUM_RAYS; i++) {
		var ray = rays[i];

		var rayDistance = ray.distance * Math.cos(ray.rayAngle - player.rotationAngle); // prevent the fishbowl effect

		var distanceProjectionPlane = WINDOW_WIDTH / 2 / Math.tan(FOV_ANGLE / 2);

		// projected wall height
		var wallStripHeight = (TILE_SIZE / rayDistance) * distanceProjectionPlane;

		// compute the transparencu based on the wall distance
		var depth = lerp(0, 1.0, (TILE_SIZE * DEPTH_FACTOR) / rayDistance);

		fill("rgba(255, 255, 255, " + depth + ")");
		noStroke(); // no borders
		rect(i * WALL_STRIP_WIDTH, WINDOW_HEIGHT / 2 - wallStripHeight / 2, WALL_STRIP_WIDTH, wallStripHeight);
	}
}

function normalizeAngle(angle) {
	angle = angle % (2 * Math.PI);
	if (angle < 0) {
		angle += 2 * Math.PI;
	}
	return angle;
}

function distanceBetweenPoints(x1, y1, x2, y2) {
	return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
}

function setup() {
	createCanvas(WINDOW_WIDTH, WINDOW_HEIGHT);
}

function update() {
	player.update();
	castAllRays(); // move to draw to debug
}

function draw() {
	clear("#212121");
	update();

	renderProjectedWalls();

	grid.render();
	for (ray of rays) ray.render();
	player.render();
}
