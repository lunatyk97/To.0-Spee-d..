using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.UI;
using System.Xml.Schema;

public class OdczytZPliku : MonoBehaviour
{

    public Text Name;
    public Text Points;
    public Text Date;
    public int Id = 0;

    // Start is called before the first frame update
    void Start()
    {
        Read();
    }


    public void Read()
    {
        Debug.Log("Read");

        if (File.Exists(Application.persistentDataPath + "/gameSave.data"))
        {
            FileStream plik = File.Open(Application.persistentDataPath + "/gameSave.data", FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();

            //Data dane = (Data)bf.Deserialize(plik);
            Highscores2 highscores = (Highscores2)bf.Deserialize(plik);
            plik.Close();

            Name.text = highscores.listaWynikow[0].nazwaGracza.ToString();
            Points.text = highscores.listaWynikow[0].punkty.ToString();
            Date.text = highscores.listaWynikow[0].czas.ToString();

            //Name.text = dane.listaWynikow[Id].nazwa.ToString();
            //Points.text = dane.listaWynikow[Id].punkty.ToString();
            // Date.text = dane.listaWynikow[Id].data.ToString();
        }
    }
    public void Read2()
    {
        Debug.Log("Read");

        if(File.Exists(Application.persistentDataPath + "/gameSave.data"))
        {
            FileStream plik = File.Open(Application.persistentDataPath + "/gameSave.data", FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();

            Data dane = (Data)bf.Deserialize(plik);
            plik.Close();

            Name.text = dane.nazwaGracza.ToString();
            Points.text = dane.punkty.ToString();
            Date.text = dane.czas.ToString();

            //Name.text = dane.listaWynikow[Id].nazwa.ToString();
            //Points.text = dane.listaWynikow[Id].punkty.ToString();
           // Date.text = dane.listaWynikow[Id].data.ToString();
        }
    }

}

