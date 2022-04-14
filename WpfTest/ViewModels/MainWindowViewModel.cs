using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfTest.Models;
using WpfTest.Services;

namespace WpfTest.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly StockdataClient _stockdataClient;
        

        public MainWindowViewModel(StockdataClient stockdataClient)
        {
            _stockdataClient = stockdataClient;
        }


        #region Title : string - Text of title MainWindow

        /// <summary>Text of title MainWindow</summary>
        private string _Title = "Заголовок";

        /// <summary>Text of title MainWindow</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion


        #region ListOfStocks : ObservableCollection<ProfitOfTikers> - Text of title MainWindow

        /// <summary>Text of title MainWindow</summary>
        private ObservableCollection<ProfitOfTikers> _ListOfStocks = new ObservableCollection<ProfitOfTikers>();

        /// <summary>Text of title MainWindow</summary>
        public ObservableCollection<ProfitOfTikers> ListOfStocks
        {
            get => _ListOfStocks;
            set => Set(ref _ListOfStocks, value);
        }

        #endregion


        #region TickersValues : string - Text of Tickers input field

        /// <summary>Text of Tickers input field</summary>
        private string _TickersValues;

        /// <summary>Text of Tickers input field</summary>
        public string TickersValues
        {
            get => _TickersValues;
            set => Set(ref _TickersValues, value);
        }

        #endregion

        #region SelectedTickerValue : ProfitOfTikers - Selected ProfitOfTikers in listOfStocks

        /// <summary>Selected ProfitOfTikers in listOfStocks</summary>
        private ProfitOfTikers _SelectedTickerValue;

        /// <summary>Selected ProfitOfTikers in listOfStocks</summary>
        public ProfitOfTikers SelectedTickerValue
        {
            get => _SelectedTickerValue;
            set => Set(ref _SelectedTickerValue, value);
        }

        #endregion



        #region Command LoadInfoFromApi - loading some info from api

        /// <summary>loading some info from api</summary>
        private ICommand _LoadInfoFromApi;

        

        /// <summary>loading some info from api</summary>
        public ICommand LoadInfoFromApi => _LoadInfoFromApi
            ??= new LambdaCommandAsync(OnLoadInfoFromApiExequted, CanLoadInfoFromApiExequt);

        /// <summary>Checking the possibility of execution - loading some info from api</summary>
        public bool CanLoadInfoFromApiExequt(object p) => true;

        /// <summary>Execution logic - loading some info from api</summary>
        public async Task OnLoadInfoFromApiExequted(object p)
        {
            var resultApi = await _stockdataClient.GetStockData(TickersValues, ConfigApp.Token);
            
            foreach(var item in resultApi.Data)
            {
                ListOfStocks.Add(new()
                {
                    CompanyName = item.Name,
                    MinCost = item.DayLow,
                    MaxCost = item.DayHigh
                });

                ListOfStocks.OrderBy(p => p.Profit);
            }

            MessageBox.Show($"Загружено информации о {resultApi.Meta.Returned} компаниях");

            TickersValues = "";

        }

        #endregion
    }
}
