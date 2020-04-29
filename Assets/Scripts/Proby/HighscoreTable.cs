using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
	public Transform entryContainer;
	public Transform entryTemplate;
	public List<HighscoreEntry> highscoreEntryList;
	public List<Transform> highscoreEntryTransformList;
	
	public void Awake()
	{
		entryContainer = transform.Find("HighscoreContainer");
		entryTemplate = entryContainer.Find("HighscoreEntryTemplate");
		
		entryTemplate.gameObject.SetActive(false);
		
		
		string jsonString = PlayerPrefs.GetString("highscoreTable");
		Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
		
		for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
		{
			for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
			{
				if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
				{
					HighscoreEntry tmp = highscores.highscoreEntryList[i];
					highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
					highscores.highscoreEntryList[j] = tmp;
				}
			}
		}
		
		highscoreEntryTransformList = new List<Transform>();
		foreach(HighscoreEntry highscoreEntry in highscoreEntryList)
		{
			CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
		}

	}
		
		public void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
		{
		
			float templateHeigh = 30f;
	
			Transform entryTransform = Instantiate(entryTemplate, entryContainer);
			RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
			entryRectTransform.anchoredPosition = new Vector2(0, -templateHeigh * transformList.Count);
			entryTransform.gameObject.SetActive(true);
			
			int rank = transformList.Count + 1;
			string rankString;
			switch(rank)
			{
			default:
				rankString = rank + "TH"; break;
				
			case 1: rankString = "1ST"; break;
			case 2: rankString = "2ND"; break;
			case 3: rankString = "3RD"; break;
			}
			
			entryTransform.Find("PositionText").GetComponent<Text>().text = rankString;
			
			int score = highscoreEntry.score;
			
			entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
			
			string name = highscoreEntry.name;
			
			entryTransform.Find("NicknameText").GetComponent<Text>().text = name;
			
			entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
			
			if(rank == 1)
			{
				entryTransform.Find("PositionText").GetComponent<Text>().color = Color.green;
				entryTransform.Find("ScoreText").GetComponent<Text>().color = Color.green;
				entryTransform.Find("NicknameText").GetComponent<Text>().color = Color.green;
			}
			
			transformList.Add(entryTransform);
		}
		
		public void AddHighscoreEntry(int score, string name)
		{
			HighscoreEntry highscoreEntry = new HighscoreEntry {score = score, name = name};
			
			Highscores highscores = new Highscores {highscoreEntryList = highscoreEntryList};
			string json = JsonUtility.ToJson(highscores);
			
			highscores.highscoreEntryList.Add(highscoreEntry);
			
			PlayerPrefs.SetString("highscoreTable", json);
			PlayerPrefs.Save();
		}
		
		public class Highscores 
		{
			public List<HighscoreEntry> highscoreEntryList;
		}
		
		[System.Serializable]
		public class HighscoreEntry
		{
			public int score;
			public string name;
		}
    }
