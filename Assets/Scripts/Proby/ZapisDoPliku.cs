using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.UI;
using System.Data;

public class ZapisDoPliku : MonoBehaviour
{

    public Text Name;
    public Text Points;
    public Text Date;
    private List<Data>listaWynikow;

    // Start is called before the first frame update
    protected void Awake()
    {
        listaWynikow = new List<Data>()
        {
            new Data{nazwaGracza = "abc", punkty = 25, czas = DateTime.Now },
            new Data{nazwaGracza = "dbc", punkty = 28, czas = DateTime.Now },
            new Data{nazwaGracza = "ebc", punkty = 30, czas = DateTime.Now },
        };

        // tutaj sortowanie wyników 

        //Highscores highscores = new Highscores { listaWynikow = listaWynikow };
    }

    public void Save()
    {
        Debug.Log("Save");

        FileStream plik = File.Create(Application.persistentDataPath + "/gameSave.data");
        /*
        Data dane = new Data();
        dane.nazwaGracza = Name.text;
        dane.punkty = int.Parse(Points.text);
        dane.czas = DateTime.Now;

        //dane.wynik = new Data.Wynik(Name.text, int.Parse(Points.text), DateTime.Now); 
        //dane.listaWynikow.Add(new Data.Wynik(Name.text, int.Parse(Points.text), DateTime.Now));
        //dane.listaWynikow.Sort();
        */
        listaWynikow = new List<Data>()
        {
            new Data{nazwaGracza = "abc", punkty = 25, czas = DateTime.Now },
            new Data{nazwaGracza = "dbc", punkty = 28, czas = DateTime.Now },
            new Data{nazwaGracza = "ebc", punkty = 30, czas = DateTime.Now },
        };

        Debug.Log(listaWynikow.ToString());
        Highscores2 highscores = new Highscores2 { listaWynikow = listaWynikow };
        Debug.Log(highscores.ToString());

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(plik, highscores);
        plik.Close();
    }

    public void Save2()
    {
        Debug.Log("Save");

        FileStream plik = File.Create(Application.persistentDataPath + "/gameSave.data");

        Data dane = new Data();
        dane.nazwaGracza = Name.text;
        dane.punkty = int.Parse(Points.text);
        dane.czas = DateTime.Now;

        //dane.wynik = new Data.Wynik(Name.text, int.Parse(Points.text), DateTime.Now); 
        //dane.listaWynikow.Add(new Data.Wynik(Name.text, int.Parse(Points.text), DateTime.Now));
        //dane.listaWynikow.Sort();

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(plik, dane);
        plik.Close();
    }

}

public class Highscores2
{
    public List<Data> listaWynikow;
}

[Serializable]
public class Data
{
    public String nazwaGracza;
    public int punkty;
    public DateTime czas;

    //public Wynik wynik;
    //public List<Wynik> listaWynikow;

    /*
    public struct Wynik
    {
        public String nazwa;
        public int punkty;
        public DateTime data;

        public Wynik(string nazwa, int punkty, DateTime data)
        {
            this.nazwa = nazwa;
            this.punkty = punkty;
            this.data = data;
        }
    }
    */
}

