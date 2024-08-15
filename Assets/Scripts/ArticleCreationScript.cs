using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArticleCreationScript : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float segment3Time;
    [SerializeField] private float segment3CommentsDelay;
    [SerializeField] private string levelToLoadAtEnd;
    private int week1Article;
    private int week2Article;
    private int week3Article;
    private int week4Article;
    private int currentWeek = 1;

    [Header("Object References")]
    [SerializeField] private TextMeshProUGUI weekCounter;
    [SerializeField] private GameObject comment1;
    [SerializeField] private GameObject comment2;
    [SerializeField] private GameObject comment3;
    [SerializeField] private GameObject segment3;
    [SerializeField] private GameObject segment4;

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
