using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Dialogue
{
    public int id;
    public string sentence;
    public int character;
    public int emotion;
    public bool invisibleChar;

    public Dialogue(int id_, string sentence_, int character_, int emotion_, bool invisibleChar_)
    {
        this.id = id_;
        this.sentence = sentence_;
        this.character = character_;
        this.emotion = emotion_;
        this.invisibleChar = invisibleChar_;
    }
}

public class TextWriter : MonoBehaviour
{

    public Text txt;
    public List<Image> ptr;
    public GameObject dialBox;
    public TextAsset ta;
    public int currentDialogueId;
    public float speed;
    private GameManager gm;
    private int index;
    private int charact;
    private int emotion;
    private string sentence;
    public bool isWriting;
    [SerializeField] List<Dialogue> dial = new List<Dialogue>();
    public List<Sprite> portrait_Axo;
    public List<Sprite> portrait_Geck;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (isWriting)
            {
                isWriting = false;
            }
            else
            {
                AddText();
            }
        }
    }

    public void AddText()
    {
        if (currentDialogueId >= dial.Count)
        {
            dialBox.SetActive(false);
            gm.setPlayersControllable(true);
            return;
        }

        isWriting = true;
        index = 0;
        

        sentence = GetSentence(currentDialogueId).sentence;
        charact = GetSentence(currentDialogueId).character;
        emotion = GetSentence(currentDialogueId).emotion;
        StartCoroutine(WriteText(sentence, sentence.Length, charact, true));
        currentDialogueId++;

        ActivateCharacter(charact, emotion);
    }

    public IEnumerator WriteText(string sentence, int charNb, int charact, bool invisibleChar)
    {

        while (index < charNb && isWriting)
        {
            yield return new WaitForSeconds(speed);
            string text = sentence.Substring(0, index);
            if (invisibleChar)
            {
                text += "<color=#00000000>" + sentence.Substring(index) + "</color>";
            }
            txt.text = text;
            index++;
        }
      
        isWriting = false;
        invisibleChar = false;
        txt.text = sentence.Substring(0, charNb);
        yield break;
    }

    public void ActivateCharacter(int id, int emo)
    {
        foreach(var x in ptr)
        {
            x.gameObject.SetActive(false);
        }

        ptr[id].gameObject.SetActive(true);

        if (id == 1)
        {
            ptr[id].sprite = portrait_Axo[emo];
        }
        else
        {
            ptr[id].sprite = portrait_Geck[emo];
        }
    }

    public void ActivateDialogue()
    {
        if (gm.currentTableauManager.text_for_the_tab == null)
        {
            gm.setPlayersControllable(true);
            return;
        }
        ta = gm.currentTableauManager.text_for_the_tab;
        AnalyseTextAsset(ta);
        if (dial.Count != 0)
        {
            dialBox.SetActive(true);
            currentDialogueId = 0;
            AddText();
        }
        else
        {
            //Si on n'a pas de dialogue, on rend le contrôle aux joueurs
            gm.setPlayersControllable(true);
        }
    }

    public Dialogue GetSentence(int id)
    {
        return dial.Find(dials => dials.id == id);
    }

    public void AnalyseTextAsset(TextAsset ta)
    {
        currentDialogueId = 0;
        dial = new List<Dialogue>();
        string ss = "";
        int cc = 0;
        int ee = 0;
        int id = 0;

        var l = ta.text.Split('\n');
        for (int i = 0; i < l.Length; i++)
        {
            id = i;
            var c = l[i].Split(char.Parse("|"));
            if (c.Length >= 2)
            {
                ss = c[0];

                int ccc;
                int.TryParse(c[1], out ccc);
                cc = ccc;

                int eee;
                int.TryParse(c[2], out eee);
                ee = eee;

                dial.Add(new Dialogue(id, ss, cc, ee, true));
            }
            
        } 
    }

}
