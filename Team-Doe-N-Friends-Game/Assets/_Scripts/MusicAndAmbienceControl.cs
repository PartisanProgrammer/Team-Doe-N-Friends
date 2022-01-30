
using FMOD.Studio;
using UnityEngine;

public class MusicAndAmbienceControl : MonoBehaviour{
    [SerializeField] FMODUnity.EventReference Ambience;
    [SerializeField] FMODUnity.EventReference Music;

    Rigidbody2D playerRB;
    EventInstance ambienceInstance;
    EventInstance musicInstance;
    PauseMenu pauseMenu;

    bool created;

    public static MusicAndAmbienceControl instance = null;

    void Awake(){
        ambienceInstance = FMODUnity.RuntimeManager.CreateInstance(Ambience);
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(Music);
        if (instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start(){
        musicInstance.start();
        ambienceInstance.start();
        playerRB = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    void Update(){
        if (playerRB == null){
            playerRB = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
        }
        if (pauseMenu == null){
            pauseMenu = FindObjectOfType<PauseMenu>();
        }
        if (playerRB.gravityScale == -1){
            ambienceInstance.setParameterByName("LightSide", 0);
            musicInstance.setParameterByName("LightSide", 0);
        }

        if (playerRB.gravityScale == 1){
            ambienceInstance.setParameterByName("LightSide", 1);
            musicInstance.setParameterByName("LightSide", 1);
        }

        if (pauseMenu.gameIsPaused){
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        }

        if (!pauseMenu.gameIsPaused){
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 0);
        }
    }
}
