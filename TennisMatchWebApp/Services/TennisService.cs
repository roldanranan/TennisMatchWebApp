using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TennisMatchWebApp.Models;
using System.Data.Entity;

namespace TennisMatchWebApp.Services
{
    public class TennisService
    {
        public static int InsertPlayer(string name)
        {
            int id = 0;
            string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Players_Insert", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);

                    SqlParameter p = new SqlParameter("@Id", id);
                    p.Direction = ParameterDirection.Output;
                    command.Parameters.Add(p);

                    conn.Open();

                    command.ExecuteNonQuery();

                    int.TryParse(command.Parameters["@Id"].Value.ToString(), out id);
                }
            }

            return id;
        }

        public static int InsertMatch(PlayerMatchScore model)
        {
            int id = 0;
            string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("dbo.MatchScores_Insert", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Location", model.Location);
                    command.Parameters.AddWithValue("@Date", model.Date);
                    command.Parameters.AddWithValue("@WinnerId", model.WinnerId);
                    command.Parameters.AddWithValue("@Player1", model.Player1);
                    command.Parameters.AddWithValue("@P1Set1", model.P1Set1);
                    command.Parameters.AddWithValue("@P1Set2", model.P1Set2);
                    command.Parameters.AddWithValue("@P1Set3", model.P1Set3);
                    command.Parameters.AddWithValue("@Player2", model.Player2);
                    command.Parameters.AddWithValue("@P2Set1", model.P2Set1);
                    command.Parameters.AddWithValue("@P2Set2", model.P2Set2);
                    command.Parameters.AddWithValue("@P2Set3", model.P2Set3);

                    SqlParameter p = new SqlParameter("@MatchId", model.MatchId);
                    p.Direction = ParameterDirection.Output;
                    command.Parameters.Add(p);

                    conn.Open();

                    command.ExecuteNonQuery();

                    int.TryParse(command.Parameters["@MatchId"].Value.ToString(), out id);
                }
            }

            return id;
        }

        public static int UpdateMatch(PlayerMatchScore model)
        {
            string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("dbo.MatchScores_Update", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MatchId", model.MatchId);
                    command.Parameters.AddWithValue("@Location", model.Location);
                    command.Parameters.AddWithValue("@Date", model.Date);
                    command.Parameters.AddWithValue("@WinnerId", model.WinnerId);
                    command.Parameters.AddWithValue("@Player1", model.Player1);
                    command.Parameters.AddWithValue("@P1Set1", model.P1Set1);
                    command.Parameters.AddWithValue("@P1Set2", model.P1Set2);
                    command.Parameters.AddWithValue("@P1Set3", model.P1Set3);
                    command.Parameters.AddWithValue("@Player2", model.Player2);
                    command.Parameters.AddWithValue("@P2Set1", model.P2Set1);
                    command.Parameters.AddWithValue("@P2Set2", model.P2Set2);
                    command.Parameters.AddWithValue("@P2Set3", model.P2Set3);

                    conn.Open();

                    command.ExecuteNonQuery();
                }
            }

            return model.MatchId;
        }

        public static List<Match> GetMatches()
        {
            List<Match> matches = null;
            string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("dbo.MatchScores_SelectAll", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int startingIndex = 0;
                            Match match = new Match();

                            //reader.Read();

                            match.MatchId = reader.GetInt32(startingIndex++);
                            match.Player1 = reader.GetInt32(startingIndex++);
                            match.P1Name = reader.GetString(startingIndex++);
                            match.P1Set1 = reader.GetInt32(startingIndex++);
                            match.P1Set2 = reader.GetInt32(startingIndex++);
                            match.P1Set3 = reader.GetInt32(startingIndex++);
                            match.Player2 = reader.GetInt32(startingIndex++);
                            match.P2Name = reader.GetString(startingIndex++);
                            match.P2Set1 = reader.GetInt32(startingIndex++);
                            match.P2Set2 = reader.GetInt32(startingIndex++);
                            match.P2Set3 = reader.GetInt32(startingIndex++);
                            match.Date = reader.GetDateTime(startingIndex++);
                            match.Location = reader.GetString(startingIndex++);
                            match.WinnerId = reader.GetInt32(startingIndex++);

                            if(matches == null)
                            {
                                matches = new List<Match>();
                            }

                            matches.Add(match);
                        }
                    }
                }
            }
            return matches;
        }

        //public class DataSession : DbContext
        //{
        //    public DbSet<Players> Players { get; set; }
        //}

        //public static List<Players> GetPlayers()
        //{
        //    List<Players> players = new List<Players>();
        //    using (DataSession data = new DataSession())
        //    {
        //        Players player =
        //    }

        //    return players;
        //}

        public static List<Player> GetPlayers()
        {
            List<Player> players = null;
            string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Players_SelectAll", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int startingIndex = 0;
                            Player player = new Player();

                            //reader.Read();

                            player.Id = reader.GetInt32(startingIndex++);
                            player.Name = reader.GetString(startingIndex++);


                            if (players == null)
                            {
                                players = new List<Player>();
                            }

                            players.Add(player);
                        }
                    }
                }
            }
            return players;
        }

        public static int DeleteMatch(int id)
        {
            string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Matches_SoftDelete", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    conn.Open();

                    command.ExecuteNonQuery();
                }
            }

            return id;
        }
    }
}