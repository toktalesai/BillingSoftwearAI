using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace TVTRON_Bills
{
    public partial class MainForm : BaseForm
    {
        private WebView2 webView;

        public MainForm()
        {
            InitializeComponents();
            this.Text = "TVTron Bills organization faced";
            this.WindowState = FormWindowState.Maximized;
            this.Load += MainForm_Load;
            this.Load += MainForm_Load;

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var env = await CoreWebView2Environment.CreateAsync();
            await webView.EnsureCoreWebView2Async(env);

            // Option A: Load local file (index.html) from app folder
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string indexPath = Path.Combine(appPath, "wwwroot", "Bills_New.html");
            if (File.Exists(indexPath))
            {
                webView.Source = new Uri(indexPath);
                return;
            }
             //Add the below code for the opposite site developement
              webView.CoreWebView2.Navigate("https://google.com");
            // Option B: fallback to a remote URL if provided
            webView.CoreWebView2.Navigate("https://example.com");
        }

        private void InitializeComponents()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Dock
            };
            this.Controls.Add(webView);
        }
    }
}


