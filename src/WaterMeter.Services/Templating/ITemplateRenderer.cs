namespace WaterMeter.Services.Templating
{
    public interface ITemplateRenderer
    {
        string Render<TModel>(string templateFile, TModel model, object templateArgs = null);

    }
}
