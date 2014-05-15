using UnityEngine;
using System.Collections;

public class overworld_music : MonoBehaviour {

    Stats stat;

    public AudioSource overworld;
    public AudioSource game_over;
    public AudioSource battle;
    public AudioSource front;
    public AudioSource temple;

    int count = 1;
    bool g_o = true;
    public bool b_t = true;

    void Awake () {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        stat = (Stats)FindObjectOfType(typeof(Stats));

        overworld = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipa;
        myAudioClipa = (AudioClip)Resources.Load("Music/At Launch");
        overworld.clip = myAudioClipa;
        overworld.volume = 0.5f;
        overworld.Play();
        overworld.loop = true;

        game_over = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipb;
        myAudioClipb = (AudioClip)Resources.Load("Music/death_music");
        game_over.clip = myAudioClipb;
        game_over.volume = 1;
        game_over.loop = true;

        battle = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipc;
        myAudioClipc = (AudioClip)Resources.Load("Music/Blam");
        battle.clip = myAudioClipc;
        battle.volume = 0.25f;
        battle.loop = true;

        front = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipd;
        myAudioClipd = (AudioClip)Resources.Load("Music/Discovery Hit");
        front.clip = myAudioClipd;
        front.volume = 1f;
        front.loop = false;

        temple = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipe;
        myAudioClipe = (AudioClip)Resources.Load("Music/Beneathere");
        temple.clip = myAudioClipe;
        temple.volume = 1f;
        temple.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
        count++;
        /*if (count == 1) {
            if (stat.currentLevel == 17 || stat.currentLevel == 18) {
                front.Stop();
                temple.Play();
            } else if (stat.currentLevel == 16) {
                overworld.Stop();
                front.Play();
            } else {
                front.Stop();
                overworld.Play();
            }
        }*/

        if (GameObject.Find("Battle")) {
            overworld.Pause();
            //temple.Pause();
            if (b_t) {
                battle.Play();
            }
            b_t = false;
            count = 0;
        } else if (!GameObject.Find("Game Over") && count == 1) {
            battle.Stop();
            /*if (stat.currentLevel == 17 || stat.currentLevel == 18) {
                front.Stop();
                temple.Play();
            } else if (stat.currentLevel == 16) {
                overworld.Stop();
                front.Play();
            } else {
                front.Stop();
                overworld.Play();
            }*/
            overworld.Play();
            b_t = true;
        }

        if (GameObject.Find("Pause") || GameObject.Find("Inventory")) {
            overworld.volume = 0.4f;
        } else {
            overworld.volume = 1;
        }

        if (GameObject.Find("Game Over")) {
            overworld.Stop();
            temple.Stop();
			battle.Stop();
            if (g_o) {
                game_over.Play();
            }
            g_o = false;
            count = 0;
        } else if (!GameObject.Find("Battle") && count == 1) {
            game_over.Stop();
        }
	}
}
