//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-20
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : ComObjectRepository.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-20
//  Change History: 
// ==================================
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MES_application.Modules.CommunicationModule
{
    public class ComObjectRepository : IRepository<ComObject>
    {
        public List<ComObject> ComObjectList { get; set; }

        // singleton lazy learning 
        private static ComObjectRepository instance;

        public static ComObjectRepository Instance
        {
            get
            {
                if (instance == null) instance = new ComObjectRepository();
                return instance;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ComObjectRepository()
        {
            ComObjectList = new List<ComObject>();
        }

        public ComObject Retrieve(int p_id)
        {
            return ComObjectList[p_id];
        }

        public IEnumerable<ComObject> Retrieve()
        {
            return ComObjectList.ToList();
        }

        public void Add()
        {
        }
        public ComObject Add(ComObjectConfigure p_configure)
        {
            ComObject objTemp = new ComObject(p_configure);
            ComObjectList.Add(objTemp);
            return objTemp;
        }
        public void Delete(ComObject p_entity)
        {
            var item = ComObjectList.FindIndex(x => x.ObjectConfigure.Id == p_entity.ObjectConfigure.Id);
            ComObjectList.RemoveAt(item);
        }

        public void Delete(int p_id)
        {
            ComObjectList.RemoveAt(p_id);
        }
        public void DeleteAll(ComObject p_entity)
        {
            ComObjectList.Clear();
        }

        // edit na zaklade ID? nebo reference?
        public void Edit(ComObject p_entity)
        {

        }

        public bool Save(ComObject p_entity)
        {
            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}