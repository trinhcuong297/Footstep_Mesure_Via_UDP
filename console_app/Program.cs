/*==========================================================================
* Using namespace
*/
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

/*==========================================================================
* Global variable
*/
string myConnectionString = "server=127.0.0.1;uid=root;pwd=Caocuong297@;database=iotdb";
MySqlConnection mySQLConnection;


/*===========================================================================
* Prototype
*/
/* Execute MySQL command */
static void MySQLCommunication(string command, MySqlConnection mySQLConnection)
{
    MySqlCommand myCommand = new MySqlCommand();
    myCommand.Connection = mySQLConnection;
    myCommand.CommandText = command;
    try
    {
        myCommand.ExecuteReader();
        Console.WriteLine("[MySQL] " + command);
    }
    catch (Exception ex)
    {
        Console.WriteLine("[ERROR - MySQL]" + ex);
    }
}


/*===========================================================================
* Main program below here
*/
try
{
    /* Open MySQL connection */
    mySQLConnection = new MySqlConnection(myConnectionString);
    mySQLConnection.Open();
    Console.WriteLine("[MySQL] Open connection to "+myConnectionString);

    /* Create table "Devices" if not exist */
    MySQLCommunication("CREATE TABLE IF NOT EXISTS Devices (id int, name varchar(255))", mySQLConnection);


}
catch (MySqlException ex)
{
    Console.Write("[ERROR - MAIN] " + ex);
}

