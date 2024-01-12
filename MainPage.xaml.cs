using Microsoft.Maui.Controls.Shapes;

namespace katyBadowski4c;

public partial class MainPage : ContentPage
{
	List<int> katy = new List<int>();
    Random rand = new Random();
    int sek = 6;
    int pom = 1;
    int min = 0;
    bool on = false;
    bool ponadMin = false;
    public MainPage()
	{
		int kat = 0;
		InitializeComponent();
		while(kat <= 360)
		{
			katy.Add(kat);
			kat += 45;
		}

	}

    private void timer()
	{
        on = true;
        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (sender, e) => obrot(sender, e);
        timer.Start();
    }

	private void obrot(object sender, EventArgs e)
	{
        /*int temp = (int)rand.Next(0, katy.Count);
        kreciolek.RotateTo(katy[temp]);*/
        kreciolek.RotateTo(sek);
        sek += 6;
        if(pom < 60)
        {
            if(!ponadMin)
            {
                label.Text = pom.ToString();
                pom++;
            } else if(pom < 10)
            {
                label.Text = min.ToString() + ":0" + pom.ToString();
                pom++;
            } else
            {
                label.Text = min.ToString() + ":" + pom.ToString();
                pom++;
            }
        } else
        {
            if(pom == 60)
            {
                min++;
                pom = 0;
            }
            ponadMin = true;
            label.Text = min.ToString() + ":0" + pom.ToString();
        }
        if (on)
        {
            return;
        }
        else
        {
            timer();
        }
        przycisk.IsEnabled = false;
    }
}

