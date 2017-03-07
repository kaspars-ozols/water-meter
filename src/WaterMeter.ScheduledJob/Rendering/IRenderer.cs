namespace WaterMeter.ScheduledJob.Rendering
{
    public interface IRenderer
    {
        string Render<T>(string templateName, T model);
    }
}