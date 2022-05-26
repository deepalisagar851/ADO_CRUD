using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdoMvc.ViewModel;
using System.Data.SqlClient;
using System.Data;

namespace AdoMvc.Models
{
    public class EmployeeDb
    {
        private DbConfig db = new DbConfig();
        public List<Employee> GetEmployees()
        {
            SqlCommand cmd = new SqlCommand("sp_emp", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@action";
            sqlParameter.Value = "Select";
            sqlParameter.DbType = DbType.String;
            cmd.Parameters.Add(sqlParameter);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee obj = new Employee();
                obj.Id = (int)reader[0];
                obj.Name = reader[1].ToString();
                obj.Email = reader[2].ToString();
                obj.Mobile = reader[3].ToString();
                obj.Adress = reader[4].ToString();
                obj.Gender = reader[5].ToString();
                obj.IsActive = reader[6].ToString();

                employees.Add(obj);
            }
            db.sql.Close();
            return employees;
        }

        public void CreateList(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("sp_emp", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@action", "Create");
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@Adress", emp.Adress);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();
        }

        public void DeleteList(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_emp", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@action", "Delete");
            cmd.Parameters.AddWithValue("@Id", id);
            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();
        }

        public void UpdateList(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("sp_emp", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@action", "Update");
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
            cmd.Parameters.AddWithValue("@Adress", emp.Adress);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);

            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();
            var result = cmd.ExecuteReader();
            db.sql.Close();
        }
    }
}