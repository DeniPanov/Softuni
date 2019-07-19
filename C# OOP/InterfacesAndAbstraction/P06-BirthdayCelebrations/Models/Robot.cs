namespace P05_BorderControl.Models
{
    using P05_BorderControl.Interfaces;

    public class Robot : Ids
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
