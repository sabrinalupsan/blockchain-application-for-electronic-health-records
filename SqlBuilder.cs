using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace BlockchainApp {

    public sealed class MySqlBuilder {

        private SqlConnectionStringBuilder Builder;
        public SqlConnectionStringBuilder builder { get { return Builder; } set { } }

        private static MySqlBuilder Instance;

        public static MySqlBuilder instance {
            get {
                if (Instance == null)
                    Instance = new MySqlBuilder();
                return Instance;
            }
        }

        private MySqlBuilder() {
            try
            {
                Builder = new SqlConnectionStringBuilder();
                builder.DataSource = "blockchainapp.database.windows.net";
                builder.UserID = "lupsansabrina18";
                #region hide
                builder.Password = "e#WLQgz/E2UP=8_s";
                #endregion hide
                builder.InitialCatalog = "blockchainapp";
            }
            catch (System.NullReferenceException)
            {
                
            }
        }
    }
}
