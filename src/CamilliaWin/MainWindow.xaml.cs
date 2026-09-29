using Camillia.Core;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Windows.Graphics;
using Windows.System;

namespace CamilliaWin;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        AppWindow.Resize(new SizeInt32(640, 400));

        var info = CamilliaCoreMethods.CoreInfo();
        CoreInfoText.Text = $"Linked {info.Name} v{info.Version}";
    }

    private void Greet_Click(object sender, RoutedEventArgs e) => RunGreet();

    private void NameBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Enter)
        {
            RunGreet();
        }
    }

    private void RunGreet()
    {
        try
        {
            ResultText.Text = CamilliaCoreMethods.Greet(NameBox.Text);
        }
        catch (CoreException.InvalidInput ex)
        {
            ResultText.Text = $"Error: {ex.reason}";
        }
    }
}
