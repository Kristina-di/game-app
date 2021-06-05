using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public sealed partial class ShowAllGames : Page
    {
        public ShowAllGames()
        {
            this.InitializeComponent();
            AllGames();
        }

        static string GetConnectionString(string _connectionStringName)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration config = configurationBuilder.Build();
            return config["ConnectionStrings:" + _connectionStringName];
        }

        public void AllGames()
        {
            string cs = GetConnectionString("GamesInfo");
            string query = "SELECT Name, Icon, Developer, DevIcon, GameBlurb " +
                "FROM  dbo.Games";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    string name = (string)reader["Name"];
                    string icon = (string)reader["Icon"];
                    string developer = (string)reader["Developer"];
                    string devicon = (string)reader["DevIcon"];
                    string gameblurb = (string)reader["GameBlurb"];

                    ListG.Items.Add(name);
                    ListG.Items.Add(icon);
                    ListG.Items.Add(developer);
                    ListG.Items.Add(devicon);
                    ListG.Items.Add(gameblurb);



                }

            }
        }
    }
}
