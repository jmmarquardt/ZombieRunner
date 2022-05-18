using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SimpleDB : MonoBehaviour
{
    string _dbName = "URI=file:Inventory.db";

    void Start()
    {
        CreateDB();
    }

    void CreateDB()
    {
        using (var connection = new SqliteConnection(_dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS weapons (name VARCHAR(20), damage INT);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
