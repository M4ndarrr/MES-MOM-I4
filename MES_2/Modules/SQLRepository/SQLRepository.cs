//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-26
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : SQLRepository.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-26
//  Change History: 
// ==================================
using System.Collections.Generic;
using System.Threading;
using MES_2.Database;
using MES_application.Modules.CommunicationModule;

namespace MES_application.Modules.SQLRepository
{
    public class SQLRepository
    {
        private Thread t;
        private const string _VERSION = "0.0.1"; // verze modulů
        private static readonly object Lock = new object();

        public List<ResultTable> ListReceivedResult { get; set; }


        private static SQLRepository instance;

        public static SQLRepository Instance
        {
            get
            {
                if (instance == null) instance = new SQLRepository();
                return instance;
            }
        }

        // .Show<int>("Integer", 246); - da se napsat jakakoliv 
        // musí se zadávat hodnoty do tabulky kterou zrovna chci 
        // sql třída pouze pro 
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SQLRepository()
        {
            ListReceivedResult = new List<ResultTable>();
            t = new Thread(StateDiagram);
            t.Name = "SQL thread";
            t.Start();
        }

        public void Run()
        {
            
        }

        public void Stop()
        {
            
        }
        


        public void StateDiagram()
        {
            while(true) { 
            lock (Lock)
            {
                using (var db = new TestDatabaseEntities())
                {
                    db.ResultTable.AddRange(ListReceivedResult);
                    db.SaveChanges();
                }
                ListReceivedResult.Clear();
            }

            Thread.Sleep(5000);
            }
        }


        // list 
    }


// public void InsertToDatabase<TypeTable>(TypeTable Table)

// {

// DbSet<TypeTable> TypeTable { get; set; }


    // using (var db = new TestDatabaseEntities())
    // {
    // db.Table1.Add(new Table1
    // {
    // ComDevice = tempComObj.ObjectConfigure.Id,
    // Value = temp.Data
    // });
    // db.SaveChanges();
    // }
    // }
}