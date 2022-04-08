using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Engine : MonoBehaviour
{
    [SerializeField] GameObject DT1, DT2, DT3;
    [SerializeField] GameObject SW1, SW2, SW3;
    [SerializeField] GameObject SH1, SH2, SH3;
    [SerializeField] GameObject Dia1, Dia2, Dia3;
    [SerializeField] GameObject CT1, CT2, CT3;
    [SerializeField] GameObject Cho1, Cho2, Cho3;
    [SerializeField] GameObject UserBox;
    [SerializeField] GameObject HintButton;
    [SerializeField] GameObject NextButton;
    [SerializeField] GameObject TitleLevel;
    [SerializeField] GameObject BigBox;
    [SerializeField] GameObject InputField, Button;

    Text t1, t2, t3, tl, c1, c2, c3, u;
    InputField inputField;

    int qcount, arand, qrand, correctNum, arrayCount;
    public int item;
    string ans;
    int[] qused = new int[5] {9, 9, 9, 9, 9};
    int[] qused3 = new int[10] {99, 99, 99, 99, 99, 99, 99, 99, 99, 99 };
    public int button, wrongCount, hintCount, level, introQ;
    public bool clickCheck, correct, gameStart, inputans;

    string[,,] qna = {{{ "Which one of these are the correct term for 'oops'?", "Nyek", "Ay", "Shuta" },
                       { "If you want to call your special someone, you can say what?", "Jowa", "Shota", "Juswa" },
                       { "You say this if you're kidding around? What is the other term for 'Joking'?", "Charot", "Petmalu", "Charing" },
                       { "You say this when you are hurt but not seriously/literally?", "Awit", "Awts", "Aray" },
                       { "This is another common term for the Filipinos if they want to say 'just because'?", "Basta", "Mema", "Balakajan" }}, 
        
                       {{ "What is a word for endearment towards your mom or a female friend?", "Momshie", "Momshae", "Shawty"},
                       { "Someone is making their presence known or attracting attention. What is the correct term?", "Awra", "Ganern", "Havey" },
                       { "Your friends asks you out on a drinking session, pick out the correct slang for getting drunk or wasted.", "Walwal", "Balbal", "Momol" },
                       { "Your sisterís pet bird had passed away. What is the correct slang to proclaim their passing?", "Tigok", "Dedo", "Laglag" },
                       { "Someone very cool is walking pass you and you want to call out your admiration for them. What is another term for 'Cool'?", "Jeproks", "Churva", "Carps" } } };

    string[,] summa;

    string[] trivia = {"Nyek is commonly used in situations where you'd feel pleasantly surprised or shocked ÅEusually upon hearing corny jokes or cheesy one-liners.",
                       "This word literally translates to boyfriend or girlfriend. Also, if you want to say that someone is a girlfriend/boyfriend material, you can say that they are 'jowable'.",
                       "You say charot if you're kidding around. This is usually said after the statement which is meant to be a joke.",
                       "It's a combination of 2 words, 'awww' and 'sakit' , thus the word 'Awit'. Means aww sakit. Used when you are describing an unfortunate situation. If this word is not used as a slang it would mean singing.",
                       "This word is commonly used if you do not want to explain something, you can use this word to end a statement.",
                       "This is a cute way of calling your biological mother or any female who is significantly older than you.",
                       "It is a creative version of the English word \"aura\" It doesn't literally mean \"atmosphere\" like what the English word means. It is popularized in gay culture.",
                       "The meaning of this word originated during drinking because of the tongue sticking out of your mouth (walwal ang dila) after you've drank to the point of unconsciousness. ",
                       "The standard word for dead in tagalog is patay but this word is more popular nowadays and has become a common slang word.",
                       "It typically refers to someone that has a lot of street smarts or comes from the projects."};


    [Header("Carry Over")]
    public int stars;
    public int lvl;
    public gameplayCarry gc;

    // Start is called before the first frame update
    void Start()
    {
        t1 = DT1.GetComponent<Text>();
        t2 = DT2.GetComponent<Text>();
        t3 = DT3.GetComponent<Text>();
        
        tl = TitleLevel.GetComponent<Text>();

        c1 = CT1.GetComponent<Text>();
        c2 = CT2.GetComponent<Text>();
        c3 = CT3.GetComponent<Text>();

        u = UserBox.GetComponent<Text>();
        inputField = InputField.GetComponent<InputField>();
        InputField.SetActive(false);
        Button.SetActive(false);

        wrongCount = 0;
        item = 0;
        hintCount = 2;
        level = 1;
        gameStart = false;
        inputans = false;
        introQ = 0;

        gc = GameObject.Find("gameplayCarry").GetComponent<gameplayCarry>();
        level = gc.lvlGame;
        if (level <= 1)
        {
            gameStart = false;
        }
        else
        {
            gameStart = true;
        }

        NextButton.SetActive(false);

        SW1.SetActive(false);
        SW2.SetActive(false);
        SW3.SetActive(false);
        SH1.SetActive(false);
        SH2.SetActive(false);
        SH3.SetActive(false);
        BigBox.SetActive(false);

        Combine();
        TenQuestions();
        GenerateNum();
        RandomQuestion();
        Question();
    }

    public void Introduction()
    {
        InputField.SetActive(false);
        Button.SetActive(false);
        switch (introQ)
        {
            case 0:
                Dia1.SetActive(true);
                Dia2.SetActive(true);
                Dia3.SetActive(false);
                t1.text = "Hi! My name is orangguslang!";
                t2.text = "Click the answer box to reply.";

                Cho1.SetActive(false);
                c2.text = "Hello Orangguslang!";
                Cho3.SetActive(false);
                break;
            case 1:
                t1.text = "You can click the answer box to reply.";
                t2.text = "Do you know what Slang is?";
                Dia3.SetActive(false);

                Cho1.SetActive(false);
                c2.text = "Please explain it to me.";
                Cho3.SetActive(false);
                break;
            case 2:
                t1.text = "Slang words are unconventional words or phrases that express either something";
                t2.text = "new or something old in a new way.";
                Dia3.SetActive(true);
                t3.text = "Got it?";
                
                Cho1.SetActive(false);
                c2.text = "Yes!";
                Cho3.SetActive(false);
                break;
            case 3:
                BigBox.SetActive(true);
                t1.text = "Now there's also Slang words that are in the language of Filipino. These are called";
                t2.text = "Filipino Slangs. which are modified words that came from languages such as Filipino,";
                Dia3.SetActive(true);
                t3.text = "English or Spanish that is used in an informal manner. Sounds cool ain't it?";


                Cho1.SetActive(false);
                c2.text = "Interesting!";
                Cho3.SetActive(false);
                
                break;
            case 4:
                BigBox.SetActive(true);
                t1.text = "Now, are you ready  to learn some slang words?I will either say a phrase and you complete";
                t2.text = " it with what you think is the best word that fits the sentence or say a word then guess";
                Dia3.SetActive(true);
                t3.text = "what its direct translation is.";


                Cho1.SetActive(false);
                c2.text = "Let's get started!";
                Cho3.SetActive(false);
                break;
            case 5:
                BigBox.SetActive(false);
                t1.text = "If you don't know what to reply, you can always click the hint button at the bottom right";
                t2.text = " of the screen. I'll be here to guide you.";
                Dia3.SetActive(false);


                Cho1.SetActive(false);
                c2.text = "Noted";
                Cho3.SetActive(false);
                break;
        }
    }

    public int GenerateNum()
    {
        arand = Random.Range(1,4);
        return arand;
    }

    public void Combine()
    {
        summa = new string[10, 4];
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                //Debug.Log(qna[0, x, y]);
                summa[x, y] = qna[0, x, y];
            }
        }
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                //Debug.Log(qna[1, x, y]);
                summa[x + 5, y] = qna[1, x, y];
            }
        }
    }

    public void RandomQuestion()
    {
        arrayCount = 0;
        while (qused[4] == 9)
        {
            qrand = Random.Range(1, 6);
            Debug.Log(qrand);
            if (!qused.Contains(qrand))
            {

                qused[arrayCount] = qrand;
                arrayCount++;
                Debug.Log("ARRAY " + qused[0] + qused[1] + qused[2] + qused[3] + qused[4]);
            }
        }
    }
    
    public void TenQuestions()
    {
        arrayCount = 0;
        while (qused3[9] == 99)
        {
            qrand = Random.Range(1, 11);
            Debug.Log(qrand);
            if (!qused3.Contains(qrand))
            {
                qused3[arrayCount] = qrand;
                arrayCount++;
                Debug.Log("ARRAY " + qused3[0] + " " + qused3[1] + " " +  qused3[2] + " " + qused3[3] + " " + qused3[4] + " " + qused3[5] + " " + qused3[6] + " " + qused3[7] + " " + qused3[8] + " " + qused3[9]);
            }
        }
    }

    public void Question()
    {
        if (level == 3)
        {
            qcount = qused3[item];
        }
        else
        {
            qcount = qused[item];
        }
        NextButton.SetActive(false);
        Dia2.SetActive(false);
        Dia3.SetActive(false);
        correctNum = GenerateNum();
        if (level == 3)
        {
            Debug.Log(qcount + " || ");
            if (qcount == 1)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 2)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 3)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 4)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 5)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 6)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 7)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 8)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 9)
            {
                t1.text = summa[qcount - 1, 0];
            }
            if (qcount == 10)
            {
                t1.text = summa[qcount - 1, 0];
            }
        }
        else 
        {
            if (qcount == 1)
            {
                t1.text = qna[level - 1, qcount - 1, 0];
            }
            if (qcount == 2)
            {
                t1.text = qna[level - 1, qcount - 1, 0];
            }
            if (qcount == 3)
            {
                t1.text = qna[level - 1, qcount - 1, 0];
            }
            if (qcount == 4)
            {
                t1.text = qna[level - 1, qcount - 1, 0];
            }
            if (qcount == 5)
            {
                t1.text = qna[level - 1, qcount - 1, 0];
            }
        }

        int chance = Random.Range(0,2);
        Debug.Log(chance + " !!!!!!!!!!!!!!!!!!!!!!!!!");
        if (chance == 0)
        {
            inputans = false;
            Cho1.SetActive(true);
            Cho2.SetActive(true);
            Cho3.SetActive(true);
            if (level == 3)
            {
                switch (correctNum)
                {
                    case 1:
                        c1.text = summa[qcount - 1, 1];
                        c2.text = summa[qcount - 1, 2];
                        c3.text = summa[qcount - 1, 3];
                        ans = c1.text;
                        break;
                    case 2:
                        c1.text = summa[qcount - 1, 2];
                        c2.text = summa[qcount - 1, 1];
                        c3.text = summa[qcount - 1, 3];
                        ans = c2.text;
                        break;
                    case 3:
                        c1.text = summa[qcount - 1, 2];
                        c2.text = summa[qcount - 1, 3];
                        c3.text = summa[qcount - 1, 1];
                        ans = c3.text;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (correctNum)
                {
                    case 1:
                        c1.text = qna[level - 1, qcount - 1, 1];
                        c2.text = qna[level - 1, qcount - 1, 2];
                        c3.text = qna[level - 1, qcount - 1, 3];
                        ans = c1.text;
                        break;
                    case 2:
                        c1.text = qna[level - 1, qcount - 1, 2];
                        c2.text = qna[level - 1, qcount - 1, 1];
                        c3.text = qna[level - 1, qcount - 1, 3];
                        ans = c2.text;
                        break;
                    case 3:
                        c1.text = qna[level - 1, qcount - 1, 2];
                        c2.text = qna[level - 1, qcount - 1, 3];
                        c3.text = qna[level - 1, qcount - 1, 1];
                        ans = c3.text;
                        break;
                    default:
                        break;
                }
            }
        }
        else if(chance > 0)
        {
            InputField.SetActive(true);
            Button.SetActive(true);
            inputans = true;
        }
    }

    public void Correct()
    {
        NextButton.SetActive(true);
        BigBox.SetActive(true);
        Dia2.SetActive(false);
        Dia3.SetActive(true);
        switch (ans)
        {
            case "Nyek":
                t1.text = trivia[0];
                break;
            case "Jowa":
                t1.text = trivia[1];
                break;
            case "Charot":
                t1.text = trivia[2];
                break;
            case "Awit":
                t1.text = trivia[3];
                break;
            case "Basta":
                t1.text = trivia[4];
                break;
            case "Momshie":
                t1.text = trivia[5];
                break;
            case "Awra":
                t1.text = trivia[6];
                break;
            case "Walwal":
                t1.text = trivia[7];
                break;
            case "Tigok":
                t1.text = trivia[8];
                break;
            case "Jeproks":
                t1.text = trivia[9];
                break;
        }
        t3.text = "Let's try another.";
        correct = true;
    }

    public void Wrong()
    {
        NextButton.SetActive(true);
        Dia2.SetActive(true);
        Dia3.SetActive(true);
        t2.text = "That's wrong!";
        t3.text = "Let's try again.";
        correct = false;
    }

    private void Update()
    {
        Debug.Log("QCOUNT: " + qcount);
        Debug.Log("ITEM: " + item);
        if (gameStart)
        {
            tl.text = "Level 0" + level;
            if (inputans)
            {
                Cho1.SetActive(false);
                Cho2.SetActive(false);
                Cho3.SetActive(false);
                HintButton.SetActive(false);
            }
            if (clickCheck && !inputans)
            {
                HideAnswers();
                if (qcount == 1 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 1 && button != correctNum)
                {
                    Wrong();
                }
                if (qcount == 2 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 2 && button != correctNum)
                {
                    Wrong();
                }
                if (qcount == 3 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 3 && button != correctNum)
                {
                    Wrong();
                }
                if (qcount == 4 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 4 && button != correctNum)
                {
                    Wrong();
                }
                if (qcount == 5 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 5 && button != correctNum)
                {
                    Wrong();
                }
                if (qcount == 6 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 6 && button != correctNum)
                {
                    Wrong();
                }

                if (qcount == 7 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 7 && button != correctNum)
                {
                    Wrong();
                }

                if (qcount == 8 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 8 && button != correctNum)
                {
                    Wrong();
                }

                if (qcount == 9 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 9 && button != correctNum)
                {
                    Wrong();
                }

                if (qcount == 10 && button == correctNum)
                {
                    Correct();
                }
                else if (qcount == 10 && button != correctNum)
                {
                    Wrong();
                }
            }
            else if(clickCheck && inputans)
            {
                Debug.Log("Input");
                clickCheck = false;
                InputField.SetActive(false);
                Button.SetActive(false);
                if (inputField.text.ToLower() == qna[level - 1, qcount - 1, 1].ToLower())
                {
                    ans = qna[level - 1, qcount - 1, 1];
                    Debug.Log("Correct");
                    Correct();
                }
                else
                {
                    Debug.Log("Wrong");
                    Wrong();
                }
            }
        }
        else
        {
            Introduction();
        }
    }

    public void nextQuestion()
    {
        SW1.SetActive(false);
        SW2.SetActive(false);
        SW3.SetActive(false);
        SH1.SetActive(false);
        SH2.SetActive(false);
        SH3.SetActive(false);
        BigBox.SetActive(false);

        if(item != 4 && level != 3)
        {
            item++;
            Debug.Log(level + "<Level");
            Question();
            Debug.Log("Question for Level " + level);
        }
        else if (item != 9 && level == 3)
        {
            item++;
            Debug.Log(level + "<Level");    
            Question();
            Debug.Log("Question for Level 3");
        }
        else
        {
            Complete();
        }
    }

    public void Complete()
    {
        item = -1;
        Dia2.SetActive(false);
        Dia3.SetActive(false);
        if (wrongCount >= 10)
        {
            SH1.SetActive(true);
            SH2.SetActive(true);
            SH3.SetActive(true);
            t1.text = "Dishonor to you and your Family. Charot!";
            stars = 0;
            completeSave();
            level++;
        }
        else if (wrongCount >= 6)
        {
            SW1.SetActive(true);
            SH2.SetActive(true);
            SH3.SetActive(true);
            t1.text = "Congrats! You got 1 star!";
            stars = 1;
            lvl = level;
            completeSave();
            level++;
        }
        else if (wrongCount >= 1)
        {
            SW1.SetActive(true);
            SW2.SetActive(true);
            SH3.SetActive(true);
            t1.text = "Congrats! You got 2 stars!";
            stars = 2;
            lvl = level;
            completeSave();
            level++;
        }
        else if (wrongCount == 0)
        {
            SW1.SetActive(true);
            SW2.SetActive(true);
            SW3.SetActive(true);
            t1.text = "Congrats! You got 3 stars!";
            stars = 3;
            lvl = level;
            completeSave();
            level++;
        }
        wrongCount = 0;
        Debug.Log(level + "<Level");

        if (level == 3)
        {
            Combine();
            TenQuestions();
        }

        gc.lvl = level;
        gc.SavePlayer();
        NextButton.SetActive(false);
    }

    public void completeSave()
    {
        if (level == 1)
        {
            if (gc.star[0] < stars)
            {
                gc.star[0] = stars;
            }
            gc.level[0] = lvl;
        }
        if (level == 2)
        {
            if (gc.star[1] < stars)
            {
                gc.star[1] = stars;
            }
            gc.level[1] = lvl;
        }
        if (level == 3)
        {
            if (gc.star[2] < stars)
            {
                gc.star[2] = stars;
            }
            gc.level[2] = lvl;
        }
    }

    public void Hint()
    {
        if (hintCount != 0)
        {
            if (hintCount == 1)
            {
                HintButton.SetActive(false);
            }
            switch (correctNum)
            {
                case 1:
                    Cho2.SetActive(false);
                    break;
                case 2:
                    Cho3.SetActive(false);
                    break;
                case 3:
                    Cho1.SetActive(false);
                    break;
                default:
                    break;
            }
        }
       
    }

    public void HideAnswers()
    {
        Cho1.SetActive(false);
        Cho2.SetActive(false);
        Cho3.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene("menu");
    }
}
