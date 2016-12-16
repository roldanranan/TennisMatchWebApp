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
            _getPlayers = null;
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
            _getAllMatches = null;
            return id;
        }

        public static PlayerMatchScore UpdateMatch(PlayerMatchScore model)
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
            _getAllMatches = null;
            return model;
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
                            match.Date.ToString("MM/dd/yy");
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
        

        public static List<Player> GetAllPlayers()
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
            _getAllMatches = null;
            return id;
        }

        private static List<Player> _getPlayers;

        public static List<Player> GetPlayers
        {
            get
            {
                if (_getPlayers == null)
                {
                    List<Player> allPlayers = GetAllPlayers();
                    _getPlayers = new List<Player>();
                    foreach (Player p in allPlayers)
                    {
                        _getPlayers.Add(p);
                    }
                }
                return _getPlayers;
            }
        }

        private static List<Match> _getAllMatches;

        public static List<Match> GetAllMatches
        {
            get
            {
                if(_getAllMatches == null)
                {
                    List<Match> allMatches = GetMatches();
                    _getAllMatches = new List<Match>();
                    foreach(Match match in allMatches)
                    {
                        _getAllMatches.Add(match);
                    }
                }
                return _getAllMatches;
            }
        }
    

        public static IEnumerable<Match> SearchMatches(Search search)
        {
            List<Match> allMatches = _getAllMatches;

            var matches = from match in allMatches
                          where (match.P1Name == search.Name || match.P2Name == search.Name || search.Name == null)
                          && (match.Location == search.Location || search.Location == null)
                          && (match.Date == search.Date || search.Date == null)
                          select match;



            return matches;
        }

        public static IEnumerable<string> PlayerSearchBar()
        {
            List<Match> matches = _getAllMatches;
            List<Player> players = _getPlayers;
            var match = matches.Select(m => new[] { m.P1Name, m.P2Name }).SelectMany(i => i).ToList();
            var group = from m in match
                        orderby m
                        group m by m into g
                        select g.Key;
            return group;
        }

        public static IEnumerable<string> LocationSearchBar()
        {
            List<Match> all = _getAllMatches;
            var location = from s in all
                            orderby s.Location
                            group s by s.Location into g
                            select g.Key;
            return location;
        }

        public static IEnumerable<DateTime> DateSearchBar()
        {
            List<Match> all = _getAllMatches;
            var date = from d in all
                           orderby d.Date
                           group d by d.Date into g
                           select g.Key;
            return date;
        }
    }
}