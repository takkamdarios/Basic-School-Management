using SchoolManagement.BO;


namespace SchoolManagement.DAL.Base
{
    public class BaseDAO<TModel> : IBaseDAO<TModel> where TModel : BaseModel
    {
        static IList<TModel> Databases { get; set; } = new List<TModel>();
        public Task<TModel> Add(TModel model)
        {
            Databases.Add(model);
            return Task.Run(() => model);
        }

        public Task<bool> Delete(int Id)
        {
            var model = Databases.FirstOrDefault(m => m.Id == Id);
            if(model != null)
            {
                Databases.Remove(model);
            }
            return Task.FromResult(model != null);
        }

        public Task<IList<TModel>> FindAll()
        {
            return Task.FromResult(Databases);
        }

        public Task<TModel> FindById(int Id)
        {
            var model = Databases.FirstOrDefault(m => m.Id == Id);
            return Task.FromResult(model);
        }

        public Task<TModel> Update(TModel model)
        {
            var index = Databases.Select(m => m.Id).ToList().IndexOf(model.Id);
            Databases.RemoveAt(index);
            Databases.Insert(index, model);

            return Task.FromResult(model);
        }
    }
}
