using MES_2.DB.Tables;

namespace MES_2.DB.Database
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MES_DATABASE : DbContext
    {
        // Your context has been configured to use a 'MES_DATABASE' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MES_2.DB.Database.MES_DATABASE' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MES_DATABASE' 
        // connection string in the application configuration file.
        public MES_DATABASE()
            : base("name=MES_DATABASE")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<USR_UserList> USR_UserList { get; set; }
        public virtual DbSet<ENT_Entity> ENT_Entity { get; set; }
        public virtual DbSet<STA_StateList> STA_StateList { get; set; }
        public virtual DbSet<TRA_TranslationState> TRA_TranslationState { get; set; }
        //public virtual DbSet<TRA_TranslationStateList> TRA_TranslationStateList { get; set; }
        public virtual DbSet<COM_ComObject> ComObjecTable { get; set; }
        public virtual DbSet<PLC_PLCConnector> PLC_PLCConnectorable { get; set; }
        public virtual DbSet<RES_ResultTable> RES_ResultTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TRA_TranslationState>()
                        .HasRequired(m => m.STATE_FROM)
                        .WithMany(t => t.TRA_FROM)
                        .HasForeignKey(m => m.ID_STA_PICA_FROM)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRA_TranslationState>()
                        .HasRequired(m => m.STATE_TO)
                        .WithMany(t => t.TRA_TO)
                        .HasForeignKey(m => m.ID_STA_PICA_TO)
                        .WillCascadeOnDelete(false);
        }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}