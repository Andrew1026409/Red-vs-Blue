using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArticleCreationScript : MonoBehaviour
{
    [Header("===== Values > Segment 1 =====")]
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> weeklyArticle1Drafts = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> weeklyArticle2Drafts = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> weeklyArticle3Drafts = new List<string>();
    private int week1Article;
    private int week2Article;
    private int week3Article;
    private int week4Article;
    private int currentWeek = 1;

    [Header("===== Values > Segment 2 =====")]
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> submittingArticle1Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<Sprite> submittingArticle1Image = new List<Sprite>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> submittingArticle2Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<Sprite> submittingArticle2Image = new List<Sprite>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> submittingArticle3Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<Sprite> submittingArticle3Image = new List<Sprite>();

    [Header("===== Values > Segment 3 =====")]
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article1Comment1Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article1Comment2Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article1Comment3Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article2Comment1Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article2Comment2Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article2Comment3Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article3Comment1Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article3Comment2Body = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article3Comment3Body = new List<string>();
    [SerializeField] private float segment3Time;
    [SerializeField] private float segment3CommentsDelay;

    [Header("===== Values > Segment 4 =====")]
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article1EmailSubject = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article2EmailSubject = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article3EmailSubject = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article1EmailBody = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article2EmailBody = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> article3EmailBody = new List<string>();
    [SerializeField] private string levelToLoadAtEnd;

    [Header("===== Object References > Segment 1 =====")]
    [SerializeField] private TextMeshProUGUI weekCounter;
    [SerializeField] private GameObject article1;
    [SerializeField] private GameObject article2;
    [SerializeField] private GameObject article3;
    
    [Header("===== Object References > Segment 2 =====")]
    [SerializeField] private TextMeshProUGUI segment2HeaderText;
    [SerializeField] private TextMeshProUGUI segment2BodyText;
    [SerializeField] private Image segment2Image;

    [Header("===== Object References > Segment 3 =====")]
    [SerializeField] private GameObject segment3;
    [SerializeField] private TextMeshProUGUI segment3HeaderText;
    [SerializeField] private TextMeshProUGUI segment3BodyText;
    [SerializeField] private Image segment3Image;
    [SerializeField] private GameObject comment1;
    [SerializeField] private GameObject comment2;
    [SerializeField] private GameObject comment3;
    [SerializeField] private TextMeshProUGUI comment1BodyText;
    [SerializeField] private TextMeshProUGUI comment2BodyText;
    [SerializeField] private TextMeshProUGUI comment3BodyText;

    [Header("===== Object References > Segment 4 =====")]
    [SerializeField] private GameObject segment4;
    [SerializeField] private TextMeshProUGUI emailSubjectLineText;
    [SerializeField] private TextMeshProUGUI emailBodyText;

    private void OnEnable()
    {
        UpdateArticles(0);
    }

    public void UpdateArticles(int segment)
    {
        switch (segment)
        {
            case 0: // FOR UPDATING THE DRAFT ARTICLES EACH WEEK
                switch (currentWeek)
                {
                    case 1:
                        article1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle1Drafts[0];
                        article2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle2Drafts[0];
                        article3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle3Drafts[0];
                        break;
                    case 2:
                        article1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle1Drafts[1];
                        article2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle2Drafts[1];
                        article3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle3Drafts[1];
                        break;
                    case 3:
                        article1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle1Drafts[2];
                        article2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle2Drafts[2];
                        article3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle3Drafts[2];
                        break;
                    case 4:
                        article1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle1Drafts[3];
                        article2.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle2Drafts[3];
                        article3.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weeklyArticle3Drafts[3];
                        break;
                }
                break;
            case 1: // FOR UPDATING THE SEGMENT 2 SUBMITTING ARTICLE
                switch (currentWeek)
                {
                    case 1:
                        switch (week1Article)
                        {
                            case 1:
                                segment2HeaderText.text = weeklyArticle1Drafts[0];
                                segment2BodyText.text = submittingArticle1Body[0];
                                segment2Image.sprite = submittingArticle1Image[0];
                                break;
                            case 2:
                                segment2HeaderText.text = weeklyArticle2Drafts[0];
                                segment2BodyText.text = submittingArticle2Body[0];
                                segment2Image.sprite = submittingArticle2Image[0];
                                break;
                            case 3:
                                segment2HeaderText.text = weeklyArticle3Drafts[0];
                                segment2BodyText.text = submittingArticle3Body[0];
                                segment2Image.sprite = submittingArticle3Image[0];
                                break;
                        }
                        break;
                    case 2:
                        switch (week2Article)
                        {
                            case 1:
                                segment2HeaderText.text = weeklyArticle1Drafts[1];
                                segment2BodyText.text = submittingArticle1Body[1];
                                segment2Image.sprite = submittingArticle1Image[1];
                                break;
                            case 2:
                                segment2HeaderText.text = weeklyArticle2Drafts[1];
                                segment2BodyText.text = submittingArticle2Body[1];
                                segment2Image.sprite = submittingArticle2Image[1];
                                break;
                            case 3:
                                segment2HeaderText.text = weeklyArticle3Drafts[1];
                                segment2BodyText.text = submittingArticle3Body[1];
                                segment2Image.sprite = submittingArticle3Image[1];
                                break;
                        }
                        break;
                    case 3:
                        switch (week3Article)
                        {
                            case 1:
                                segment2HeaderText.text = weeklyArticle1Drafts[2];
                                segment2BodyText.text = submittingArticle1Body[2];
                                segment2Image.sprite = submittingArticle1Image[2];
                                break;
                            case 2:
                                segment2HeaderText.text = weeklyArticle2Drafts[2];
                                segment2BodyText.text = submittingArticle2Body[2];
                                segment2Image.sprite = submittingArticle2Image[2];
                                break;
                            case 3:
                                segment2HeaderText.text = weeklyArticle3Drafts[2];
                                segment2BodyText.text = submittingArticle3Body[2];
                                segment2Image.sprite = submittingArticle3Image[2];
                                break;
                        }
                        break;
                    case 4:
                        switch (week4Article)
                        {
                            case 1:
                                segment2HeaderText.text = weeklyArticle1Drafts[3];
                                segment2BodyText.text = submittingArticle1Body[3];
                                segment2Image.sprite = submittingArticle1Image[3];
                                break;
                            case 2:
                                segment2HeaderText.text = weeklyArticle2Drafts[3];
                                segment2BodyText.text = submittingArticle2Body[3];
                                segment2Image.sprite = submittingArticle2Image[3];
                                break;
                            case 3:
                                segment2HeaderText.text = weeklyArticle3Drafts[3];
                                segment2BodyText.text = submittingArticle3Body[3];
                                segment2Image.sprite = submittingArticle3Image[3];
                                break;
                        }
                        break;
                }
                break;
            case 2: // FOR CHANGING WHAT THE POSTED ARTICLE AND COMMENTS SAY
                segment3HeaderText.text = segment2HeaderText.text;
                segment3BodyText.text = segment2BodyText.text;
                segment3Image.sprite = segment2Image.sprite;
                Debug.Log(currentWeek);
                Debug.Log(week1Article);
                switch (currentWeek)
                {
                    case 1:
                        switch (week1Article)
                        {
                            case 1:
                                comment1BodyText.text = article1Comment1Body[0];
                                comment2BodyText.text = article1Comment2Body[0];
                                comment3BodyText.text = article1Comment3Body[0];
                                break;
                            case 2:
                                comment1BodyText.text = article2Comment1Body[0];
                                comment2BodyText.text = article2Comment2Body[0];
                                comment3BodyText.text = article2Comment3Body[0];
                                break;
                            case 3:
                                comment1BodyText.text = article3Comment1Body[0];
                                comment2BodyText.text = article3Comment2Body[0];
                                comment3BodyText.text = article3Comment3Body[0];
                                break;
                        }

                        break;
                    case 2:
                        switch (week2Article)
                        {
                            case 1:
                                comment1BodyText.text = article1Comment1Body[1];
                                comment2BodyText.text = article1Comment2Body[1];
                                comment3BodyText.text = article1Comment3Body[1];
                                break;
                            case 2:
                                comment1BodyText.text = article2Comment1Body[1];
                                comment2BodyText.text = article2Comment2Body[1];
                                comment3BodyText.text = article2Comment3Body[1];
                                break;
                            case 3:
                                comment1BodyText.text = article3Comment1Body[1];
                                comment2BodyText.text = article3Comment2Body[1];
                                comment3BodyText.text = article3Comment3Body[1];
                                break;
                        }

                        break;
                    case 3:
                        switch (week3Article)
                        {
                            case 1:
                                comment1BodyText.text = article1Comment1Body[2];
                                comment2BodyText.text = article1Comment2Body[2];
                                comment3BodyText.text = article1Comment3Body[2];
                                break;
                            case 2:
                                comment1BodyText.text = article2Comment1Body[2];
                                comment2BodyText.text = article2Comment2Body[2];
                                comment3BodyText.text = article2Comment3Body[2];
                                break;
                            case 3:
                                comment1BodyText.text = article3Comment1Body[2];
                                comment2BodyText.text = article3Comment2Body[2];
                                comment3BodyText.text = article3Comment3Body[2];
                                break;
                        }

                        break;
                    case 4:
                        switch (week4Article)
                        {
                            case 1:
                                comment1BodyText.text = article1Comment1Body[3];
                                comment2BodyText.text = article1Comment2Body[3];
                                comment3BodyText.text = article1Comment3Body[3];
                                break;
                            case 2:
                                comment1BodyText.text = article2Comment1Body[3];
                                comment2BodyText.text = article2Comment2Body[3];
                                comment3BodyText.text = article2Comment3Body[3];
                                break;
                            case 3:
                                comment1BodyText.text = article3Comment1Body[3];
                                comment2BodyText.text = article3Comment2Body[3];
                                comment3BodyText.text = article3Comment3Body[3];
                                break;
                        }
                        break;
                }
                break;
            case 3: // FOR CHANGING THE BOSS' EMAIL SUBJECT LINE AND BODY 
                switch (currentWeek)
                {
                    case 1:
                        switch (week1Article)
                        {
                            case 1:
                                emailSubjectLineText.text = article1EmailSubject[0];
                                emailBodyText.text = article1EmailBody[0];
                                break;
                            case 2:
                                emailSubjectLineText.text = article2EmailSubject[0];
                                emailBodyText.text = article2EmailBody[0];
                                break;
                            case 3:
                                emailSubjectLineText.text = article3EmailSubject[0];
                                emailBodyText.text = article3EmailBody[0];
                                break;
                        }

                        break;
                    case 2:
                        switch (week2Article)
                        {
                            case 1:
                                emailSubjectLineText.text = article1EmailSubject[1];
                                emailBodyText.text = article1EmailBody[1];
                                break;
                            case 2:
                                emailSubjectLineText.text = article2EmailSubject[1];
                                emailBodyText.text = article2EmailBody[1];
                                break;
                            case 3:
                                emailSubjectLineText.text = article3EmailSubject[1];
                                emailBodyText.text = article3EmailBody[1];
                                break;
                        }

                        break;
                    case 3:
                        switch (week3Article)
                        {
                            case 1:
                                emailSubjectLineText.text = article1EmailSubject[2];
                                emailBodyText.text = article1EmailBody[2];
                                break;
                            case 2:
                                emailSubjectLineText.text = article2EmailSubject[2];
                                emailBodyText.text = article2EmailBody[2];
                                break;
                            case 3:
                                emailSubjectLineText.text = article3EmailSubject[2];
                                emailBodyText.text = article3EmailBody[2];
                                break;
                        }

                        break;
                    case 4:
                        switch (week4Article)
                        {
                            case 1:
                                emailSubjectLineText.text = article1EmailSubject[3];
                                emailBodyText.text = article1EmailBody[3];
                                break;
                            case 2:
                                emailSubjectLineText.text = article2EmailSubject[3];
                                emailBodyText.text = article2EmailBody[3];
                                break;
                            case 3:
                                emailSubjectLineText.text = article3EmailSubject[3];
                                emailBodyText.text = article3EmailBody[3];
                                break;
                        }
                        break;
                }
                break;
        }
    }

    public void SelectArticle(int article)
    {
        switch (currentWeek)
        {
            case 1:
                week1Article = article;
                Debug.Log("Article " + week1Article + " selected");
                break;
            case 2: 
                week2Article = article;
                Debug.Log("Article " + week2Article + " selected");
                break;
            case 3: 
                week3Article = article;
                Debug.Log("Article " + week3Article + " selected");
                break;
            case 4: 
                week4Article = article;
                Debug.Log("Article " + week4Article + " selected");
                break;
        }
    }

    public void SubmitArticle()
    {
        StartCoroutine(Segment3Timer());
    }

    public void Ending()
    {
        currentWeek++;
        weekCounter.text = "Week " + currentWeek;
        
        if (currentWeek == 5)
        {
            Debug.Log("RESULTS:\nWeek 1: Article " + week1Article + "\nWeek 2: Article " + week2Article + "\nWeek 3: Article " + week3Article + "\nWeek 4: Article " + week4Article);

            SceneManager.LoadScene(levelToLoadAtEnd);
        }
    }

    private IEnumerator Segment3Timer()
    {
        StartCoroutine(CommentsAppear());
        yield return new WaitForSeconds(segment3Time);
        UpdateArticles(3);
        segment3.SetActive(false);
        segment4.SetActive(true);
    }

    private IEnumerator CommentsAppear()
    {
        yield return new WaitForSeconds(segment3CommentsDelay);
        comment1.SetActive(true);
        yield return new WaitForSeconds(segment3CommentsDelay);
        comment2.SetActive(true);
        yield return new WaitForSeconds(segment3CommentsDelay);
        comment3.SetActive(true);
    }
}