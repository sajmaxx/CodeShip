﻿using Newtonsoft.Json;
using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Core.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace StockAnalyzer.Windows
{
    public partial class MainWindow : Window
    {
        private static string API_URL = "https://ps-async.fekberg.com/api/stocks";
        private Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }



        CancellationTokenSource cancellationTokenSource;




        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BeforeLoadingStockData();

                var data = await SearchForStocks();

                Stocks.ItemsSource = data.Where(price => 
                                price.Identifier == StockIdentifier.Text);

            }
            catch(Exception ex)
            {
                Notes.Text = ex.Message;
            }
            finally
            {
                AfterLoadingStockData();
            }
        }

        private static Task<IEnumerable<StockPrice>> SearchForStocks()
        {
            var tcs = new TaskCompletionSource<IEnumerable<StockPrice>>();

            ThreadPool.QueueUserWorkItem(_ => {
                var lines = File.ReadAllLines("StockPrices_Small.csv");

                var prices = new List<StockPrice>();

                foreach (var line in lines.Skip(1))
                {
                    prices.Add(StockPrice.FromCSV(line));
                }

                tcs.SetResult(prices);
            });

            return tcs.Task;
        }














        private async Task 
            SearchForStocks(IProgress<IEnumerable<StockPrice>> progress)
        {
            var service = new StockService();
            var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();

            foreach(var identifier in StockIdentifier.Text.Split(' ', ','))
            {
                var loadTask = service.GetStockPricesFor(identifier,
                    CancellationToken.None);

                loadTask = loadTask.ContinueWith(completedTask =>
                {
                    progress?.Report(completedTask.Result);

                    return completedTask.Result;
                });

                loadingTasks.Add(loadTask);
            }

            var data = await Task.WhenAll(loadingTasks);

            Stocks.ItemsSource = data.SelectMany(stock => stock);

        }





        private static Task<List<string>> 
            SearchForStocks(CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                using (var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv")))
                {
                    var lines = new List<string>();

                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if(cancellationToken.IsCancellationRequested)
                        {
                            break;
                        }

                        lines.Add(line);
                    }

                    return lines;
                }
            }, cancellationToken);
        }

        private async Task<IEnumerable<StockPrice>>
            GetStocksFor(string identifier)
        {
            var service = new StockService();
            var data = await service.GetStockPricesFor(identifier,
                CancellationToken.None).ConfigureAwait(false);

            

            return data.Take(5);
        }

        private async Task GetStocks()
        {
            try
            {
                var store = new DataStore();

                var responseTask = store.GetStockPrices(StockIdentifier.Text);

                Stocks.ItemsSource = await responseTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


















        private void BeforeLoadingStockData()
        {
            stopwatch.Restart();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = false;
            StockProgress.Value = 0;
            StockProgress.Maximum = StockIdentifier.Text.Split(' ', ',').Length;
        }

        private void AfterLoadingStockData()
        {
            StocksStatus.Text = $"Loaded stocks for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
