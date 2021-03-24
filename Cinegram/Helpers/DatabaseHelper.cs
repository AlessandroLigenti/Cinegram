using Cinegram.Models.Entity;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cinegram.Helpers
{
    public class DatabaseHelper
    {
        private static string _connectionString;

        public static void InitConnectionString()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbCinegram"].ConnectionString;
        }

        public static List<Film> GetAllFilm()
        {
            var film = new List<Film>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM film";

                film = connection.Query<Film>(sql).ToList();
            }

            return film;
        }

        public static Film GetFilmById(int id)
        {
            var film = new Film();
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM film WHERE id = @id";
                film = connection.Query<Film>(sql, new { id }).FirstOrDefault();
            }
            return film;
        }
        public static bool ExistsUtenteByEmail(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT id FROM utente WHERE email = @email and password <>''";
                var id = connection.Query<int>(sql, new { email }).FirstOrDefault();
                return id > 0;
            }
        }

        public static int InsertUtente(Utente utente)
        {
            var id = 0;
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = "INSERT INTO utente (nome, email, password, isprivacy) " +
                        "VALUES (@nome,@email,@password,1); " +
                        "SELECT LAST_INSERT_ID()";
                    id = connection.Query<int>(sql, utente).First();
                }
            }
            catch (Exception ex)
            {
                //TODO qui bisognerebbe loggare l'errore ex.Message
            }
            return id;
        }

        public static bool UpdatePassword(int id, string password)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var sql = "UPDATE utente SET password = @password WHERE id = @id";
                    connection.Query(sql, new { id, password });
                }
            }
            catch (Exception ex)
            {
                //TODO qui bisognerebbe loggare l'errore ex.Message
                return false;
            }
            return true;
        }

        public static Utente GetUtenteByEmail(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM utente WHERE email = @email and password <>''";
                return connection.Query<Utente>(sql, new { email }).FirstOrDefault();
            }
        }
    }
}