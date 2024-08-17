using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArticleCreationScript : MonoBehaviour
{
    [Header("Values > Segment 1")]
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> weeklyArticle1Drafts = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> weeklyArticle2Drafts = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> weeklyArticle3Drafts = new List<string>();
    private int week1Article;
    private int currentWeek = 1;

    [Header("Values > Segment 2")]
    [SerializeField] private TextMeshProUGUI segment2HeaderText;
    [SerializeField] private TextMeshProUGUI segment2BodyText;
    [SerializeField] private Image segment2Image;
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> submittingArticleHeadline = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<string> submittingArticleBody = new List<string>();
    [Tooltip("Each subsequent entry into this list is counted as the next week, e.g. entry 2 is counted as week 2")] [SerializeField] private List<Sprite> submittingArticleImage = new List<Sprite>();
    private int week2Article;

    [Header("Values > Segment 3")]
    [SerializeField] private float segment3Time;
    [SerializeField] private float segment3CommentsDelay;
    private int week3Article;

    [Header("Values > Segment 4")]
    [SerializeField] private string levelToLoadAtEnd;
    private int week4Article;

    [Header("Object References > Segment 1")]
    [SerializeField] private TextMeshProUGUI weekCounter;
    [SerializeField] private GameObject article1;
    [SerializeField] private GameObject article2;
    [SerializeField] private GameObject article3;

    [Header("Object References > Segment 3")]
    [SerializeField] private GameObject segment3;
    [SerializeField] private GameObject comment1;
    [SerializeField] private GameObject comment2;
    [SerializeField] private GameObject comment3;

    [Header("Object References > Segment 4")]
    [SerializeField] private GameObject segment4;

    private void OnEnable()
    {
        UpdateArticles(0);
    }

    public void UpdateArticles(int segment)
    {
        switch (segment)
        {
            case 0:
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
            /*case 1:
                switch (currentWeek)
                {
                    case
                }
            */
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
        currentWeek++;
        weekCounter.text = "Week " + currentWeek;

        StartCoroutine(Segment3Timer());
    }

    public void Ending()
    {
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
