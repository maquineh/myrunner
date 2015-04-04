using System.Collections;

public static class GameManagersEvent{

	public delegate void GameEvent();

	public static event GameEvent StartGame, GameOver;

	public static void runGameStart(){
		if(StartGame != null){
			StartGame();
		}
	}
	
	public static void runGameOver(){
		if(GameOver != null){
			GameOver();
		}
	}
}
