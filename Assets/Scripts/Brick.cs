using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable; 
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
		}
		Debug.Log(breakableCount);
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionExit2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position, volume:1.0F);
		if (isBreakable) {
			handleHits();
		}
	}
	
	void handleHits(){
		int maxHits;
		maxHits = hitSprites.Length + 1;
		timesHit++;
		if (timesHit >= maxHits){
			breakableCount--;
			Debug.Log(breakableCount);
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject; 
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
		
	void LoadSprites(){
		int spriteIndex = timesHit -1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
}
