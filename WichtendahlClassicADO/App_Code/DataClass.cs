using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// This class will connect to the database.
/// It will have methods to retrieve the Authors.
/// It will also retrieve all the books by that author.
/// 
/// Travis Wichtendahl : 4/19/2016
/// </summary>
public class DataClass
{
    //DataClass Properties
    private SqlConnection connect;
    public DataClass()
    {
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["BookReviewConnectionString"].ToString());
    }//end constructor

    public DataTable GetAuthors()
    {
        string sql = "SELECT authorkey, authorname FROM Author";
        SqlCommand cmd = new SqlCommand(sql, connect);

        DataTable tbl = ReadData(cmd);
        return tbl;
    }

    public DataTable GetBooks(int authorKey)
    {

        string sql = "SELECT * FROM book INNER JOIN authorbook ON book.bookkey= authorbook.bookkey WHERE authorkey = @authorkey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@authorkey", authorKey);

        DataTable tbl = ReadData(cmd);
        return tbl;
    }

    private DataTable ReadData(SqlCommand cmd)
    {
        SqlDataReader reader = null;
        DataTable tbl = new DataTable();

        connect.Open();
        reader = cmd.ExecuteReader();
        tbl.Load(reader);
        reader.Close();
        connect.Close();

        return tbl;
    }
}//end class