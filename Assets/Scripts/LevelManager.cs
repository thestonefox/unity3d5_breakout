using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public int bricks = 10;
	public int lives = 3;
	public int score = 0;
	public float resetDelay = 1f;

	public GameObject brick;
	public GameObject paddle;
	public GameObject playerDeathParticles;
	public GameObject gameOver;
	public GameObject youWin;
	public Text livesText;
	public Text scoreText;

	public static LevelManager instance = null;

	private GameObject playerPaddle;
	private GameObject[,] brickLayout;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		Setup();
	}

	public void Setup() {
		Time.timeScale = 1f;
		CreatePlayer();
		CreateBricks();
		SetLivesText();
		SetScoreText();
	}

	public bool IsGameOver() {
		if (bricks < 1) {
			LevelComplete();
			return true;
		}
		if (lives < 1) {
			GameOver();
			return true;
		}
		return false;
	}

	public void LoseLife() {
		lives--;
		SetLivesText();
		Instantiate (playerDeathParticles, playerPaddle.transform.position, Quaternion.identity);
		Destroy(playerPaddle);
		if (! IsGameOver()) {
			Invoke ("CreatePlayer", resetDelay);
		}
	}

	public void HitBrick() {
		score++;
		bricks--;
		SetScoreText();
		IsGameOver();
	}

	private void SetLivesText() {
		livesText.text = "Lives: " + lives;
	}

	private void SetScoreText() {
		scoreText.text = "Score: " + score;
	}
		
	private void CreatePlayer() {
		playerPaddle = Instantiate (paddle, new Vector3(0f, -5f, 0f), Quaternion.identity) as GameObject;
	}

	private void CreateBricks() {
		int brickHorizontalLimit = 5;
		int brickVerticalLimit = bricks / brickHorizontalLimit;
		Vector2 padding = new Vector2(1f, 0.5f);
		Vector2 dimensions = new Vector2 (2f, 1f);
		Vector2 offset = new Vector2 (6f, 0f);

		brickLayout = new GameObject[brickHorizontalLimit, brickVerticalLimit];
		for (int y = 0; y < brickVerticalLimit; y++) {
			for (int x = 0; x < brickHorizontalLimit; x++) {
				float xPos = (0 + ( x * (dimensions.x + padding.x))) - offset.x;
				float yPos = (0 + ( y * (dimensions.y + padding.y))) - offset.y;
				brickLayout[x,y] = Instantiate(brick, new Vector3(xPos, yPos, 0), Quaternion.identity) as GameObject;
			}
		}

	}

	private void LevelComplete() {
		youWin.SetActive (true);
		Reset();
	}

	private void GameOver() {
		gameOver.SetActive (true);
		Reset();
	}

	private void Reset() {
		Time.timeScale = 0.3f;
		Invoke ("Reload", resetDelay);
	}

	private void Reload() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}