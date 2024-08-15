using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleCreationScript : MonoBehaviour
{
    private int week1Article;
    private int week2Article;
    private int week3Article;
    private int week4Article;
    private int currentWeek = 1;

    public void SelectArticle(int article)
    {
        switch (currentWeek)
        {
            case 1:
                week1Article = article;
                Debug.Log(week1Article);
                break;
            case 2: 
                week2Article = article;
                Debug.Log(week2Article);
                break;
            case 3: 
                week3Article = article;
                Debug.Log(week3Article);
                break;
            case 4: 
                week4Article = article;
                Debug.Log(week4Article);
                break;
        }
    }

    public void SubmitArticle()
    {
        currentWeek++;

        if (currentWeek == 5)
        {
            Debug.Log("Week 1: " + week1Article + ", Week 2:" + week2Article + ", Week 3: " + week3Article + ", Week 4: " + week4Article);
        }
        else
        {
            Debug.Log(currentWeek);
        }
    }
}
