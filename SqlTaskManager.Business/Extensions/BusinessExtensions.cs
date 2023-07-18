using PetaPoco.Providers;
using PetaPoco;
namespace SqlTaskManager.Business.Extensions {
    public abstract class BusinessExtensions {
        public required string SettingsIniFile;
        public BusinessExtensions(string settingsIniFile) {
            SettingsIniFile = settingsIniFile;
        }
        /// <summary>
        /// Get Db
        /// </summary>
        /// <returns></returns>
        public IDatabase GetDb() {
            var connectionString = IniFileHelper.ReadIni(SettingsIniFile, "Settings", "ConnectionString", "");
            return DatabaseConfiguration.Build()
                .WithoutAutoSelect()
                .UsingProvider<SqlServerDatabaseProvider>()
                .UsingConnectionString(connectionString)
                .Create();
        }
    }
}