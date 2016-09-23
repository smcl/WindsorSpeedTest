namespace WindsorSpeedTest
{
    class BenchmarkResult
    {
        public long NewMilliseconds { get; set; }

        public long CastleMilliseconds { get; set; }

        public override string ToString()
        {
            return string.Format("new: {0} ms\ncastle: {1} ms", NewMilliseconds, CastleMilliseconds);
        }
    }
}
