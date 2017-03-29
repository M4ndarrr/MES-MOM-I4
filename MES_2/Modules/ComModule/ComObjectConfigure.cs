//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-22
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : ComObjectConfigure.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-22
//  Change History: 
// ==================================
namespace MES_2.Modules.ComModule
{
    public class ComObjectConfigure
    {
        public enum ETypeComObject
        {
            Read,
            Write,
            ReadWrite
        }

        //public string Id { get; set; } = Utils.Utils.generateID();
        public int AreaOfMemory { get; set; }
        public int WorldLen { get; set; }
        public int StartOffset { get; set; }
        public int PeriodOfCheck { get; set; }
        public int DbNumber { get; set; }
        public ETypeComObject _ERW;

        public int ERW
        {
            get { return (int) _ERW; }
            set { GetTypeObject(value); }
        }

        private void GetTypeObject(int p_RW)
        {
            switch (p_RW)
            {
                case (int) ETypeComObject.Read:
                {
                    _ERW = ETypeComObject.Read;
                    break;
                }

                case (int) ETypeComObject.Write:
                    _ERW = ETypeComObject.Write;
                    break;
                case (int) ETypeComObject.ReadWrite:
                    _ERW = ETypeComObject.ReadWrite;
                    break;
                default:
                    _ERW = ETypeComObject.Read;
                    break;
            }
        }
    }
}