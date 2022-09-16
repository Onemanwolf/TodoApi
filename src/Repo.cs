using TodoApi;


namespace src
{
    public class Repo : IRepo<TodoItem>
    {
        private List<TodoItem> Todos = new List<TodoItem>();
        public async Task<List<TodoItem>> Get()
        {
            var todos = await Task.Run(() => Todos);
            return todos;
        }

        public async Task Save(TodoItem data)
        {
            await Task.Run(() => Todos.Add(data));

        }
    }
}