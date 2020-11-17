﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainApp
{
    public sealed class MySqlBuilder
    {
        private SqlConnectionStringBuilder Builder;
        public SqlConnectionStringBuilder builder { get { return Builder; } }
        private static MySqlBuilder Instance;
        public static MySqlBuilder instance {
            get
            {
                if (Instance == null)
                    Instance = new MySqlBuilder();
                return Instance;
            } }

        private MySqlBuilder()
        {
            //Instance = new MySqlBuilder();
            Builder = new SqlConnectionStringBuilder();
            builder.DataSource = "blockchainapp.database.windows.net";
            builder.UserID = "lupsansabrina18";
            builder.Password = "Selenacolierul9!";
            builder.InitialCatalog = "blockchainapp";
        }


    }
}