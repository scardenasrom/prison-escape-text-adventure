using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    private Text text;
    private enum State { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom };
    private State currentState;

	void Start () {
        text = GetComponent<Text>();
        currentState = State.cell;
	}
	
	void Update () {
        switch(currentState) {
            case State.cell:
                StateCell();
                break;
            case State.mirror:
                StateMirror();
                break;
            case State.sheets_0:
                StateSheets0();
                break;
            case State.lock_0:
                StateLock0();
                break;
            case State.cell_mirror:
                StateCellMirror();
                break;
            case State.sheets_1:
                StateSheets1();
                break;
            case State.lock_1:
                StateLock1();
                break;
            case State.freedom:
                StateFreedom();
                break;
        }
	}

    void StateCell() {
        text.text = "You are in a prison cell, and you want to escape. There are some dirty sheets on the bed, a mirror on the wall, and the door is locked from the outside.\n\n" +
                "[S] - View the sheets\n" +
                "[M] - View the mirror\n" +
                "[L] - View lock";
        if (Input.GetKeyDown(KeyCode.S))        { currentState = State.sheets_0; } 
        else if (Input.GetKeyDown(KeyCode.M))   { currentState = State.mirror; } 
        else if (Input.GetKeyDown(KeyCode.L))   { currentState = State.lock_0; }
    }

    void StateSheets0() {
        text.text = "You can't believe you sleep in these things. Surely it's time somebody changed them. The pleasures of prison life I guess!\n\n" +
                "[R] - Keep roaming in your cell";
        if (Input.GetKeyDown(KeyCode.R))        { currentState = State.cell; }
    }

    void StateLock0() {
        text.text = "This is one of those button locks. You have no idea what the combination is. You wish you could somehow see where the dirty fingerprints were " +
                    ", maybe that would help.\n\n" +
                    "[R] - Keep roaming in your cell";
        if (Input.GetKeyDown(KeyCode.R))        { currentState = State.cell; }
    }

    void StateMirror() {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                "[T] - Take the mirror\n" +
                "[R] - Keep roaming in your cell";
        if (Input.GetKeyDown(KeyCode.T))        { currentState = State.cell_mirror; } 
        else if (Input.GetKeyDown(KeyCode.R))   { currentState = State.cell; }
    }

    void StateCellMirror() {
        text.text = "You are still in your cell, and still want to escape. There are some dirty sheets on the bed, a mark where the mirror was, and that pesky door" +
            " is still there, and firmly locked.\n\n" +
                "[S] - View the sheets\n" +
                "[L] - View lock";
        if (Input.GetKeyDown(KeyCode.S))        { currentState = State.sheets_1; } 
        else if (Input.GetKeyDown(KeyCode.L))   { currentState = State.lock_1; }
    }

    void StateSheets1() {
        text.text = "Holding a mirror in your hand doesn't make the sheets look any better.\n\n" +
                "[R] - Keep roaming in your cell";
        if (Input.GetKeyDown(KeyCode.R)) { currentState = State.cell_mirror; }
    }

    void StateLock1() {
        text.text = "Your carefully put the mirror through the bars, and turn it around so you can see the lock." +
                " You can just make out fingerprints around the buttons. You press the dirty buttons, and hear a click.\n\n" +
                "[O] - Open the door\n" +
                "[R] - Keep roaming in your cell";
        if (Input.GetKeyDown(KeyCode.O)) { currentState = State.freedom; } else if (Input.GetKeyDown(KeyCode.R)) { currentState = State.cell_mirror; }
    }

    void StateFreedom() {
        text.text = "You are free!\n\n" +
                "[P] - Play again";
        if (Input.GetKeyDown(KeyCode.P)) { currentState = State.cell; }
    }

}
