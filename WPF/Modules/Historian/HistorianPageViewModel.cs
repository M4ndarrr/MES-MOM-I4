using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using AutoMapper;
using MES_2.DB.Tables;
using MES_2.Modules.ComModule;
using MES_2.Modules.PLCConnectorModule;
using MES_2.Modules.SystemModule.State;
using MoreLinq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using WPF.Helpers;
using WPF.Modules.Interfaces;
using ViewModelBase = WPF.Modules.Base.ViewModelBase;

namespace WPF.Modules.Historian
{
    public class HistorianPageViewModel : ViewModelBase
    {
        public HistorianPageViewModel()
        {
// GetHistorianCommand = new RelayCommand(OnGetHistorian);
            PLCConnectors =
                new ObservableCollection<PLCConnectorModel>(
                    PlcConnectorModuleRepository.Instance.RetrieveModel().ToList());
        }

        private ObservableCollection<PLCConnectorModel> _PLCConnectors;

        public ObservableCollection<PLCConnectorModel> PLCConnectors
        {
            get { return _PLCConnectors; }
            set { SetProperty(ref _PLCConnectors, value); }
        }

        private PLCConnectorModel _PLCConnector;

        public PLCConnectorModel PLCConnector
        {
            get { return _PLCConnector; }
            set
            {
                SetProperty(ref _PLCConnector, value);

                if (value != null && value.ID_PLC.ToString() != string.Empty)
                {
                    // ComObjects.RemoveAll();
                    var temp = PlcConnectorModuleRepository.Instance.RetrieveDetailModel(PLCConnector.ID_PLC);
                    ComObjects =
                        new ObservableCollection<ComObjectModel>(temp.COM_ComObject.Select(Mapper.Map<ComObjectModel>));
                }
            }
        }

        private ObservableCollection<ComObjectModel> _ComObjects;

        public ObservableCollection<ComObjectModel> ComObjects
        {
            get { return _ComObjects; }
            set { SetProperty(ref _ComObjects, value); }
        }

        private ComObjectModel _ComObject;

        public ComObjectModel ComObject
        {
            get { return _ComObject; }
            set
            {
                SetProperty(ref _ComObject, value);
                if (value != null && value.ID_COM.ToString() != string.Empty)
                {
                    // ReceivedResults.RemoveAll();
                    var temp = ComObjectRepository.Instance.RetrieveDetailModel(ComObject.ID_COM);
                    ReceivedResults =
                        new ObservableCollection<ReceivedResult>(
                            temp.RES_ResultTable.Select(Mapper.Map<ReceivedResult>));
                }
            }
        }


        private ObservableCollection<ReceivedResult> _receivedResults;

        public ObservableCollection<ReceivedResult> ReceivedResults
        {
            get { return _receivedResults; }
            set
            {
                SetProperty(ref _receivedResults, value);

                if (value != null && value.Count != 0)
                {
                    PeriodStart = ReceivedResults.Min(x => x.PLCStamp);
                    PeriodEnd = ReceivedResults.Max(x => x.PLCStamp);

                    VisiblePeriodStart = ReceivedResults.Min(x => x.PLCStamp);
                    VisiblePeriodEnd = ReceivedResults.Max(x => x.PLCStamp);
                }
            }
        }

        private ObservableCollection<ReceivedResult> _receivedResultsDetail;

        public ObservableCollection<ReceivedResult> ReceivedResultsDetail
        {
            get { return _receivedResultsDetail; }
            set { SetProperty(ref _receivedResultsDetail, value); }
        }


        private DateTime _periodStar;

        public DateTime PeriodStart
        {
            get { return _periodStar; }
            set { SetProperty(ref _periodStar, value); }
        }

        private DateTime _periodEnd;

        public DateTime PeriodEnd
        {
            get { return _periodEnd; }
            set { SetProperty(ref _periodEnd, value); }
        }

        private DateTime _visiblePeriodStart;

        public DateTime VisiblePeriodStart
        {
            get { return _visiblePeriodStart; }
            set { SetProperty(ref _visiblePeriodStart, value); }
        }

        private DateTime _visiblePeriodEnd;

        public DateTime VisiblePeriodEnd
        {
            get { return _visiblePeriodEnd; }
            set { SetProperty(ref _visiblePeriodEnd, value); }
        }

        private DateTime _selectionStar;

        public DateTime SelectionStart
        {
            get { return _selectionStar; }
            set
            {
                SetProperty(ref _selectionStar, value);
                if (value != null)
                {
                    ReceivedResultsDetail =
                        new ObservableCollection<ReceivedResult>(
                            ReceivedResults.Where(x => x.PLCStamp > SelectionStart && x.PLCStamp < SelectionEnd));
                }
            }
        }

        private DateTime _selectionEnd;

        public DateTime SelectionEnd
        {
            get { return _selectionEnd; }
            set
            {
                SetProperty(ref _selectionEnd, value);
                if (value != null)
                {
                    ReceivedResultsDetail =
                        new ObservableCollection<ReceivedResult>(
                            ReceivedResults.Where(x => x.PLCStamp > SelectionStart && x.PLCStamp < SelectionEnd));
                }
            }
        }
    }
}
    