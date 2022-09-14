namespace MemLeakEvents.Dto;

public class PerformanceSummary
{
    public long BytesInUse { get; set; }
    public float PrivateBytes { get; set; }
    public float Gen0Collections { get; set; }
    public float Gen1Collections { get; set; }
    public float Gen2Collections { get; set; }
    public float Gen0HeapSize { get; set; }
}