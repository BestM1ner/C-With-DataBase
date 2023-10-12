using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    public SqliteConnection dbConnection;
    public InputField regName, regPass, regMail, record;
    
    private string path;

    public void setConnection() 
    {
        path = Application.dataPath + "/StreamingAssets/users.db";
        dbConnection = new SqliteConnection("URI=file:" + path);
        dbConnection.Open();
        if (dbConnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = "SELECT * FROM USERS";
            SqliteDataReader read = cmd.ExecuteReader();
            while (read.Read())
                Debug.Log(String.Format("{0}   {1}   {2}   {3}   {4}", read[0], read[1], read[2], read [3], read[4]));
        }
        else
            Debug.Log("Error connection");

    }

    public void addUser()
    {
        path = Application.dataPath + "/StreamingAssets/users.db";
        dbConnection = new SqliteConnection("URI=file:" + path);
        dbConnection.Open();
        if (dbConnection.State == ConnectionState.Open)
        {
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = dbConnection;
            cmd.CommandText = "INSERT INTO USERS (name, password, mail, record) VALUES (' " + regName.text +"','" + regPass.text + "','" + regMail.text + "','" + record.text + "');";
            cmd.ExecuteReader();
            //while (read.Read())
                //Debug.Log(String.Format("{0}   {1}   {2}   {3}", read[0], read[1], read[2], read[3]));
        }
        dbConnection.Close();
    }
}
