namespace Cassette.Babel
{
  public class BabelCompilerQueueInitializer : IStartUpTask
  {
    private readonly BabelCompilerQueue _queue;

    public BabelCompilerQueueInitializer(BabelCompilerQueue queue)
    {
      _queue = queue;
    }

    public void Start()
    {
      _queue.Start();
    }
  }
}
