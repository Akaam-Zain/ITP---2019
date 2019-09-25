namespace Inventory_management.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class DBModel : DbContext
    {
      
        public DBModel() : base("name=DBModel")
        {
        }

        public List<income> incomeData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password;database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM income", con);

            var model = new List<income>();
            
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DateTime dt = System.DateTime.Parse(rdr["date"].ToString());
                var income = new income();
                income.id = int.Parse(rdr["id"].ToString());
                income.date = dt.ToString("yyyy-MM-dd");
                income.category = rdr["category"].ToString();
                income.cash = Double.Parse(rdr["cash"].ToString());
                income.pos = Double.Parse(rdr["pos"].ToString());
                income.total = Double.Parse(rdr["amount"].ToString());
                model.Add(income);
            }

            return model;
        }

        public void incomeInsert(income income)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password; database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO income (date, category, cash, pos, amount) VALUES (@date, @category, @cash, @pos, @total)", con);

            cmd.Parameters.AddWithValue("@date", income.date);
            cmd.Parameters.AddWithValue("@category", income.category);
            cmd.Parameters.AddWithValue("@cash", income.cash);
            cmd.Parameters.AddWithValue("@pos", income.pos);
            cmd.Parameters.AddWithValue("@total", income.total);

            cmd.ExecuteNonQuery();


        }

        public void incomeEdit(income income)
        {

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password; database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE income SET date = @date, category = @category, cash = @cash, pos = @pos, amount = @total WHERE id = @id", con);

            cmd.Parameters.AddWithValue("@date", income.date);
            cmd.Parameters.AddWithValue("@category", income.category);
            cmd.Parameters.AddWithValue("@cash", income.cash);
            cmd.Parameters.AddWithValue("@pos", income.pos);
            cmd.Parameters.AddWithValue("@total", income.total);
            cmd.Parameters.AddWithValue("@id", income.id);

            cmd.ExecuteNonQuery();


        }

        public void deleteIncome(income income)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password; database=inventorymgt;allowuservariables=True");

            con.Open();

            MySqlCommand cmd = new MySqlCommand("delete from income where id = @id", con);

            cmd.Parameters.AddWithValue("@id", income.id);

            cmd.ExecuteNonQuery();


        }

        public List<daily> dailyData()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password;database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM daily", con);

            var model = new List<daily>();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DateTime dt = System.DateTime.Parse(rdr["date"].ToString());
                var daily = new daily();
                daily.id = int.Parse(rdr["id"].ToString());
                daily.date = dt.ToString("yyyy-MM-dd");
                daily.category = rdr["category"].ToString();
                daily.savings = Double.Parse(rdr["savings"].ToString());
                daily.amount = Double.Parse(rdr["amount"].ToString());
                model.Add(daily);
            }

            return model;
        }

        public void deleteDaily(daily daily)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password; database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("delete from daily where id = @id", con);

            cmd.Parameters.AddWithValue("@id", daily.id);

            cmd.ExecuteNonQuery();
        }

        public void editDaily(daily daily)
        {

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password; database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("UPDATE daily SET date = @date, category = @category, savings = @savings, amount = @amount WHERE id = @id", con);

            cmd.Parameters.AddWithValue("@date", daily.date);
            cmd.Parameters.AddWithValue("@category", daily.category);
            cmd.Parameters.AddWithValue("@savings", daily.savings);
            cmd.Parameters.AddWithValue("@amount", daily.amount);
            cmd.Parameters.AddWithValue("@id", daily.id);

            cmd.ExecuteNonQuery();
        }

        public void dailyInsert(daily daily)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password; database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO daily (date, category, savings, amount) VALUES (@date, @category, @savings, @amount)", con);

            cmd.Parameters.AddWithValue("@date", daily.date);
            cmd.Parameters.AddWithValue("@category", daily.category);
            cmd.Parameters.AddWithValue("@savings", daily.savings);
            cmd.Parameters.AddWithValue("@amount", daily.amount);

            cmd.ExecuteNonQuery();

        }

        public List<statement> statementData(String year, String month)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=password; database=inventorymgt;allowuservariables=True");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COALESCE(SUM(amount),0) as income,(SELECT COALESCE(SUM(amount),0) FROM daily WHERE year(date)='"+year+"' and month(date)='"+month+ "') as daily,COALESCE(SUM(amount),0) -(SELECT COALESCE(SUM(amount),0) FROM daily WHERE year(date)='" + year + "' and month(date)='" + month + "') as profit FROM income WHERE year(date)='" + year + "' and month(date)='" + month + "'", con);

            var model = new List<statement>();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var statement = new statement();
                statement.incomes = double.Parse(rdr["income"].ToString());
                statement.dailys = double.Parse(rdr["daily"].ToString());
                statement.total = double.Parse(rdr["profit"].ToString());
                model.Add(statement);
            }

            return model;
        }

    }

    public class income
    {
        public int id { get; set; }
        public string date { get; set; }
        public string category { get; set; }
        public Double cash { get; set; }
        public Double pos { get; set; }
        public Double total { get; set; }
    }

    public class daily
    {
        public int id { get; set; }
        public string date { get; set; }
        public string category { get; set; }
        public Double savings { get; set; }
        public Double amount { get; set; }

    }

    public class statement
    {
        public Double incomes { get; set; }
        public Double dailys { get; set; }
        public Double total { get; set; }
    }

}