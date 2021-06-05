using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalAssignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowAllPlayersPlay : Page
    {
        public ShowAllPlayersPlay()
        {
            this.InitializeComponent();
            AllPlayersPlay();
        }
        static string GetConnectionString(string _connectionStringName)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration config = configurationBuilder.Build();
            return config["ConnectionStrings:" + _connectionStringName];
        }

        public void AllPlayersPlay()
        {
            string cs = GetConnectionString("GamesInfo");
            string query = "SELECT Nickname, Icon, Games.Name " +
                "FROM  dbo.Players JOIN dbo.GamePlayers ON Players.Id = GamePlayers.PlayerId JOIN dbo.Games ON Games.Id = GamePlayers.GameId";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nickname = (string)reader["Nickname"];
                    string icon = (string)reader["Icon"];
                    string name = (string)reader["Name"];


                    ListPP.Items.Add(nickname);
                    ListPP.Items.Add(icon);
                    ListPP.Items.Add(name);





                }
            }
        }
    }
}
