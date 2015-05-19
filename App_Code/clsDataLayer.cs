// Add your comments here
using System.Data.OleDb;
using System.Net;
using System.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDataLayer
/// </summary>
public class clsDataLayer
{
    // This function gets the user activity from the tblUserActivity
    public static dsUserActivity GetUserActivity(string Database)
    {
        // Declares the variables for the required classes
        dsUserActivity DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        //Stores the server path as a sql instruction into the variable
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);
        // Stores the sql instructions to show all tables from the specified tables
        sqlDA = new OleDbDataAdapter("select * from tblUserActivity", sqlConn);
        // stores the user activity into variable
        DS = new dsUserActivity();
        // The useractivity is entered into the dataset through the Fill command.
        sqlDA.Fill(DS.tblUserActivity);
        // The dataset is returned for the user to see.
        return DS;
    }
    // This function saves the user activity
    public static void SaveUserActivity(string Database, string FormAccessed)
    {
        //The connection is created and given a path to follow in sql instructions
        OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + Database);
        //The connection is opened. The server path is stored in the command variable.
        conn.Open();
        OleDbCommand command = conn.CreateCommand();
        // String object is declared and stored inside is sql commands to store values
        string strSQL;
        strSQL = "Insert into tblUserActivity (UserIP, FormAccessed) values ('" +
        GetIP4Address() + "', '" + FormAccessed + "')";
        //The commands are executed and the connection is closed.
        command.CommandType = CommandType.Text;
        command.CommandText = strSQL;
        command.ExecuteNonQuery();
        conn.Close();
    }
    // This function gets the IP Address
    public static string GetIP4Address()
    {
        string IP4Address = string.Empty;
        foreach (IPAddress IPA in
        Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        if (IP4Address != string.Empty)
        {
            return IP4Address;
        }
        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }
        return IP4Address;
    }
	public clsDataLayer()
	{

	}
    // This function saves the personnel data
    public static bool SavePersonnel(string Database, string FirstName, string LastName,
    string PayRate, string StartDate, string EndDate)
    {
        bool recordSaved;
        // declares a variable and instantiates it to null. The try catch block
        //executes to see if try works, if an error occurs, the catch block will 
        //handle the error.
        OleDbTransaction myTransaction = null;
        try
        {
            // Sets server path and opens connectioin.
            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + Database);
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;
            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;
            //Stores the sql commands to store the values
            strSQL = "Insert into tblPersonnel " +
            "(FirstName, LastName) values ('" +
            FirstName + "', '" + LastName + "')";
            // executes the sql commands stored in the variable.
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            
            command.ExecuteNonQuery();
            //Stores the sql commands to update the person that was added with more
            //information such as payrate, start date and end date.
            strSQL = "Update tblPersonnel " +
            "Set PayRate=" + PayRate + ", " +
            "StartDate='" + StartDate + "', " +
            "EndDate='" + EndDate + "' " +
            "Where ID=(Select Max(ID) From tblPersonnel)";
            // Commands are executed to update
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            // Executes sql statements to return the rows affected
            command.ExecuteNonQuery();
            // The table is saved.
            myTransaction.Commit();
            // Connection is closed
            conn.Close();
            recordSaved = true;
        }
        catch (Exception ex)
        {
            // The changes from the try block are undone and returns a false result.
            myTransaction.Rollback();
            recordSaved = false;
        }
        return recordSaved;
    }
    // This function gets the user activity from the tblPersonnel
    public static dsPersonnel GetPersonnel(string Database, string strSearch)
    {
        // declare variables
        dsPersonnel DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        // sets command value for sql connection
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Database);
        // checks the strSearch for null and displays all values or the strSearch value if not null
        if (strSearch == null || strSearch.Trim() == "")
        {
            sqlDA = new OleDbDataAdapter("select * from tblPersonnel", sqlConn);
        }
        else
        {
            sqlDA = new OleDbDataAdapter("select * from tblPersonnel where LastName = '" + strSearch + "'", sqlConn);
        }
        // saves the personnel information into varaible
        DS = new dsPersonnel();
        // the personnel information is filled into the database
        sqlDA.Fill(DS.tblPersonnel);
        // the information is returned
        return DS;
    }
    // This function verifies a user in the tblUser table
    public static dsUser VerifyUser(string Database, string UserName, string UserPassword)
    {
        // Add your comments here
        dsUser DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;
        // Add your comments here
        sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source=" + Database);
        // Add your comments here
        sqlDA = new OleDbDataAdapter("Select SecurityLevel from tblUserLogin " +
        "where UserName like '" + UserName + "' " +
        "and UserPassword like '" + UserPassword + "'", sqlConn);
        // Add your comments here
        DS = new dsUser();
        // Add your comments here
        sqlDA.Fill(DS.tblUserLogin);
        // Add your comments here
        return DS;
    }    
    public static bool SaveUser(string Database, string UserName, string Password,
string SecurityLevel)
        {
            bool recordSaved;
            // Creates variable and instantiates to null
            OleDbTransaction myTransaction = null;
            try
            {
                // Sets server path and opens connection
                OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" + Database);
                conn.Open();
                OleDbCommand command = conn.CreateCommand();
                string strSQL;
                // The connection begins sending commands
                myTransaction = conn.BeginTransaction();
                command.Transaction = myTransaction;
                // Stores sql commands to insert values into the table
                strSQL = "Insert into tblUserLogin " +
                "(UserName, UserPassword, SecurityLevel) values ('" +
                UserName + "', '" + Password + "', '" + SecurityLevel +"')";
                // The sql commands are executed
                command.CommandType = CommandType.Text;
                command.CommandText = strSQL;
                command.ExecuteNonQuery();
              
                // The changes are saved
                myTransaction.Commit();
                // The connection is closed.
                conn.Close();
                recordSaved = true;
            }
            catch (Exception ex)
            {
                // The catchblock caught an error and reverses all the changes 
                //returns a false result for the record saved.
                myTransaction.Rollback();
                recordSaved = false;
            }
            return recordSaved;
        
    }
}