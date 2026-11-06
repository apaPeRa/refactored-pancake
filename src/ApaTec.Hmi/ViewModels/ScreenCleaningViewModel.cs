using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-24 Bildschirm reinigen (Vollbild): Zeitfenster mit Fortschritt 0 bis 100 %, Eingabesperre (View), Schliessen nach Ablauf per <c>GoBack()</c>.
/// Dauer aus Parameter <c>durationSeconds</c>, sonst Einstellungen; ungueltig = Dummy-Dauer (S24-2). Ein Stoerungs-Alarm beendet die Reinigung (S24-4).
/// </summary>
[PageKey(PageKeys.ScreenCleaning)]
public sealed partial class ScreenCleaningViewModel : PageViewModelBase, IDisposable
{
    /// <summary>Die Seite scrollt selbst und fuellt den Inhaltsbereich (S-01).</summary>
    public override bool FillsContentArea => true;

    private const int TickMilliseconds = 250;

    private readonly ISettingsService _settings;
    private readonly INavigationService? _navigation;
    private readonly IMessageService? _messages;
    private readonly SynchronizationContext? _context = SynchronizationContext.Current;
    private Timer? _timer;
    private DateTime _start;
    private double _durationSeconds;
    private bool _finished;

    [ObservableProperty]
    private double _progress;

    public ScreenCleaningViewModel()
        : this(new DummySettingsService(), null, null)
    {
        Progress = ScreenCleaningDesignData.SampleProgress;
    }

    public ScreenCleaningViewModel(ISettingsService settings, INavigationService? navigation, IMessageService? messages)
    {
        _settings = settings;
        _navigation = navigation;
        _messages = messages;
    }

    public override void OnNavigatedTo(object? parameter)
    {
        _finished = false;
        Progress = 0;
        _durationSeconds = ResolveDuration(parameter);
        _start = DateTime.UtcNow;
        if (_messages is not null)
        {
            _messages.Changed += OnMessagesChanged;
        }

        _timer?.Dispose();
        _timer = new Timer(_ => Post(Tick), null, TickMilliseconds, TickMilliseconds);
    }

    public override void OnNavigatedFrom() => Stop();

    public void Dispose() => Stop();

    private double ResolveDuration(object? parameter)
    {
        var seconds = parameter is NavigationParameters p && p.Get<int>("durationSeconds") is var v and > 0 ? v : _settings.ScreenCleaningSeconds;
        return seconds is > 0 and <= ScreenCleaningDesignData.MaxSeconds ? seconds : ScreenCleaningDesignData.FallbackSeconds;
    }

    private void Tick()
    {
        if (_finished)
        {
            return;
        }

        Progress = Math.Min(100, (DateTime.UtcNow - _start).TotalSeconds / _durationSeconds * 100);
        if (Progress >= 100)
        {
            Finish();
        }
    }

    private void Finish()
    {
        if (_finished)
        {
            return;
        }

        _finished = true;
        Stop();
        _navigation?.GoBack();
    }

    private void Stop()
    {
        _timer?.Dispose();
        _timer = null;
        if (_messages is not null)
        {
            _messages.Changed -= OnMessagesChanged;
        }
    }

    private void OnMessagesChanged(object? sender, EventArgs e) =>
        Post(() =>
        {
            if (_messages?.Current is { Class: MessageClass.Fault })
            {
                Finish();
            }
        });

    private void Post(Action action)
    {
        if (_context is null)
        {
            action();
        }
        else
        {
            _context.Post(_ => action(), null);
        }
    }
}
