using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;


        public AdatbazisKezelo()
        {

            this.connectionString = "server=localhost;user=root;database=jatekdb;password=";// Irjuk meg a connectionstringet a megfelelő adatbázisra hivatkozva
        }

   
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
       
        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();

            using(MySqlConnection kapcsolcsolat = new MySqlConnection(connectionString))
            {
                kapcsolcsolat.Open();
                string sql = "SELECT * FROM karakterek";
                using (MySqlCommand parancs = new MySqlCommand(sql, kapcsolcsolat))
                {
                    using (MySqlDataReader olvaso = parancs.ExecuteReader())
                    {
                        while (olvaso.Read())
                        {
                            Karakter karakter = new Karakter(
                                olvaso.GetInt32("Id"),
                                olvaso.GetString("Nev"),
                                olvaso.GetString("Osztaly"),
                                olvaso.GetInt32("Szint"),
                                olvaso.GetInt32("Arany"),
                                olvaso.GetString("Szerver")
                            );

                            karakterek.Add(karakter);
                        }
                    }
                }
            }
            return karakterek;
        }
    }
}
