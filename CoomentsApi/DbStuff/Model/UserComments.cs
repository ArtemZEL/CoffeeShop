using CooffeeApi.DbStuff.Model;

namespace CoffeeApi.DbStuff.Model
{
    public class UserComments : BaseModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }

    }
}
