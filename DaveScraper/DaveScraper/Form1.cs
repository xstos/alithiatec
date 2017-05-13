using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaveScraper
{
    public partial class Form1 : Form
    {
        WebBrowser browser = new WebBrowser();
        List<OHLC> results = new List<OHLC>();
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            
        }

        IEnumerable<OHLC> GetDateSequence()
        {
            foreach (var symbol in textBox1.Lines)
            {
                foreach (var date in GetWorkingDaysBetween(startDatePicker.Value, endDatePicker.Value))
                {
                    yield return new OHLC() { symbol = symbol, date = date };
                }
            }
            yield break;
        }
        private void button1_Click(object sender1, EventArgs ee)
        {
            results.Clear();
            textBox3.Clear();
            browser.AllowNavigation = true;
            var dateEnumerator = GetDateSequence().GetEnumerator();
            if (!dateEnumerator.MoveNext()) return;
            Action navigate = () =>
            {
                var url = createUrl(dateEnumerator.Current.symbol, dateEnumerator.Current.date);
                
                browser.Navigate(url);
                
            };
            browser.DocumentCompleted += (sender, e) =>
            {
                if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                {
                    return; //see http://stackoverflow.com/questions/2777878/detect-webbrowser-complete-page-loading
                }
                var data = GetTableDataFromDocument(browser.Document, dateEnumerator.Current);
                results.Add(data);
                textBox3.AppendText(data.ToTabDelimitedString()+Environment.NewLine);
                if (dateEnumerator.MoveNext())
                {
                    navigate();
                }
                else
                {
                    saveResults();
                }
            };
            navigate();
        }

        void saveResults()
        {
            File.WriteAllLines(savePathTextBox.Text, results.Select(item => item.ToTabDelimitedString()));
            Process.Start(savePathTextBox.Text);

        }
        static DateTime OffsetBackwardsTo(DateTime date, DayOfWeek day)
        {
            while (date.DayOfWeek > day) //sloppy but it's easier than doing the math
            {
                date = date.AddDays(-1);
            }
            return date;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            savePathTextBox.Text = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"output.txt");
            browser.ScriptErrorsSuppressed = true;
            var lastSat = OffsetBackwardsTo(DateTime.Now, DayOfWeek.Saturday);
            startDatePicker.Value = OffsetBackwardsTo(lastSat, DayOfWeek.Monday);
            endDatePicker.Value = startDatePicker.Value.AddDays(4);
        }

        struct OHLC
        {
            public DateTime date { get; set; }
            public string symbol { get; set; }
            public string open { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string close { get; set; }
            public string ToTabDelimitedString()
            {
                return string.Join("\t", new[] {date.ToShortDateString(), symbol, open, high, low, close});
            }
        }

        static OHLC GetTableDataFromDocument(HtmlDocument document,OHLC fillme)
        {
            var tbl = document.GetElementById("historicalquote");
            if (tbl==null) return fillme;
            dynamic myTable = tbl.DomElement;
            fillme.close = myTable.rows[2].cells[1].innerText;
            fillme.open = myTable.rows[3].cells[1].innerText;
            fillme.high = myTable.rows[4].cells[1].innerText;
            fillme.low = myTable.rows[5].cells[1].innerText;
            return fillme;
        }
        static IEnumerable<DateTime> GetWorkingDaysBetween(DateTime start, DateTime end)
        {
            while (start.Date <= end.Date)
            {
                if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
                {
                    start = start.AddDays(1);
                    continue;
                }
                yield return start.Date;
                start = start.AddDays(1);
            }
        }

        static string createUrl(string symbol, DateTime date)
        {
            var month = date.Month;
            var day = date.Day;
            var year = Microsoft.VisualBasic.Strings.Right(date.Year.ToString(),2);
            return $"http://bigcharts.marketwatch.com/historical/default.asp?symb={symbol}&closeDate={month}%2F{day}%2F{year}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this)==DialogResult.OK)
            {
                savePathTextBox.Text = saveFileDialog1.FileName;
            }
        }

        
    }
}
