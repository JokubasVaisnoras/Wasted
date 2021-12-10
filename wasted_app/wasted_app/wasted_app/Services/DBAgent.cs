using System;
using System.Data.SqlClient;
using System.Data;
using wasted_app.Models;
using System.Collections.Generic;

namespace wasted_app.Services
{
    public class DBAgent
    {
        public void AddItemToDB(Item item)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=BULL-LEGION\\SQLEXPRESS, 1433;Initial Catalog=wasted;User Id=wastedproj;Password=wasted2021";
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Items (Name, Description, Price, Expiration, Type1, Type2, Amount) VALUES ('{item.Name}', '{item.Description}', {item.Price}, '{item.Expiration}', '{item.Type1}', '{item.Type2}', {item.Amount})";
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("DB error");
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public List<Item> ShowItems()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=BULL-LEGION\\SQLEXPRESS, 1433;Initial Catalog=wasted;User Id=wastedproj;Password=wasted2021";
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"SELECT Id, Name, Description, Price, Expiration, Type1, Type2, Amount FROM Items";
                    List<Item> itemsList = new List<Item>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            itemsList.Add(new Item
                            {
                                Id = dr["Id"].ToString(),
                                Name = dr["Name"].ToString(),
                                Description = dr["Description"].ToString(),
                                Price = (double)dr["Price"],
                                Expiration = dr["Expiration"].ToString(),
                                Type1 = dr["Type1"].ToString(),
                                Type2 = dr["Type2"].ToString(),
                                Amount = (int)dr["Amount"]
                            });
                        }
                        return itemsList;
                    }
                    dr.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("DB error");
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    cn.Close();
                }
            }
            return null;
        }

        public void DeleteItem(string id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=BULL-LEGION\\SQLEXPRESS, 1433;Initial Catalog=wasted;User Id=wastedproj;Password=wasted2021";
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"DELETE FROM Items WHERE Name LIKE '{id}'";
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("DB error");
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public void UpdateItemDescription(string id, string newText)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=BULL-LEGION\\SQLEXPRESS, 1433;Initial Catalog=wasted;User Id=wastedproj;Password=wasted2021";
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"UPDATE Items SET Description = '{newText}' WHERE Name LIKE '{id}'";
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("DB error");
                    Console.WriteLine(ex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}