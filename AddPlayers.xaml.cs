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
    public sealed partial class AddPlayers : Page
    {
        public AddPlayers()
        {
            this.InitializeComponent();
        }
        static string GetConnectionString(string _connectionStringName)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration config = configurationBuilder.Build();
            return config["ConnectionStrings:" + _connectionStringName];
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cs = GetConnectionString("GamesInfo");
            string query = "INSERT INTO dbo.Players (Nickname, Name, Surname) values (@Nickname, @Name, @Surname)";
            string _nickname = text1.Text;
            string _name = text2.Text;
            string _surname = text3.Text;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Nickname", _nickname);
                cmd.Parameters.AddWithValue("Name", _name);
                cmd.Parameters.AddWithValue("Surname", _surname);
                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                {
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
