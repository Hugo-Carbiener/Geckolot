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

    public Dialogue(int id_, string sentence_, int character_, int emotion_)
    {
        this.id = id_;
        this.sentence = sentence_;
        this.character = character_;
        this.emotion = emotion_;
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
    private int index;
    private int charact;
    private string sentence;
    public bool isWriting;
    [SerializeField] List<Dialogue> dial = new List<Dialogue>();
    public List<Sprite> portrait_Axo;
    public List<Sprite> portrait_Geck;


    // Start is called before the first frame update
    void Awake()
    {
        AnalyseTextAsset(ta);
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
        if (currentDialogueId+1 > dial.Count)
        {
            dialBox.SetActive(false);
            return;
        }

        isWriting = true;
        index = 0;
        

        sentence = GetSentence(currentDialogueId).sentence;
        charact = GetSentence(currentDialogueId).character;
        StartCoroutine(WriteText(sentence, sentence.Length, charact));
        currentDialogueId++;

        ActivateCharacter(charact);
    }

    public IEnumerator WriteText(string sentence, int charNb, int charact)
    {

        while (index < charNb && isWriting)
        {
            yield return new WaitForSeconds(speed);
            txt.text = sentence.Substring(0, index);
            index++;
        }

        txt.text = sentence;
        isWriting = false;
        yield break;
    }

    public void ActivateCharacter(int id)
    {
        foreach(var x in ptr)
        {
            x.gameObject.SetActive(false);
        }

        ptr[id].gameObject.SetActive(true);
        // ajouter l'émotion
    }

    public Dialogue GetSentence(int id)
    {
        return dial.Find(dials => dials.id == id);
    }

    public void AnalyseTextAsset(TextAsset ta)
    {
        string ss = "";
        int cc = 0;
        int ee = 0;
        int id = 0;

        var l = ta.text.Split('\n');

        for (int i = 0; i < l.Length; i++)
        {
            id = i;
            var c = l[i].Split(char.Parse("|"));

            ss = c[0];

            int ccc;
            int.TryParse(c[1], out ccc);
            cc = ccc;

            int eee;
            int.TryParse(c[2], out eee);
            ee = eee;

            dial.Add(new Dialogue(id, ss, cc, ee));
        } 
    }

}
