namespace LockIn_API.Services.Aggregators
{
    public interface IMetricAggregatorFactory
    {
        IMetricAggregator GetAggregator(string metricName);
    }
    public class MetricAggregatorFactory : IMetricAggregatorFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Type> _aggregatorMapping;

        public MetricAggregatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            // Define mapping (keys should match the Metric.Name from the database, case-insensitive)
            _aggregatorMapping = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
            {
                { "Water", typeof(WaterIntakeAggregator) },
                // Add additional mappings for each new metric type
            };
        }
        public IMetricAggregator GetAggregator(string metricName)
        {
            if (_aggregatorMapping.TryGetValue(metricName, out var aggregatorType))
            {
                return (IMetricAggregator)_serviceProvider.GetService(aggregatorType);
            }
            throw new Exception($"No aggregator registered for metric '{metricName}'.");
        }
    }
}
