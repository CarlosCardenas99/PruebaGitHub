using Telerik.Reporting;

namespace Paltarumi.Acopio.Domain.Extensions
{
    public static class ReportExtensions
    {
        public static void UpdateDataSource(this Report report, string name, string connectionString, Dictionary<string, object> parameters)
        {
            var dataSources = report.GetDataSources();
            var loteDataSource = dataSources.FirstOrDefault(x => x.Name == name) as SqlDataSource;

            if (loteDataSource != null)
            {
                loteDataSource.ConnectionString = connectionString;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        var reportParameter = loteDataSource.Parameters.FirstOrDefault(x => x.Name == parameter.Key);
                        if (reportParameter != null) reportParameter.Value = parameter.Value;
                    }
                }
            }
        }
    }
}
