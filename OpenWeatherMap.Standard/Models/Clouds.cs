namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// clouds model
    /// </summary>
    public class Clouds : BaseModel
    {
        private int all;

        /// <summary>
        /// all
        /// </summary>
        public int All
        {
            get => all;
            set => SetProperty(ref all, value);
        }
    }

}
