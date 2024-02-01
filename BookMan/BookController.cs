namespace BookMan;

public class ControllerBase {
    protected void Render<T>(Action<T> action, T model) {
        action?.Invoke(model);
    }
}

public class BookController : ControllerBase {
    private readonly BookRepository _repository = new();

    public void List() {
        var model = _repository.Retrieve();
        var view = BookView.Collection;
        Render(view, model);
    }

    public void Single(string param) {
        var id = param.ToParams()["id"].To<int>();
        var model = _repository.Retrieve(id);
        var view = BookView.Single;
        Render(view, model);
    }
}
