using CyberManager.Application.Services;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private readonly IGreeting _greeting;
        public Form1(IGreeting greeting)
        {
            InitializeComponent();
            _greeting = greeting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = _greeting.Greet();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = _greeting.Greet();
        }
    }
}
