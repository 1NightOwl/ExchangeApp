namespace ExchangeApp
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> _ratesCache;

        //List<string> list = new List<string>();



        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 1) Fetch the currency data (name, code, rate).
                var currencyData = await ExchangeHelper.GetExchangeRatesAsync();

                // 2) Set up the columns (Name, Code, Rate) in the ListView.
                listView1.Clear(); // clears items + columns
                listView1.Columns.Add("Currency Name", 150);
                listView1.Columns.Add("Code", 60);
                listView1.Columns.Add("Rate", 80);

                // 3) Populate rows.
                foreach (var info in currencyData)
                {
                    // Example row: "Dollar Amerikan" | "USD" | "95.33"
                    var row = new ListViewItem(info.Name);
                    row.SubItems.Add(info.Code);
                    row.SubItems.Add(info.Rate.ToString());

                    listView1.Items.Add(row);
                }

                // (Optional) auto-size columns to fit content
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        //private void PopulateListView(Dictionary<string, double> rates)
        //{
        //    // Clear any existing items/columns:
        //    listView1.Items.Clear();
        //    listView1.Columns.Clear();

        //    // Define columns
        //    listView1.Columns.Add("Currency", 100); // 100 is the column width
        //    listView1.Columns.Add("Rate", 100);

        //    // Add each currency code and rate
        //    foreach (var kvp in rates)
        //    {
        //        // kvp.Key = currency code, kvp.Value = rate
        //        var item = new ListViewItem(kvp.Key);
        //        item.SubItems.Add(kvp.Value.ToString());
        //        listView1.Items.Add(item);
        //    }

        //    // (Optional) Auto-resize columns to fit content
        //    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //}



    }
}
