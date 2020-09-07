using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace AudioPlayer2020.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        private double _currentTrackLenght;
        private double _currentTrackPosition;
        private string _playPauseImageSource;
        private float _currentVolume;

        private ObservableCollection<Track> _playlist;
        private Track _currentlyPlayingTrack;
        private Track _currentlySelectedTrack;
        //private AudioPlayer _audioPlayer;


            public string Title
    {
        get { return _title; }
        set
        {
            if (value == _title) return;
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public string PlayPauseImageSource
    {
        get { return _playPauseImageSource; }
        set
        {
            if (value == _playPauseImageSource) return;
            _playPauseImageSource = value;
            OnPropertyChanged(nameof(PlayPauseImageSource));
        }
    }

    public float CurrentVolume
    {
        get { return _currentVolume; }
        set
        {

            if (value.Equals(_currentVolume)) return;
            _currentVolume = value;
            OnPropertyChanged(nameof(CurrentVolume));
        }
    }

    public double CurrentTrackLenght
    {
        get { return _currentTrackLenght; }
        set
        {
            if (value.Equals(_currentTrackLenght)) return;
            _currentTrackLenght = value;
            OnPropertyChanged(nameof(CurrentTrackLenght));
        }
    }

    public double CurrentTrackPosition
    {
        get { return _currentTrackPosition; }
        set
        {
            if (value.Equals(_currentTrackPosition)) return;
            _currentTrackPosition = value;
            OnPropertyChanged(nameof(CurrentTrackPosition));
        }
    }

    public Track CurrentlySelectedTrack
    {
        get { return _currentlySelectedTrack; }
        set
        {
            if (Equals(value, _currentlySelectedTrack)) return;
            _currentlySelectedTrack = value;
            OnPropertyChanged(nameof(CurrentlySelectedTrack));
        }
    }

    public Track CurrentlyPlayingTrack
    {
        get { return _currentlyPlayingTrack; }
        set
        {
            if (Equals(value, _currentlyPlayingTrack)) return;
            _currentlyPlayingTrack = value;
            OnPropertyChanged(nameof(CurrentlyPlayingTrack));
        }
    }

    public ObservableCollection<Track> Playlist
    {
        get { return _playlist; }
        set
        {
            if (Equals(value, _playlist)) return;
            _playlist = value;
            OnPropertyChanged(nameof(Playlist));
        }
    }

    public ICommand ExitApplicationCommand { get; set; }
    public ICommand AddFileToPlaylistCommand { get; set; }
    public ICommand AddFolderToPlaylistCommand { get; set; }
    public ICommand SavePlaylistCommand { get; set; }
    public ICommand LoadPlaylistCommand { get; set; }

    public ICommand RewindToStartCommand { get; set; }
    public ICommand StartPlaybackCommand { get; set; }
    public ICommand StopPlaybackCommand { get; set; }
    public ICommand ForwardToEndCommand { get; set; }
    public ICommand ShuffleCommand { get; set; }

    public ICommand TrackControlMouseDownCommand { get; set; }
    public ICommand TrackControlMouseUpCommand { get; set; }
    public ICommand VolumeControlValueChangedCommand { get; set; }

    
    public MainWindowViewModel()
    {
        LoadCommands();

        Playlist = new ObservableCollection<Track>();

		Title = "NaudioPlayer";
        PlayPauseImageSource = "../Images/play.png";
    }

    private void LoadCommands()
    {
        // Menu commands
        ExitApplicationCommand = new RelayCommand(ExitApplication,CanExitApplication);
        AddFileToPlaylistCommand = new RelayCommand(AddFileToPlaylist, CanAddFileToPlaylist);
        AddFolderToPlaylistCommand = new RelayCommand(AddFolderToPlaylist, CanAddFolderToPlaylist);
        SavePlaylistCommand = new RelayCommand(SavePlaylist, CanSavePlaylist);
        LoadPlaylistCommand = new RelayCommand(LoadPlaylist, CanLoadPlaylist);

        // Player commands
        RewindToStartCommand = new RelayCommand(RewindToStart, CanRewindToStart);
        StartPlaybackCommand = new RelayCommand(StartPlayback, CanStartPlayback);
        StopPlaybackCommand = new RelayCommand(StopPlayback, CanStopPlayback);
        ForwardToEndCommand = new RelayCommand(ForwardToEnd, CanForwardToEnd);
        ShuffleCommand = new RelayCommand(Shuffle, CanShuffle);

        // Event commands
        TrackControlMouseDownCommand = new RelayCommand(TrackControlMouseDown, CanTrackControlMouseDown);
        TrackControlMouseUpCommand = new RelayCommand(TrackControlMouseUp, CanTrackControlMouseUp);
        VolumeControlValueChangedCommand = new RelayCommand(VolumeControlValueChanged, CanVolumeControlValueChanged);
    }

    // Menu commands
    private void ExitApplication(object p)
    {

    }
    private bool CanExitApplication(object p)
    {
        return true;
    }

    private void AddFileToPlaylist(object p)
    {

    }
    private bool CanAddFileToPlaylist(object p)
    {
        return true;
    }

    private void AddFolderToPlaylist(object p)
    {

    }

    private bool CanAddFolderToPlaylist(object p)
    {
        return true;
    }

    private void SavePlaylist(object p)
    {

    }

    private bool CanSavePlaylist(object p)
    {
        return true;
    }

    private void LoadPlaylist(object p)
    {

    }

    private bool CanLoadPlaylist(object p)
    {
        return true;
    }

    // Player commands
    private void RewindToStart(object p)
    {

    }
    private bool CanRewindToStart(object p)
    {
        return true;
    }

    private void StartPlayback(object p)
    {

    }

    private bool CanStartPlayback(object p)
    {
        return true;
    }

    private void StopPlayback(object p)
    {

    }
    private bool CanStopPlayback(object p)
    {
        return true;
    }

    private void ForwardToEnd(object p)
    {

    }
    private bool CanForwardToEnd(object p)
    {
        return true;
    }

    private void Shuffle(object p)
    {

    }
    private bool CanShuffle(object p)
    {
        return true;
    }

    // Events
    private void TrackControlMouseDown(object p)
    {

    }

    private void TrackControlMouseUp(object p)
    {

    }

    private bool CanTrackControlMouseDown(object p)
    {
        return true;
    }

    private bool CanTrackControlMouseUp(object p)
    {
        return true;
    }

    private void VolumeControlValueChanged(object p)
    {

    }

    private bool CanVolumeControlValueChanged(object p)
    {
        return true;
    }

    //[NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
}
