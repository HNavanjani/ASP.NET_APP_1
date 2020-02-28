using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository: IUserRepository
    {

        
        private string _conString;
        public UserRepository(string conString)
        {
            _conString = conString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            try
            {
                List<User> _userList = new List<User>();

                using (var con = new SqlConnection(_conString))
                {
                    using (var cmd = new SqlCommand("GetUsers", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //use db column names
                                object id = reader["Id"];
                                if (id == DBNull.Value)
                                {
                                    id = 0;

                                }

                                object userName = reader["UserName"];
                                if (userName == DBNull.Value)
                                {
                                    userName = "";
                                }

                                object password = reader["Password"];
                                if (password == DBNull.Value)
                                {
                                    password = "";
                                }

                                object firstName = reader["FirstName"];
                                if (firstName == DBNull.Value)
                                {
                                    firstName = "";
                                }

                                object lastName = reader["LastName"];
                                if (lastName == DBNull.Value)
                                {
                                    lastName = "";
                                }

                                object isActive = reader["IsActive"];
                                if (isActive == DBNull.Value)
                                {
                                    isActive = false;
                                }


                                _userList.Add(new User
                                {
                                    Id = Convert.ToInt64(id),
                                    UserName = Convert.ToString(userName),
                                    Password = Convert.ToString(password),
                                    FirstName = Convert.ToString(firstName),
                                    LastName = Convert.ToString(lastName),
                                    IsActive = Convert.ToBoolean(isActive)
                                });

                            }

                        }
                       
                    }
                }
                return _userList;
            }
            catch (Exception e)
            {

                return null; 
            }
        }


        public User GetUser(int id)
        {
            User user = new User();

            try
            {
                using (var con = new SqlConnection(_conString))
                {
                    using (var cmd = new SqlCommand("GetUser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt).Value = id;

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //use db column names
                                object userName = reader["UserName"];
                                if (userName == DBNull.Value)
                                {
                                    userName = "";
                                }

                                object password = reader["Password"];
                                if (password == DBNull.Value)
                                {
                                    password = "";
                                }

                                object firstName = reader["FirstName"];
                                if (firstName == DBNull.Value)
                                {
                                    firstName = "";
                                }

                                object lastName = reader["LastName"];
                                if (lastName == DBNull.Value)
                                {
                                    lastName = "";
                                }

                                object isActive = reader["IsActive"];
                                if (isActive == DBNull.Value)
                                {
                                    isActive = false;
                                }

                                user.Id = Convert.ToInt64(id);
                                user.UserName = Convert.ToString(userName);
                                user.Password = Convert.ToString(password);
                                user.FirstName = Convert.ToString(firstName);
                                user.LastName = Convert.ToString(lastName);
                                user.IsActive = Convert.ToBoolean(isActive);
                            }

                        }
                    }
                }
                return user;

            }
            catch (Exception e)
            {

                return null;
            }
        }



        public Boolean DeleteUser(int id)
        {
            try
            {
                using (var con = new SqlConnection(_conString))
                {
                    using (var cmd = new SqlCommand("DeleteUser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt).Value = id;

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.RecordsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }   
                }
               
            }
            catch (Exception e)
            {

                return false;
            }
        }






        public User SaveUser(User user)
        {
            try
            {
                using (var con = new SqlConnection(_conString))
                {
                    using (var cmd = new SqlCommand("SaveUser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        

                        cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt).Value = user.Id;
                        cmd.Parameters.Add("@userName", System.Data.SqlDbType.NVarChar).Value = user.UserName;
                        cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = user.Password;
                        cmd.Parameters.Add("@firstName", System.Data.SqlDbType.NVarChar).Value = user.FirstName;
                        cmd.Parameters.Add("@lastName", System.Data.SqlDbType.NVarChar).Value = user.LastName;
                        cmd.Parameters.Add("@isActive", System.Data.SqlDbType.Bit).Value = user.IsActive;

                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        //Get Id of newly added record


                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //use db column names
                                object id = reader["Id"];
                                if (id == DBNull.Value)
                                {
                                    id = 0;

                                }

                                object userName = reader["UserName"];
                                if (userName == DBNull.Value)
                                {
                                    userName = "";
                                }

                                object password = reader["Password"];
                                if (password == DBNull.Value)
                                {
                                    password = "";
                                }

                                object firstName = reader["FirstName"];
                                if (firstName == DBNull.Value)
                                {
                                    firstName = "";
                                }

                                object lastName = reader["LastName"];
                                if (lastName == DBNull.Value)
                                {
                                    lastName = "";
                                }

                                object isActive = reader["IsActive"];
                                if (isActive == DBNull.Value)
                                {
                                    isActive = false;
                                }
                                user.Id = Convert.ToInt64(id);
                                user.UserName = Convert.ToString(userName);
                                user.Password = Convert.ToString(password);
                                user.FirstName = Convert.ToString(firstName);
                                user.LastName = Convert.ToString(lastName);
                                user.IsActive = Convert.ToBoolean(isActive);
                            }

                        }


                        if (reader.RecordsAffected > 0)
                        {
                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
