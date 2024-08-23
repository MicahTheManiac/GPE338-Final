public interface IReplay
{
    public void ReplayStartRecording(bool start);
    public void ReplayPlayback(bool start);
    public float ReplayGetSeconds();
}