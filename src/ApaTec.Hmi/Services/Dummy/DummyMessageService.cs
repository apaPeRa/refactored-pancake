using System.Timers;
using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Beispielmeldung 014 (Hinweis) mit zwei weiteren und drei neuen Meldungen; Hinweistexte (A-28) verfallen nach fuenf Sekunden.</summary>
[DummyService]
public sealed class DummyMessageService : IMessageService, IDisposable
{
    private const double HintDurationMs = 5000;

    private readonly object _gate = new();
    private readonly System.Timers.Timer _hintTimer = new(HintDurationMs) { AutoReset = false };
    private readonly MessageInfo _message = new(ShellDesignData.MessageNumber, ShellDesignData.MessageText, ShellDesignData.MessageClass);
    private MessageInfo? _hint;

    public DummyMessageService()
    {
        _hintTimer.Elapsed += OnHintElapsed;
    }

    public MessageInfo? Current
    {
        get
        {
            lock (_gate)
            {
                return _hint ?? _message;
            }
        }
    }

    public int AdditionalCount => ShellDesignData.AdditionalMessageCount;

    public int UnreadCount => ShellDesignData.UnreadMessageCount;

    public event EventHandler? Changed;

    public void ShowHint(string text)
    {
        lock (_gate)
        {
            _hint = new MessageInfo(null, text, MessageClass.Notice);
            _hintTimer.Stop();
            _hintTimer.Start();
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        _hintTimer.Elapsed -= OnHintElapsed;
        _hintTimer.Dispose();
    }

    private void OnHintElapsed(object? sender, ElapsedEventArgs e)
    {
        lock (_gate)
        {
            _hint = null;
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }
}
